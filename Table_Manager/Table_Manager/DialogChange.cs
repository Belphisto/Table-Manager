using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Table_Manager
{
    public partial class DialogChange : Form
    {
        public DialogChange()
        {
            InitializeComponent();
            string[] departments = { "Хогвартс", "Пожиратели смерти" };
            departmentListBox.Items.AddRange(departments);

            nameTextBox.Text = Form1.Rec.Name;
            dateTimePicker1.Value = Form1.Rec.BirthDate;
            roleTextBox.Text = Form1.Rec.Position;
            salaryTextBox.Text = Form1.Rec.Salary.ToString();
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(nameTextBox.Text) &&
                !string.IsNullOrEmpty(roleTextBox.Text) &&
                !string.IsNullOrEmpty(dateTimePicker1.Text) &&
                !string.IsNullOrEmpty(salaryTextBox.Text) && decimal.TryParse(salaryTextBox.Text, out decimal salary) &&
                !string.IsNullOrEmpty(departmentListBox.Text))
            {
                Form1.Rec.Name = nameTextBox.Text;
                Form1.Rec.BirthDate = dateTimePicker1.Value;
                Form1.Rec.Position = roleTextBox.Text;
                Form1.Rec.Department = departmentListBox.SelectedItem.ToString();
                Form1.Rec.Salary = salary;

                this.Close();
            }
            else
            {
                var result = MessageBox.Show("Не заполнены поля", "Проверка",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

                if (result == DialogResult.Yes)
                {
                    // Оставляем форму открытой
                }
                else
                {
                    this.DialogResult = DialogResult.None; // Установите DialogResult на None, чтобы форма осталась открытой
                }
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DialogChange_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // Обработка нажатия Enter
                e.Handled = true; // Это предотвращает "другие" обработчики событий от обработки этого события Enter
                OkButton_Click(sender, e);
            }
            else if (e.KeyCode == Keys.Escape)
            {
                // Обработка нажатия Esc
                e.Handled = true; // Это предотвращает "другие" обработчики событий от обработки этого события Esc
                CancelButton_Click(sender, e);
            }
        }
    }
}
