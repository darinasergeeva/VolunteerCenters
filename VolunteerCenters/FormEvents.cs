using Microsoft.EntityFrameworkCore;
using VolunteerCenters.Models;

namespace VolunteerCenters
{
    public partial class FormEvents : Form
    {
        public User CurrentUser { get; private set; }
        public bool IsGuest { get; private set; }
        public bool IsAdmin { get; private set; }

        private List<Doing> _allDoings;
        private Dictionary<int, int> _confirmedRegistrations;

        // Элементы фильтрации
        private TextBox txtSearch;
        private ComboBox cmbFilterStatus;
        private ComboBox cmbSortBy;
        private Button btnReset;

        public FormEvents(User user, bool guest, bool admin)
        {
            InitializeComponent();
            CreateFilterControls();

            CurrentUser = user;
            IsGuest = guest;
            IsAdmin = admin;

            lblUserName.Text = IsGuest ? "Гость" : CurrentUser.FullName;
            this.Text = IsAdmin ? "Список мероприятий (Администратор)" : "Список мероприятий";

            ConfigureDataGridViewColumns();
            LoadEvents();
            SetButtonsVisibility();
        }

        private void CreateFilterControls()
        {
            Panel filterPanel = new Panel();
            filterPanel.Dock = DockStyle.Top;
            filterPanel.Height = 45;
            filterPanel.BackColor = ColorTranslator.FromHtml("#F0FFF0");
            filterPanel.Padding = new Padding(5);

            Label lblSearch = new Label() { Text = "Поиск:", Location = new Point(10, 12), Size = new Size(45, 25), Font = new Font("Times New Roman", 10) };
            txtSearch = new TextBox() { Name = "txtSearch", Location = new Point(60, 10), Size = new Size(200, 25), Font = new Font("Times New Roman", 10) };
            txtSearch.TextChanged += ApplyFilterAndSort;

            Label lblFilter = new Label() { Text = "Фильтр:", Location = new Point(280, 12), Size = new Size(50, 25), Font = new Font("Times New Roman", 10) };
            cmbFilterStatus = new ComboBox() { Name = "cmbFilterStatus", Location = new Point(335, 10), Size = new Size(130, 25), Font = new Font("Times New Roman", 10), DropDownStyle = ComboBoxStyle.DropDownList };
            cmbFilterStatus.Items.AddRange(new string[] { "Все", "Запланировано", "Завершено", "Отменено" });
            cmbFilterStatus.SelectedIndex = 0;
            cmbFilterStatus.SelectedIndexChanged += ApplyFilterAndSort;

            Label lblSort = new Label() { Text = "Сортировка:", Location = new Point(485, 12), Size = new Size(70, 25), Font = new Font("Times New Roman", 10) };
            cmbSortBy = new ComboBox() { Name = "cmbSortBy", Location = new Point(560, 10), Size = new Size(180, 25), Font = new Font("Times New Roman", 10), DropDownStyle = ComboBoxStyle.DropDownList };
            cmbSortBy.Items.AddRange(new string[] { "По дате (новые)", "По дате (старые)", "По названию (А-Я)", "По названию (Я-А)", "По свободным местам (меньше)", "По свободным местам (больше)", "По % набора (меньше)", "По % набора (больше)" });
            cmbSortBy.SelectedIndex = 0;
            cmbSortBy.SelectedIndexChanged += ApplyFilterAndSort;

            btnReset = new Button() { Text = "Сбросить", Location = new Point(760, 9), Size = new Size(90, 28), BackColor = ColorTranslator.FromHtml("#4CAF50"), ForeColor = Color.White, Font = new Font("Times New Roman", 10), FlatStyle = FlatStyle.Flat };
            btnReset.Click += BtnReset_Click;

            filterPanel.Controls.AddRange(new Control[] { lblSearch, txtSearch, lblFilter, cmbFilterStatus, lblSort, cmbSortBy, btnReset });
            this.Controls.Add(filterPanel);

            if (dgvEvent != null)
            {
                dgvEvent.Top = filterPanel.Height + 5;
                dgvEvent.Height = this.ClientSize.Height - filterPanel.Height - 60;
            }
        }

