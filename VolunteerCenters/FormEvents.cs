using Microsoft.EntityFrameworkCore;
using System.Data;
using VolunteerCenters.Models;

namespace VolunteerCenters
{
    public partial class FormEvents : Form
    {

        public User CurrentUser { get; private set; }
        public bool IsGuest { get; private set; }

        public FormEvents(User user, bool guest)
        {
            InitializeComponent();

            CurrentUser = user;
            IsGuest = guest;

            lblUserName.Text = IsGuest ? "Гость" : CurrentUser.FullName;
            this.Text = "Список мероприятий";

            ConfigureDataGridViewColumns();

            LoadEvents();

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
                    // Загрузка мероприятий со связанными данными
                    var doings = db.Doings
                        .Include(d => d.Event)
                        .Include(d => d.Category)
                        .Include(d => d.EventStatus)
                        .Include(d => d.User)
                        .ToList();

                    var confirmedStatusId = db.RegistrationStatuses
                        .FirstOrDefault(rs => rs.NameRegistrationStatus == "Подтверждено")?.Id ?? 0;

                    var confirmedRegistrations = db.VolunteerRegistrations
                        .Where(vr => vr.IdRegistrationStatus == confirmedStatusId)
                        .GroupBy(vr => vr.IdEvent)
                        .Select(g => new { IdEvent = g.Key, Count = g.Count() })
                        .ToDictionary(x => x.IdEvent, x => x.Count);

                    dgvEvent.Rows.Clear();

                    foreach (var doing in doings)
                    {
                        int confirmedCount = confirmedRegistrations.ContainsKey(doing.IdEvent)
                            ? confirmedRegistrations[doing.IdEvent]
                            : 0;

                        int freeSpots = doing.VolunteersNeeded - confirmedCount;
                        if (freeSpots < 0) freeSpots = 0;

                        double percent = doing.VolunteersNeeded > 0
                            ? (confirmedCount * 100.0 / doing.VolunteersNeeded)
                            : 0;

                        int rowIndex = dgvEvent.Rows.Add();
                        var row = dgvEvent.Rows[rowIndex];

                        row.Tag = doing.Id;

                        row.Cells["colName"].Value = doing.Event?.NameEvent ?? "—";
                        row.Cells["colCategory"].Value = doing.Category?.NameCategori ?? "—";
                        row.Cells["colDate"].Value = doing.DateDoing.ToString("dd.MM.yyyy");
                        row.Cells["colPlace"].Value = doing.Place;
                        row.Cells["colVolunteersNeeded"].Value = doing.VolunteersNeeded;
                        row.Cells["colCoordinator"].Value = doing.User?.FullName ?? "—";
                        row.Cells["colStatus"].Value = doing.EventStatus?.NameEventStatus ?? "—";
                        row.Cells["colFreeSpots"].Value = freeSpots;
                        row.Cells["colPercent"].Value = $"{percent:F1}%";

                        ApplyRowStyle(row, doing.EventStatus?.NameEventStatus, freeSpots);
                    }

                    dgvEvent.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCells);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ApplyRowStyle(DataGridViewRow row, string status, int freeSpots)
        {
            if (status == "Отменено")
            {
                row.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#FFB6C1");
            }
            else if (status == "Завершено")
            {
                row.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#E0E0E0");
            }
            else if (status == "Запланировано" && freeSpots < 3 && freeSpots > 0)
            {
                row.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#FFE5B4");
            }
        }

        private void btnLogut_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (var formEdit = new FormEventEdit())
            {
                if (formEdit.ShowDialog() == DialogResult.OK)
                {
                    LoadEvents();
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            // Проверка, что выбран хотя бы один ряд
            if (dgvEvent.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите мероприятие для редактирования!", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Получаем ID выбранного мероприятия
            int selectedId = GetSelectedDoingId();

            if (selectedId == -1)
            {
                MessageBox.Show("Не удалось определить ID мероприятия!\n" +
                    "Проверьте, что колонка colId существует и содержит данные.",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (var db = new BdVolunteerCentersContext())
                {
                    var doing = db.Doings
                        .Include(d => d.Event)
                        .Include(d => d.Category)
                        .Include(d => d.EventStatus)
                        .Include(d => d.User)
                        .FirstOrDefault(d => d.Id == selectedId);

                    if (doing != null)
                    {
                        using (var formEdit = new FormEventEdit(doing))
                        {
                            if (formEdit.ShowDialog() == DialogResult.OK)
                            {
                                LoadEvents();
                                MessageBox.Show("Данные обновлены!", "Успех",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show($"Мероприятие с ID {selectedId} не найдено в базе данных!",
                            "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при редактировании: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int GetSelectedDoingId()
        {
            if (dgvEvent.SelectedRows.Count == 0) return -1;

            var selectedRow = dgvEvent.SelectedRows[0];

            if (selectedRow.Tag != null)
            {
                return (int)selectedRow.Tag;
            }

            MessageBox.Show("Tag строки пуст! ID не сохранен.", "Ошибка",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            return -1;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvEvent.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите мероприятие для удаления!", "Внимание",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int selectedId = GetSelectedDoingId();
            if (selectedId == -1) return;

            // Подтверждение удаления
            var result = MessageBox.Show("Вы уверены, что хотите удалить это мероприятие?\n" +
                "Все связанные регистрации также будут удалены!",
                "Подтверждение удаления",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    using (var db = new BdVolunteerCentersContext())
                    {
                        // Сначала удаляем связанные регистрации
                        var registrations = db.VolunteerRegistrations
                            .Where(vr => vr.IdEvent == selectedId);
                        db.VolunteerRegistrations.RemoveRange(registrations);

                        // Затем удаляем само мероприятие
                        var doing = db.Doings.Find(selectedId);
                        if (doing != null)
                        {
                            db.Doings.Remove(doing);
                            db.SaveChanges();

                            MessageBox.Show("Мероприятие успешно удалено!", "Успех",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

                            LoadEvents(); // Обновляем таблицу
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при удалении: {ex.Message}", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
