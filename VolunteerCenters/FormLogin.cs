using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace VolunteerCenters
{
    public partial class FormLogin : Form
    {
        public Models.User CurrentUser { get; private set; }
        public bool IsGuest { get; private set; }
        public FormLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtLogin.Text) || String.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Введите логин и пароль", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var db = new BdVolunteerCentersContext())
            {
                var user = db.Users
                    .Include(u => u.Role)
                    .Where(w => w.Login == txtLogin.Text && w.Password == txtPassword.Text)
                    .FirstOrDefault();

                if (user != null)
                {
                    CurrentUser = user;
                    IsGuest = false;


                    string roleName = user.Role?.NameRole ?? "Роль не загружена";
                    MessageBox.Show($"Добро пожаловать, {user.FullName}!\nВаша роль: {roleName}",
                        "Успешный вход",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Неверный логин или пароль", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnGuest_Click(object sender, EventArgs e)
        {
            CurrentUser = null;
            IsGuest = true;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
