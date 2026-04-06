namespace VolunteerCenters
{
    partial class FormEvents
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            panelTop = new Panel();
            btnAdd = new Button();
            btnEdit = new Button();
            btnDelete = new Button();
            lblUserName = new Label();
            btnLogut = new Button();
            dgvEvent = new DataGridView();
            panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvEvent).BeginInit();
            SuspendLayout();
            // 
            // panelTop
            // 
            panelTop.BackColor = Color.White;
            panelTop.Controls.Add(btnAdd);
            panelTop.Controls.Add(btnEdit);
            panelTop.Controls.Add(btnDelete);
            panelTop.Controls.Add(lblUserName);
            panelTop.Controls.Add(btnLogut);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(984, 40);
            panelTop.TabIndex = 0;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.FromArgb(76, 175, 80);
            btnAdd.BackgroundImageLayout = ImageLayout.Center;
            btnAdd.FlatAppearance.BorderSize = 0;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Location = new Point(0, 0);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(150, 40);
            btnAdd.TabIndex = 11;
            btnAdd.TabStop = false;
            btnAdd.Text = "Добавить";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnEdit
            // 
            btnEdit.BackColor = Color.FromArgb(76, 175, 80);
            btnEdit.BackgroundImageLayout = ImageLayout.Center;
            btnEdit.FlatAppearance.BorderSize = 0;
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.Location = new Point(168, 0);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(150, 40);
            btnEdit.TabIndex = 10;
            btnEdit.TabStop = false;
            btnEdit.Text = "Редактировать";
            btnEdit.UseVisualStyleBackColor = false;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.FromArgb(76, 175, 80);
            btnDelete.BackgroundImageLayout = ImageLayout.Center;
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Location = new Point(336, 0);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(150, 40);
            btnDelete.TabIndex = 9;
            btnDelete.TabStop = false;
            btnDelete.Text = "Удалить";
            btnDelete.UseVisualStyleBackColor = false;
            // 
            // lblUserName
            // 
            lblUserName.AutoSize = true;
            lblUserName.Dock = DockStyle.Right;
            lblUserName.Location = new Point(789, 0);
            lblUserName.Name = "lblUserName";
            lblUserName.Size = new Size(45, 19);
            lblUserName.TabIndex = 8;
            lblUserName.Text = "label1";
            lblUserName.TextAlign = ContentAlignment.MiddleRight;
            // 
            // btnLogut
            // 
            btnLogut.BackColor = Color.FromArgb(76, 175, 80);
            btnLogut.BackgroundImageLayout = ImageLayout.Center;
            btnLogut.Dock = DockStyle.Right;
            btnLogut.FlatAppearance.BorderSize = 0;
            btnLogut.FlatStyle = FlatStyle.Flat;
            btnLogut.Location = new Point(834, 0);
            btnLogut.Name = "btnLogut";
            btnLogut.Size = new Size(150, 40);
            btnLogut.TabIndex = 7;
            btnLogut.TabStop = false;
            btnLogut.Text = "Выйти";
            btnLogut.UseVisualStyleBackColor = false;
            btnLogut.Click += btnLogut_Click;
            // 
            // dgvEvent
            // 
            dgvEvent.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvEvent.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvEvent.BackgroundColor = Color.White;
            dgvEvent.BorderStyle = BorderStyle.None;
            dgvEvent.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEvent.ColumnHeadersVisible = false;
            dgvEvent.Dock = DockStyle.Fill;
            dgvEvent.Location = new Point(0, 40);
            dgvEvent.MultiSelect = false;
            dgvEvent.Name = "dgvEvent";
            dgvEvent.ReadOnly = true;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            dgvEvent.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvEvent.RowHeadersVisible = false;
            dgvEvent.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvEvent.Size = new Size(984, 621);
            dgvEvent.TabIndex = 2;
            // 
            // FormEvents
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(984, 661);
            Controls.Add(dgvEvent);
            Controls.Add(panelTop);
            Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            Margin = new Padding(4);
            Name = "FormEvents";
            Text = "Список мероприятий";
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvEvent).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelTop;
        private Label lblUserName;
        private Button btnLogut;
        private DataGridView dgvEvent;
        private Button btnAdd;
        private Button btnEdit;
        private Button btnDelete;
    }
}