        private void SetButtonsVisibility()
        {
            if (btnAdd != null) btnAdd.Visible = IsAdmin;
            if (btnEdit != null) btnEdit.Visible = IsAdmin;
            if (btnDelete != null) btnDelete.Visible = IsAdmin;
        }

        private void ConfigureDataGridViewColumns()
        {
            dgvEvent.Columns.Clear();

            dgvEvent.Columns.Add("colName", "Название мероприятия");
            dgvEvent.Columns.Add("colCategory", "Категория");
            dgvEvent.Columns.Add("colDate", "Дата проведения");
            dgvEvent.Columns.Add("colPlace", "Место проведения");
            dgvEvent.Columns.Add("colVolunteersNeeded", "Нужно волонтеров");
            dgvEvent.Columns.Add("colCoordinator", "Координатор");
            dgvEvent.Columns.Add("colStatus", "Статус мероприятия");
            dgvEvent.Columns.Add("colFreeSpots", "Свободных мест");
            dgvEvent.Columns.Add("colPercent", "% набора волонтеров");

            dgvEvent.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvEvent.RowTemplate.Height = 35;
            dgvEvent.DefaultCellStyle.Font = new Font("Times New Roman", 10);
            dgvEvent.ColumnHeadersDefaultCellStyle.Font = new Font("Times New Roman", 11, FontStyle.Bold);
            dgvEvent.AllowUserToAddRows = false;
            dgvEvent.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvEvent.MultiSelect = false;
        }

