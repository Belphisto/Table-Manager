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
            // Инициализация списка данными
            persons = new List<Person>
            {
                new Person("Альбус Дамблдор", new DateTime(1881, 8, 15), "Директор", "Хогвартс", 5000000),
                new Person("Минерва Макгонагалл", new DateTime(1935, 10, 4), "Профессор", "Хогвартс", 600000),
                new Person("Рубеус Хагрид", new DateTime(1928, 12, 6), "Лесничий", "Хогвартс", 55000),
                new Person("Волан-де-Морт", new DateTime(1995, 12, 5), "Темный лорд", "Пожиратели смерти", 700000000),
                new Person("Беллатриса Лестрейндж", new DateTime(1951, 7, 18), "Волшебник", "Пожиратели смерти", 650000),
            };

            // Программное назначение свойств для DataGridView
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = persons;

            // Программное добавление заголовков колонок
            dataGridView1.Columns["Name"].HeaderText = "Имя";
            dataGridView1.Columns["BirthDate"].HeaderText = "Дата рождения";
            dataGridView1.Columns["Position"].HeaderText = "Должность";
            dataGridView1.Columns["Department"].HeaderText = "Отдел";
            dataGridView1.Columns["Salary"].HeaderText = "Оклад";
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Получение номера текущей записи
            int currentRow = dataGridView1.CurrentRow.Index;

            // Извлечение данных из таблицы по номеру
            Person selectedPerson = persons[currentRow];

            // Отображение данных в текстовом поле
            CurrentRowTextBox.Text = selectedPerson.ToString();
        }

        private void AboutProgramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Приложение Windows Forms\n" +
                "Целевая платформа: .Net 6.0 (долгосрочная поддержка)\n\n" +
                "Выполнила: Мария Анталеева\n" +
                "Группа: ЭУ-239", "О проекте");
        }
    }
}