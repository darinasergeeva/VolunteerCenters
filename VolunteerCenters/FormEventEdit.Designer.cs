namespace VolunteerCenters
{
    partial class FormEventEdit
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
            lblEvent = new Label();
            cmbEvent = new ComboBox();
            cmbCategory = new ComboBox();
            lblCategory = new Label();
            lblDate = new Label();
            dtpDate = new DateTimePicker();
            lblPlace = new Label();
            txtPlace = new TextBox();
            lblVolunteers = new Label();
            numVolunteers = new NumericUpDown();
            lblCoordinator = new Label();
            cmbCoordinator = new ComboBox();
            cmbStatus = new ComboBox();
            lblStatus = new Label();
            btnSave = new Button();
            btnCancel = new Button();
            ((System.ComponentModel.ISupportInitialize)numVolunteers).BeginInit();
            SuspendLayout();
            // 
            // lblEvent
            // 
            lblEvent.AutoSize = true;
            lblEvent.Location = new Point(24, 27);
            lblEvent.Name = "lblEvent";
            lblEvent.Size = new Size(169, 19);
            lblEvent.TabIndex = 0;
            lblEvent.Text = "Название мероприятия:\t";
            // 
            // cmbEvent
            // 
            cmbEvent.FormattingEnabled = true;
            cmbEvent.Location = new Point(24, 64);
            cmbEvent.Name = "cmbEvent";
            cmbEvent.Size = new Size(337, 27);
            cmbEvent.TabIndex = 1;
            // 
            // cmbCategory
            // 
            cmbCategory.FormattingEnabled = true;
            cmbCategory.Location = new Point(24, 146);
            cmbCategory.Name = "cmbCategory";
            cmbCategory.Size = new Size(337, 27);
            cmbCategory.TabIndex = 3;
            // 
            // lblCategory
            // 
            lblCategory.AutoSize = true;
            lblCategory.Location = new Point(24, 109);
            lblCategory.Name = "lblCategory";
            lblCategory.Size = new Size(79, 19);
            lblCategory.TabIndex = 2;
            lblCategory.Text = "Категория";
            // 
            // lblDate
            // 
            lblDate.AutoSize = true;
            lblDate.Location = new Point(24, 191);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(125, 19);
            lblDate.TabIndex = 4;
            lblDate.Text = "Дата проведения";
            // 
            // dtpDate
            // 
            dtpDate.Location = new Point(24, 228);
            dtpDate.Name = "dtpDate";
            dtpDate.Size = new Size(334, 26);
            dtpDate.TabIndex = 5;
            // 
            // lblPlace
            // 
            lblPlace.AutoSize = true;
            lblPlace.Location = new Point(24, 272);
            lblPlace.Name = "lblPlace";
            lblPlace.Size = new Size(136, 19);
            lblPlace.TabIndex = 6;
            lblPlace.Text = "Место проведения";
            // 
            // txtPlace
            // 
            txtPlace.Location = new Point(24, 309);
            txtPlace.Name = "txtPlace";
            txtPlace.Size = new Size(337, 26);
            txtPlace.TabIndex = 7;
            // 
            // lblVolunteers
            // 
            lblVolunteers.AutoSize = true;
            lblVolunteers.Location = new Point(24, 353);
            lblVolunteers.Name = "lblVolunteers";
            lblVolunteers.Size = new Size(138, 19);
            lblVolunteers.TabIndex = 8;
            lblVolunteers.Text = "Нужно волонтёров";
            // 
            // numVolunteers
            // 
            numVolunteers.Location = new Point(24, 390);
            numVolunteers.Name = "numVolunteers";
            numVolunteers.Size = new Size(337, 26);
            numVolunteers.TabIndex = 9;
            // 
            // lblCoordinator
            // 
            lblCoordinator.AutoSize = true;
            lblCoordinator.Location = new Point(24, 434);
            lblCoordinator.Name = "lblCoordinator";
            lblCoordinator.Size = new Size(99, 19);
            lblCoordinator.TabIndex = 10;
            lblCoordinator.Text = "Координатор";
            // 
            // cmbCoordinator
            // 
            cmbCoordinator.FormattingEnabled = true;
            cmbCoordinator.Location = new Point(24, 471);
            cmbCoordinator.Name = "cmbCoordinator";
            cmbCoordinator.Size = new Size(337, 27);
            cmbCoordinator.TabIndex = 11;
            // 
            // cmbStatus
            // 
            cmbStatus.FormattingEnabled = true;
            cmbStatus.Location = new Point(24, 553);
            cmbStatus.Name = "cmbStatus";
            cmbStatus.Size = new Size(337, 27);
            cmbStatus.TabIndex = 13;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(24, 516);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(55, 19);
            lblStatus.TabIndex = 12;
            lblStatus.Text = "Статус";
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(76, 175, 80);
            btnSave.BackgroundImageLayout = ImageLayout.Center;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Location = new Point(24, 601);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(150, 40);
            btnSave.TabIndex = 14;
            btnSave.TabStop = false;
            btnSave.Text = "Сохранить";
            btnSave.UseVisualStyleBackColor = false;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.Honeydew;
            btnCancel.BackgroundImageLayout = ImageLayout.Center;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Location = new Point(196, 601);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(150, 40);
            btnCancel.TabIndex = 15;
            btnCancel.TabStop = false;
            btnCancel.Text = "Отмена";
            btnCancel.UseVisualStyleBackColor = false;
            // 
            // FormEventEdit
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(384, 653);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(cmbStatus);
            Controls.Add(lblStatus);
            Controls.Add(cmbCoordinator);
            Controls.Add(lblCoordinator);
            Controls.Add(numVolunteers);
            Controls.Add(lblVolunteers);
            Controls.Add(txtPlace);
            Controls.Add(lblPlace);
            Controls.Add(dtpDate);
            Controls.Add(lblDate);
            Controls.Add(cmbCategory);
            Controls.Add(lblCategory);
            Controls.Add(cmbEvent);
            Controls.Add(lblEvent);
            Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(4, 4, 4, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormEventEdit";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Редактор";
            ((System.ComponentModel.ISupportInitialize)numVolunteers).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblEvent;
        private ComboBox cmbEvent;
        private ComboBox cmbCategory;
        private Label lblCategory;
        private Label lblDate;
        private DateTimePicker dtpDate;
        private Label lblPlace;
        private TextBox txtPlace;
        private Label lblVolunteers;
        private NumericUpDown numVolunteers;
        private Label lblCoordinator;
        private ComboBox cmbCoordinator;
        private ComboBox cmbStatus;
        private Label lblStatus;
        private Button btnSave;
        private Button btnCancel;
    }
}