        private void LoadEvents()
        {
            try
            {
                using (var db = new BdVolunteerCentersContext())
                {
                    _allDoings = db.Doings
                        .Include(d => d.Event)
                        .Include(d => d.Category)
                        .Include(d => d.EventStatus)
                        .Include(d => d.User)
                        .ToList();

                    var confirmedStatusId = db.RegistrationStatuses
                        .FirstOrDefault(rs => rs.NameRegistrationStatus == "Подтверждено")?.Id ?? 0;

                    _confirmedRegistrations = db.VolunteerRegistrations
                        .Where(vr => vr.IdRegistrationStatus == confirmedStatusId)
                        .GroupBy(vr => vr.IdEvent)
                        .Select(g => new { IdEvent = g.Key, Count = g.Count() })
                        .ToDictionary(x => x.IdEvent, x => x.Count);

                    ApplyFilterAndSort(null, null);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ApplyFilterAndSort(object sender, EventArgs e)
        {
            if (_allDoings == null) return;

            // Фильтрация
            var filtered = _allDoings.AsEnumerable();

            string search = txtSearch.Text.Trim().ToLower();
            if (!string.IsNullOrWhiteSpace(search))
            {
                filtered = filtered.Where(d =>
                    (d.Event?.NameEvent?.ToLower().Contains(search) == true) ||
                    (d.Place?.ToLower().Contains(search) == true) ||
                    (d.User?.FullName?.ToLower().Contains(search) == true));
            }

            string status = cmbFilterStatus.SelectedItem?.ToString();
            if (status != null && status != "Все")
            {
                filtered = filtered.Where(d => d.EventStatus?.NameEventStatus == status);
            }

            // Подготовка данных для сортировки
            var data = filtered.Select(d => new
            {
                Doing = d,
                Confirmed = _confirmedRegistrations.ContainsKey(d.IdEvent) ? _confirmedRegistrations[d.IdEvent] : 0,
                FreeSpots = Math.Max(0, d.VolunteersNeeded - (_confirmedRegistrations.ContainsKey(d.IdEvent) ? _confirmedRegistrations[d.IdEvent] : 0)),
                Percent = d.VolunteersNeeded > 0 ? ((_confirmedRegistrations.ContainsKey(d.IdEvent) ? _confirmedRegistrations[d.IdEvent] : 0) * 100.0 / d.VolunteersNeeded) : 0
            }).ToList();

            // Сортировка
            string sort = cmbSortBy.SelectedItem?.ToString();
            switch (sort)
            {
                case "По дате (новые)": data = data.OrderByDescending(x => x.Doing.DateDoing).ToList(); break;
                case "По дате (старые)": data = data.OrderBy(x => x.Doing.DateDoing).ToList(); break;
                case "По названию (А-Я)": data = data.OrderBy(x => x.Doing.Event?.NameEvent).ToList(); break;
                case "По названию (Я-А)": data = data.OrderByDescending(x => x.Doing.Event?.NameEvent).ToList(); break;
                case "По свободным местам (меньше)": data = data.OrderBy(x => x.FreeSpots).ToList(); break;
                case "По свободным местам (больше)": data = data.OrderByDescending(x => x.FreeSpots).ToList(); break;
                case "По % набора (меньше)": data = data.OrderBy(x => x.Percent).ToList(); break;
                case "По % набора (больше)": data = data.OrderByDescending(x => x.Percent).ToList(); break;
                default: data = data.OrderByDescending(x => x.Doing.DateDoing).ToList(); break;
            }

            // Отображение
            dgvEvent.Rows.Clear();

            foreach (var item in data)
            {
                var d = item.Doing;
                int rowIndex = dgvEvent.Rows.Add();
                var row = dgvEvent.Rows[rowIndex];

                row.Tag = d.Id;
                row.Cells["colName"].Value = d.Event?.NameEvent ?? "—";
                row.Cells["colCategory"].Value = d.Category?.NameCategori ?? "—";
                row.Cells["colDate"].Value = d.DateDoing.ToString("dd.MM.yyyy");
                row.Cells["colPlace"].Value = d.Place;
                row.Cells["colVolunteersNeeded"].Value = d.VolunteersNeeded;
                row.Cells["colCoordinator"].Value = d.User?.FullName ?? "—";
                row.Cells["colStatus"].Value = d.EventStatus?.NameEventStatus ?? "—";
                row.Cells["colFreeSpots"].Value = item.FreeSpots;
                row.Cells["colPercent"].Value = $"{item.Percent:F1}%";

                ApplyRowStyle(row, d.EventStatus?.NameEventStatus, item.FreeSpots);
            }

            this.Text = $"Список мероприятий{(IsAdmin ? " (Админ)" : "")} - Найдено: {data.Count}";
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            cmbFilterStatus.SelectedIndex = 0;
            cmbSortBy.SelectedIndex = 0;
        }

        private void ApplyRowStyle(DataGridViewRow row, string status, int freeSpots)
        {
            if (status == "Отменено")
                row.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#FFB6C1");
            else if (status == "Завершено")
                row.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#E0E0E0");
            else if (status == "Запланировано" && freeSpots < 3 && freeSpots > 0)
                row.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#FFE5B4");
        }

        private int GetSelectedDoingId()
        {
            if (dgvEvent.SelectedRows.Count == 0) return -1;
            var row = dgvEvent.SelectedRows[0];
            return row.Tag != null ? (int)row.Tag : -1;
        }

        private void btnLogut_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (var form = new FormEventEdit())
            {
                if (form.ShowDialog() == DialogResult.OK)
                    LoadEvents();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvEvent.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите мероприятие!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int id = GetSelectedDoingId();
            if (id == -1) return;

            using (var db = new BdVolunteerCentersContext())
            {
                var doing = db.Doings
                    .Include(d => d.Event)
                    .Include(d => d.Category)
                    .Include(d => d.EventStatus)
                    .Include(d => d.User)
                    .FirstOrDefault(d => d.Id == id);

                if (doing != null)
                {
                    using (var form = new FormEventEdit(doing))
                    {
                        if (form.ShowDialog() == DialogResult.OK)
                            LoadEvents();
                    }
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvEvent.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите мероприятие!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int id = GetSelectedDoingId();
            if (id == -1) return;

            var result = MessageBox.Show("Удалить мероприятие? Все регистрации будут удалены.", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                using (var db = new BdVolunteerCentersContext())
                {
                    var registrations = db.VolunteerRegistrations.Where(vr => vr.IdEvent == id);
                    db.VolunteerRegistrations.RemoveRange(registrations);

                    var doing = db.Doings.Find(id);
                    if (doing != null)
                    {
                        db.Doings.Remove(doing);
                        db.SaveChanges();
                        LoadEvents();
                    }
                }
            }
        }
    }
}