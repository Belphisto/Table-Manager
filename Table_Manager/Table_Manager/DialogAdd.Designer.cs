namespace Table_Manager
{
    partial class DialogAdd
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
            OkButton = new Button();
            CancelButton = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            nameTextBox = new TextBox();
            roleTextBox = new TextBox();
            dateTimePicker1 = new DateTimePicker();
            salaryTextBox = new TextBox();
            departmentListBox = new ListBox();
            SuspendLayout();
            // 
            // OkButton
            // 
            OkButton.DialogResult = DialogResult.OK;
            OkButton.Location = new Point(71, 288);
            OkButton.Name = "OkButton";
            OkButton.Size = new Size(68, 31);
            OkButton.TabIndex = 0;
            OkButton.Text = "ОК";
            OkButton.UseVisualStyleBackColor = true;
            OkButton.Click += OkButton_Click;
            // 
            // CancelButton
            // 
            CancelButton.DialogResult = DialogResult.Cancel;
            CancelButton.Location = new Point(217, 288);
            CancelButton.Name = "CancelButton";
            CancelButton.Size = new Size(68, 31);
            CancelButton.TabIndex = 1;
            CancelButton.Text = "Отмена";
            CancelButton.UseVisualStyleBackColor = true;
            CancelButton.Click += CancelButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(71, 30);
            label1.Name = "label1";
            label1.Size = new Size(31, 15);
            label1.TabIndex = 2;
            label1.Text = "Имя";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(33, 71);
            label2.Name = "label2";
            label2.Size = new Size(69, 15);
            label2.TabIndex = 3;
            label2.Text = "Должность";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 115);
            label3.Name = "label3";
            label3.Size = new Size(90, 15);
            label3.TabIndex = 4;
            label3.Text = "Дата рождения";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(61, 148);
            label4.Name = "label4";
            label4.Size = new Size(41, 15);
            label4.TabIndex = 5;
            label4.Text = "Оклад";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(62, 182);
            label5.Name = "label5";
            label5.Size = new Size(40, 15);
            label5.TabIndex = 6;
            label5.Text = "Отдел";
            // 
            // nameTextBox
            // 
            nameTextBox.Location = new Point(129, 27);
            nameTextBox.Name = "nameTextBox";
            nameTextBox.Size = new Size(177, 23);
            nameTextBox.TabIndex = 7;
            // 
            // roleTextBox
            // 
            roleTextBox.Location = new Point(129, 68);
            roleTextBox.Name = "roleTextBox";
            roleTextBox.Size = new Size(177, 23);
            roleTextBox.TabIndex = 8;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(130, 109);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(178, 23);
            dateTimePicker1.TabIndex = 9;
            // 
            // salaryTextBox
            // 
            salaryTextBox.Location = new Point(131, 145);
            salaryTextBox.Name = "salaryTextBox";
            salaryTextBox.Size = new Size(177, 23);
            salaryTextBox.TabIndex = 10;
            // 
            // departmentListBox
            // 
            departmentListBox.FormattingEnabled = true;
            departmentListBox.ItemHeight = 15;
            departmentListBox.Location = new Point(132, 182);
            departmentListBox.Name = "departmentListBox";
            departmentListBox.Size = new Size(175, 94);
            departmentListBox.TabIndex = 11;
            // 
            // DialogAdd
            // 
            AcceptButton = OkButton;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = CancelButton;
            ClientSize = new Size(361, 346);
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
            KeyPreview = true;
            MaximizeBox = false;
            Name = "DialogAdd";
            ShowIcon = false;
            Text = "Добавить";
            KeyDown += AddForm_KeyDown;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button OkButton;
        private Button CancelButton;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox nameTextBox;
        private TextBox roleTextBox;
        private DateTimePicker dateTimePicker1;
        private TextBox salaryTextBox;
        private ListBox departmentListBox;
    }
}