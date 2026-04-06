namespace VolunteerCenters
{
    partial class FormLogin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLogin));
            pictureBoxLogo = new PictureBox();
            txtLogin = new TextBox();
            lblogin = new Label();
            pnMain = new Panel();
            btnGuest = new Button();
            btnLogin = new Button();
            lbPassword = new Label();
            txtPassword = new TextBox();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogo).BeginInit();
            pnMain.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBoxLogo
            // 
            pictureBoxLogo.Image = (Image)resources.GetObject("pictureBoxLogo.Image");
            pictureBoxLogo.Location = new Point(142, 21);
            pictureBoxLogo.Name = "pictureBoxLogo";
            pictureBoxLogo.Size = new Size(100, 100);
            pictureBoxLogo.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxLogo.TabIndex = 0;
            pictureBoxLogo.TabStop = false;
            // 
            // txtLogin
            // 
            txtLogin.Location = new Point(38, 39);
            txtLogin.Name = "txtLogin";
            txtLogin.Size = new Size(250, 26);
            txtLogin.TabIndex = 1;
            txtLogin.UseSystemPasswordChar = true;
            // 
            // lblogin
            // 
            lblogin.AutoSize = true;
            lblogin.Location = new Point(137, 8);
            lblogin.Name = "lblogin";
            lblogin.Size = new Size(52, 19);
            lblogin.TabIndex = 0;
            lblogin.Text = "Логин";
            // 
            // pnMain
            // 
            pnMain.Anchor = AnchorStyles.None;
            pnMain.Controls.Add(btnGuest);
            pnMain.Controls.Add(btnLogin);
            pnMain.Controls.Add(lbPassword);
            pnMain.Controls.Add(txtPassword);
            pnMain.Controls.Add(txtLogin);
            pnMain.Controls.Add(lblogin);
            pnMain.Location = new Point(31, 127);
            pnMain.Name = "pnMain";
            pnMain.Size = new Size(322, 220);
            pnMain.TabIndex = 3;
            // 
            // btnGuest
            // 
            btnGuest.BackColor = Color.Honeydew;
            btnGuest.BackgroundImageLayout = ImageLayout.Center;
            btnGuest.FlatAppearance.BorderSize = 0;
            btnGuest.FlatStyle = FlatStyle.Flat;
            btnGuest.Location = new Point(88, 188);
            btnGuest.Name = "btnGuest";
            btnGuest.Size = new Size(150, 30);
            btnGuest.TabIndex = 5;
            btnGuest.Text = "Войти как гость";
            btnGuest.UseVisualStyleBackColor = false;
            btnGuest.Click += btnGuest_Click;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.FromArgb(76, 175, 80);
            btnLogin.BackgroundImageLayout = ImageLayout.Center;
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Location = new Point(88, 146);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(150, 30);
            btnLogin.TabIndex = 4;
            btnLogin.Text = "Войти";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // lbPassword
            // 
            lbPassword.AutoSize = true;
            lbPassword.Location = new Point(134, 77);
            lbPassword.Name = "lbPassword";
            lbPassword.Size = new Size(58, 19);
            lbPassword.TabIndex = 3;
            lbPassword.Text = "Пароль";
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(38, 108);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(250, 26);
            txtPassword.TabIndex = 2;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // FormLogin
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(384, 361);
            Controls.Add(pnMain);
            Controls.Add(pictureBoxLogo);
            Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            Margin = new Padding(4);
            Name = "FormLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Вход в систему";
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogo).EndInit();
            pnMain.ResumeLayout(false);
            pnMain.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBoxLogo;
        private TextBox txtLogin;
        private Label lblogin;
        private Panel pnMain;
        private Button btnGuest;
        private Button btnLogin;
        private Label lbPassword;
        private TextBox txtPassword;
    }
}