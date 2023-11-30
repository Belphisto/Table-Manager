namespace Table_Manager
{
    partial class DialogChange
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
            departmentListBox = new ListBox();
            salaryTextBox = new TextBox();
            dateTimePicker1 = new DateTimePicker();
            roleTextBox = new TextBox();
            nameTextBox = new TextBox();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            CancelButton = new Button();
            OkButton = new Button();
            SuspendLayout();
            // 
            // departmentListBox
            // 
            departmentListBox.FormattingEnabled = true;
            departmentListBox.ItemHeight = 15;
            departmentListBox.Location = new Point(137, 185);
            departmentListBox.Name = "departmentListBox";
            departmentListBox.Size = new Size(175, 94);
            departmentListBox.TabIndex = 23;
            // 
            // salaryTextBox
            // 
            salaryTextBox.Location = new Point(136, 148);
            salaryTextBox.Name = "salaryTextBox";
            salaryTextBox.Size = new Size(177, 23);
            salaryTextBox.TabIndex = 22;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(135, 112);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(178, 23);
            dateTimePicker1.TabIndex = 21;
            // 
            // roleTextBox
            // 
            roleTextBox.Location = new Point(134, 71);
            roleTextBox.Name = "roleTextBox";
            roleTextBox.Size = new Size(177, 23);
            roleTextBox.TabIndex = 20;
            // 
            // nameTextBox
            // 
            nameTextBox.Location = new Point(134, 30);
            nameTextBox.Name = "nameTextBox";
            nameTextBox.Size = new Size(177, 23);
            nameTextBox.TabIndex = 19;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(67, 185);
            label5.Name = "label5";
            label5.Size = new Size(40, 15);
            label5.TabIndex = 18;
            label5.Text = "Отдел";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(66, 151);
            label4.Name = "label4";
            label4.Size = new Size(41, 15);
            label4.TabIndex = 17;
            label4.Text = "Оклад";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(17, 118);
            label3.Name = "label3";
            label3.Size = new Size(90, 15);
            label3.TabIndex = 16;
            label3.Text = "Дата рождения";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(38, 74);
            label2.Name = "label2";
            label2.Size = new Size(69, 15);
            label2.TabIndex = 15;
            label2.Text = "Должность";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(76, 33);
            label1.Name = "label1";
            label1.Size = new Size(31, 15);
            label1.TabIndex = 14;
            label1.Text = "Имя";
            // 
            // CancelButton
            // 
            CancelButton.DialogResult = DialogResult.Cancel;
            CancelButton.Location = new Point(222, 291);
            CancelButton.Name = "CancelButton";
            CancelButton.Size = new Size(68, 31);
            CancelButton.TabIndex = 13;
            CancelButton.Text = "Отмена";
            CancelButton.UseVisualStyleBackColor = true;
            CancelButton.Click += CancelButton_Click;
            // 
            // OkButton
            // 
            OkButton.DialogResult = DialogResult.OK;
            OkButton.Location = new Point(76, 291);
            OkButton.Name = "OkButton";
            OkButton.Size = new Size(68, 31);
            OkButton.TabIndex = 12;
            OkButton.Text = "ОК";
            OkButton.UseVisualStyleBackColor = true;
            OkButton.Click += OkButton_Click;
            // 
            // DialogChange
            // 
            AcceptButton = OkButton;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(359, 346);
            Controls.Add(departmentListBox);
            Controls.Add(salaryTextBox);
            Controls.Add(dateTimePicker1);
            Controls.Add(roleTextBox);
            Controls.Add(nameTextBox);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(CancelButton);
            Controls.Add(OkButton);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "DialogChange";
            ShowIcon = false;
            Text = "Редактировать";
            KeyDown += DialogChange_KeyDown;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox departmentListBox;
        private TextBox salaryTextBox;
        private DateTimePicker dateTimePicker1;
        private TextBox roleTextBox;
        private TextBox nameTextBox;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private Button CancelButton;
        private Button OkButton;
    }
}