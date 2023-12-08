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
    public partial class UserChoose : Form
    {
        public string selected { get; private set; }
        public UserChoose()
        {
            InitializeComponent();
        }

        public UserChoose(List<string> arr)
        {
            InitializeComponent();
            listBox1.DataSource = arr;
        }

        private void OK_Click(object sender, EventArgs e)
        {
            selected = listBox1.SelectedItem as string;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
