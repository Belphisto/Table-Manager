namespace Table_Manager
{
    public partial class Form1 : Form
    {
        private List<Person> persons;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // ������������� ������ �������
            persons = new List<Person>
            {
                new Person("������ ��������", new DateTime(1881, 8, 15), "��������", "��������", 5000000),
                new Person("������� �����������", new DateTime(1935, 10, 4), "���������", "��������", 600000),
                new Person("������ ������", new DateTime(1928, 12, 6), "��������", "��������", 55000),
                new Person("�����-��-����", new DateTime(1995, 12, 5), "������ ����", "���������� ������", 700000000),
                new Person("���������� ����������", new DateTime(1951, 7, 18), "���������", "���������� ������", 650000),
            };

            // ����������� ���������� ������� ��� DataGridView
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = persons;

            // ����������� ���������� ���������� �������
            dataGridView1.Columns["Name"].HeaderText = "���";
            dataGridView1.Columns["BirthDate"].HeaderText = "���� ��������";
            dataGridView1.Columns["Position"].HeaderText = "���������";
            dataGridView1.Columns["Department"].HeaderText = "�����";
            dataGridView1.Columns["Salary"].HeaderText = "�����";
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // ��������� ������ ������� ������
            int currentRow = dataGridView1.CurrentRow.Index;

            // ���������� ������ �� ������� �� ������
            Person selectedPerson = persons[currentRow];

            // ����������� ������ � ��������� ����
            CurrentRowTextBox.Text = selectedPerson.ToString();
        }

        private void AboutProgramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("���������� Windows Forms\n" +
                "������� ���������: .Net 6.0 (������������ ���������)\n\n" +
                "���������: ����� ���������\n" +
                "������: ��-239", "� �������");
        }
    }
}