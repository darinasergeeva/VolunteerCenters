using Microsoft.EntityFrameworkCore;
using System.Data;
using VolunteerCenters.Models;

namespace VolunteerCenters
{
    public partial class FormEventEdit : Form
    {
        private BdVolunteerCentersContext _db;
        private Doing _editingDoing;
        private int _eventId;
        public FormEventEdit(Doing doing = null)
        {
            InitializeComponent();
            _editingDoing = doing;
            LoadComboBoxes();
        }

        private void LoadComboBoxes()
        {
            _db = new BdVolunteerCentersContext();

            // Загрузка событий
            var events = _db.Events.ToList();
            cmbEvent.DisplayMember = "NameEvent";
            cmbEvent.ValueMember = "Id";
            cmbEvent.DataSource = events;

            // Загрузка категорий
            var categories = _db.Categories.ToList();
            cmbCategory.DisplayMember = "NameCategori";
            cmbCategory.ValueMember = "Id";
            cmbCategory.DataSource = categories;

            // Загрузка координаторов 
            var coordinators = _db.Users
                .Include(u => u.Role)
                .Where(u => u.Role.NameRole == "Координатор") 
                .ToList();

            cmbCoordinator.DisplayMember = "FullName";
            cmbCoordinator.ValueMember = "Id";
            cmbCoordinator.DataSource = coordinators;

            // Если координаторов нет, показываем сообщение
            if (coordinators.Count == 0)
            {
                cmbCoordinator.Items.Clear();
                cmbCoordinator.Items.Add("Нет доступных координаторов");
                cmbCoordinator.Enabled = false;
                MessageBox.Show("В базе данных нет пользователей с ролью 'Координатор'!\n" +
                    "Добавьте координаторов перед созданием мероприятий.",
                    "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            // Загрузка статусов
            var statuses = _db.EventStatuses.ToList();
            cmbStatus.DisplayMember = "NameEventStatus";
            cmbStatus.ValueMember = "Id";
            cmbStatus.DataSource = statuses;
        }
        private void LoadDoingData()
        {
            if (_editingDoing == null) return;

            // Выбор события в ComboBox
            cmbEvent.SelectedValue = _editingDoing.IdEvent;

            // Выбор категории
            cmbCategory.SelectedValue = _editingDoing.IdCategori;

            // Дата
            dtpDate.Value = _editingDoing.DateDoing.ToDateTime(new TimeOnly(0, 0));

            // Место
            txtPlace.Text = _editingDoing.Place;

            // Количество волонтеров
            numVolunteers.Value = _editingDoing.VolunteersNeeded;

            // Координатор
            cmbCoordinator.SelectedValue = _editingDoing.IdUser;

            // Статус
            cmbStatus.SelectedValue = _editingDoing.IdEventStatus;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Валидация
            if (!ValidateForm())
                return;

            try
            {
                using (var db = new BdVolunteerCentersContext())
                {
                    if (_editingDoing == null)
                    {
                        // добавление
                        var newDoing = new Doing
                        {
                            IdEvent = (int)cmbEvent.SelectedValue,
                            IdCategori = (int)cmbCategory.SelectedValue,
                            DateDoing = DateOnly.FromDateTime(dtpDate.Value),
                            Place = txtPlace.Text.Trim(),
                            VolunteersNeeded = (int)numVolunteers.Value,
                            IdUser = (int)cmbCoordinator.SelectedValue,
                            IdEventStatus = (int)cmbStatus.SelectedValue
                        };

                        db.Doings.Add(newDoing);
                        db.SaveChanges();

                        MessageBox.Show("Мероприятие успешно добавлено!", "Успешно",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        // редактирование
                        var doingToUpdate = db.Doings.Find(_editingDoing.Id);
                        if (doingToUpdate != null)
                        {
                            doingToUpdate.IdEvent = (int)cmbEvent.SelectedValue;
                            doingToUpdate.IdCategori = (int)cmbCategory.SelectedValue;
                            doingToUpdate.DateDoing = DateOnly.FromDateTime(dtpDate.Value);
                            doingToUpdate.Place = txtPlace.Text.Trim();
                            doingToUpdate.VolunteersNeeded = (int)numVolunteers.Value;
                            doingToUpdate.IdUser = (int)cmbCoordinator.SelectedValue;
                            doingToUpdate.IdEventStatus = (int)cmbStatus.SelectedValue;

                            db.SaveChanges();

                            MessageBox.Show("Мероприятие успешно обновлено!", "Успешно",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateForm()
        {
            if (cmbEvent.SelectedItem == null)
            {
                MessageBox.Show("Выберите название мероприятия!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (cmbCategory.SelectedItem == null)
            {
                MessageBox.Show("Выберите категорию!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtPlace.Text))
            {
                MessageBox.Show("Введите место проведения!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (numVolunteers.Value <= 0)
            {
                MessageBox.Show("Количество волонтеров должно быть больше 0!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (cmbCoordinator.SelectedItem == null)
            {
                MessageBox.Show("Выберите координатора!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (cmbStatus.SelectedItem == null)
            {
                MessageBox.Show("Выберите статус мероприятия!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
