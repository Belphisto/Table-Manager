
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Wordprocessing;

using Microsoft.VisualBasic;


using System.Data.Common;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
using Text = DocumentFormat.OpenXml.Wordprocessing.Text;
using Run = DocumentFormat.OpenXml.Wordprocessing.Run;
using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.Office2013.Word;
using System.Linq.Expressions;

namespace Table_Manager
{
    public partial class Form1 : Form
    {
        public static Person Rec;
        string saveFileName = "";

        private List<Person> persons;

        public Form1()
        {
            InitializeComponent();

            DeleteToolStripButton.Click += DeleteToolStripMenuItem1_Click;
            EditToolStripButton.Click += EditToolStripMenuItem_Click;
            AddToolStripButton.Click += AddToolStripMenuItem_Click;

            CreateToolStripButton.Click += CreateToolStripMenuItem1_Click;
            SaveToolStripButton.Click += SaveToolStripMenuItem1_Click;
            OpenToolStripButton.Click += OpenToolStripMenuItem1_Click;

            // Инициализация списка данными
            persons = new List<Person>
            {
                new Person("Альбус Дамблдор", new DateTime(1881, 8, 15), "Директор", "Хогвартс", 5000000),
                new Person("Минерва Макгонагалл", new DateTime(1935, 10, 4), "Профессор", "Хогвартс", 600000),
                new Person("Рубеус Хагрид", new DateTime(1928, 12, 6), "Лесничий", "Хогвартс", 55000),
                new Person("Волан-де-Морт", new DateTime(1995, 12, 5), "Темный лорд", "Пожиратели смерти", 700000000),
                new Person("Беллатриса Лестрейндж", new DateTime(1951, 7, 18), "Волшебник", "Пожиратели смерти", 650000),
            };

            Redraw();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Redraw();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Получение номера текущей записи
                int currentRow = dataGridView1.CurrentRow.Index;

                // Извлечение данных из таблицы по номеру
                Person selectedPerson = persons[currentRow];

                // Отображение данных в текстовом поле
                CurrentRowTextBox.Text = selectedPerson.ToString();
            }
            catch(System.ArgumentOutOfRangeException ex) { }
            
            
        }

        private void AboutProgramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Приложение Windows Forms\n" +
                "Целевая платформа: .Net 6.0 (долгосрочная поддержка)\n\n" +
                "Выполнила: Мария Анталеева\n" +
                "Группа: ЭУ-239", "О проекте");
        }

        private void AddToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogAdd Dialog = new DialogAdd();
            Dialog.ShowDialog();

            if (Dialog.DialogResult == DialogResult.OK)
            {
                persons.Add(Rec);
                Redraw();
            }
        }

        public void Redraw()
        {
            dataGridView1.DataSource = null;
            dataGridView1.Columns.Clear();

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

        public void Redraw(List<Person> people)
        {
            dataGridView1.DataSource = null;
            dataGridView1.Columns.Clear();

            // Программное назначение свойств для DataGridView
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = people;

            // Программное добавление заголовков колонок
            dataGridView1.Columns["Name"].HeaderText = "Имя";
            dataGridView1.Columns["BirthDate"].HeaderText = "Дата рождения";
            dataGridView1.Columns["Position"].HeaderText = "Должность";
            dataGridView1.Columns["Department"].HeaderText = "Отдел";
            dataGridView1.Columns["Salary"].HeaderText = "Оклад";
        }

        public void Redraw(IEnumerable<IGrouping<string, Person>> persons)
        {
            dataGridView1.DataSource = null;

            // Программное назначение свойств для DataGridView
            dataGridView1.AutoGenerateColumns = true;
            //dataGridView1.DataSource = persons;

            // Программное добавление заголовков колонок
            dataGridView1.Columns.Add("Name", "Имя");
            dataGridView1.Columns.Add("BirthDate", "Дата рождения");
            dataGridView1.Columns.Add("Position", "Должность");
            dataGridView1.Columns.Add("Salary", "Оклад");

            // Проход по группам и добавление их в DataGridView
            foreach (var group in persons)
            {
                // group.Key - это отдел
                // group.ToList() - это список сотрудников в данном отделе

                // добавление заголовка группы
                dataGridView1.Rows.Add($"Отдел: {group.Key}");

                foreach (var person in group)
                {
                    dataGridView1.Rows.Add(person.Name, person.BirthDate, person.Position, person.Salary);
                }
            }
        }

        private void EditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int current = dataGridView1.CurrentRow.Index;
            Rec = persons[current];
            // Передача текущей записи в диалог изменения
            DialogChange dialog = new DialogChange();

            dialog.ShowDialog();
            if (dialog.DialogResult == DialogResult.OK)
            {
                // Обновление записи в таблице
                persons[current] = Rec; // Метод GetRecord возвращает измененную запись из диалога

                // Обновление DataGridView
                Redraw();
            }

        }

        private void DeleteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int current = dataGridView1.CurrentRow.Index;
            Person Rec = persons[current];
            var result = MessageBox.Show("Попытка удалить запись" + Rec.ToString(), "Удаление",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            // Обработка выбора пользователя
            if (result == DialogResult.OK)
            {
                // Удаление записи из таблицы
                persons.RemoveAt(current);

                // Обновление DataGridView
                Redraw();
            }
        }

        private void OpenToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // Получаем имя выбранного файла
                string fileName = openFileDialog1.FileName;

                // Создаем объект StreamReader для чтения файла
                using (StreamReader sr = new StreamReader(fileName))
                {
                    // Очищаем существующие данные
                    persons.Clear();

                    // Читаем файл построчно и добавляем данные в список
                    while (!sr.EndOfStream)
                    {
                        string record = sr.ReadLine();
                        Person worker = Person.Parse(record);
                        persons.Add(worker);
                    }
                    saveFileName = fileName + ".txt";

                    // Обновляем отображение данных
                    Redraw();
                }
            }
        }

        private void SaveToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (saveFileName == "")
            {
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    Save();
            }
            else
                Save();
        }

        private void SaveAsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = saveFileName;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                Save();

        }

        private void Save()
        {
            // Создаем объект StreamWriter для записи в файл
            using (StreamWriter sw = new StreamWriter(saveFileDialog1.FileName))
            {
                // Записываем каждую запись в файл
                foreach (Person worker in persons)
                {
                    sw.WriteLine(worker.Compose());
                }
            }
            saveFileName = saveFileDialog1.FileName + ".txt";
            MessageBox.Show("Данные сохранены успешно", "Сохранение", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void CreateToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (!TableIsEmpty())
            {
                DialogResult result = MessageBox.Show("Сохранить текущие данные в файл?", "Сохранение", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
                if (result == DialogResult.Yes)
                {
                    SaveToolStripMenuItem1_Click(sender, e);
                    persons.Clear();
                    Redraw();
                    saveFileName = "";
                }
                else if (result == DialogResult.No)
                {
                    saveFileName = "";
                    persons.Clear();
                    Redraw();
                }

            }
        }

        private bool TableIsEmpty()
        {
            if (persons.Count == 0) return true;
            else return false;
        }

        private void exelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (persons.Count != 0)
            {
                SaveFileDialog saveExelFileDialog = new SaveFileDialog();
                saveExelFileDialog.Filter = "Excel Files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                if (saveExelFileDialog.ShowDialog() == DialogResult.OK)
                {
                    ExportToExel(saveExelFileDialog.FileName);
                    MessageBox.Show("Данные импортированы в Excel", "Импорт", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Файл не выбран. Импорт не удался", "Импорт", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else MessageBox.Show("Таблица пуста. Импорт не удался", "Импорт", MessageBoxButtons.OK, MessageBoxIcon.Information);


        }

        private void ExportToExel(string fileName)
        {
            using (var spreadsheetDocument = SpreadsheetDocument.Create($"{fileName}", SpreadsheetDocumentType.Workbook))
            {
                // Add a WorkbookPart to the document
                var workbookpart = spreadsheetDocument.AddWorkbookPart();
                workbookpart.Workbook = new Workbook();

                // Add a WorksheetPart to the WorkbookPart
                var worksheetPart = workbookpart.AddNewPart<WorksheetPart>();
                worksheetPart.Worksheet = new Worksheet(new SheetData());

                // Add Sheets to the Workbook
                var sheets = spreadsheetDocument.WorkbookPart.Workbook.AppendChild<Sheets>(new Sheets());
                sheets.Append(new Sheet() { Id = spreadsheetDocument.WorkbookPart.GetIdOfPart(worksheetPart), SheetId = 1, Name = "Sheet1" });

                // Get the SheetData from the worksheet
                var sheetData = worksheetPart.Worksheet.GetFirstChild<SheetData>();

                // Add header row
                var headerRow = new Row();
                headerRow.Append(
                    new Cell { CellValue = new CellValue("Name"), DataType = CellValues.String },
                    new Cell { CellValue = new CellValue("BirthDate"), DataType = CellValues.String },
                    new Cell { CellValue = new CellValue("Position"), DataType = CellValues.String },
                    new Cell { CellValue = new CellValue("Department"), DataType = CellValues.String },
                    new Cell { CellValue = new CellValue("Salary"), DataType = CellValues.String }
                );
                sheetData.AppendChild(headerRow);

                // Add data rows
                foreach (Person person in persons)
                {
                    var dataRow = new Row();
                    dataRow.Append(
                        new Cell { CellValue = new CellValue(person.Name), DataType = CellValues.String },
                        new Cell { CellValue = new CellValue(person.BirthDate.ToString()), DataType = CellValues.String },
                        new Cell { CellValue = new CellValue(person.Position), DataType = CellValues.String },
                        new Cell { CellValue = new CellValue(person.Department), DataType = CellValues.String },
                        new Cell { CellValue = new CellValue(person.Salary.ToString()), DataType = CellValues.String }
                    );
                    sheetData.AppendChild(dataRow);
                }
            }
        }

        private void wordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (persons.Count != 0)
            {
                SaveFileDialog saveWordFileDialog = new SaveFileDialog();
                saveWordFileDialog.Filter = "Word Files (*.docx)|*.docx|All files (*.*)|*.*";
                if (saveWordFileDialog.ShowDialog() == DialogResult.OK)
                {
                    ExportToWord(saveWordFileDialog.FileName);
                    MessageBox.Show("Данные импортированы в Word", "Импорт", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Файл не выбран. Импорт не удался", "Импорт", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else MessageBox.Show("Таблица пуста. Импорт не удался", "Импорт", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ExportToWord(string fileName)
        {
            using (WordprocessingDocument wordDocument = WordprocessingDocument.Create($"{fileName}", WordprocessingDocumentType.Document))
            {
                // Add a main document part
                MainDocumentPart mainPart = wordDocument.AddMainDocumentPart();
                mainPart.Document = new Document();
                var body = mainPart.Document.AppendChild(new Body());

                // Add paragraphs to the body
                foreach (Person person in persons)
                {
                    var paragraph = body.AppendChild(new Paragraph());
                    paragraph.AppendChild(new Run(new Text(person.ToString())));
                }
            }
        }

        private void ShowAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Redraw();
        }

        private bool CheckUserInput(string criteri, out string userInput)
        {
            // Вызываем InputBox для ввода строки
            userInput = Interaction.InputBox($"Введите {criteri}", $"Поиск сотрудника по {criteri}", "Поиск");

            // Check if the user pressed "Cancel" or entered an empty string
            if (string.IsNullOrEmpty(userInput))
            {
                return false;  // Do nothing if the user canceled or entered an empty string
            }
            else return true;
        }

        private void FindFioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CheckUserInput("фио", out string userInput))
            {
                List<Person> resultByFullName = LinqPerson.FindByFio(persons, userInput);
                Redraw(resultByFullName);
            }
        }

        private void FindPositionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var positions = LinqPerson.GetPosition(persons);
            UserChoose choosePosition = new UserChoose(positions);
            if (choosePosition.ShowDialog() == DialogResult.OK)
            {
                string userInput = choosePosition.selected;
                List<Person> result = LinqPerson.FindByPosition(persons, userInput);
                Redraw(result);
                
            }
            else return;
        }

        private void FindDepartmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var departments = LinqPerson.GetDepartment(persons);
            UserChoose chooseDepartment = new UserChoose(departments);
            if (chooseDepartment.ShowDialog() == DialogResult.OK)
            {
                string userInput = chooseDepartment.selected;
                List<Person> result = LinqPerson.FindByDepartment(persons, userInput);
                Redraw(result);
            }
            else return;
        }

        private void Under30YearsOldToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var result = LinqPerson.Under30YearOld(persons);
            Redraw(result);
        }

        private void Under30YearsOldAndPositionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var positions = LinqPerson.GetPosition(persons);
            UserChoose choosePosition = new UserChoose(positions);
            if (choosePosition.ShowDialog() == DialogResult.OK)
            {
                string userInput = choosePosition.selected;
                List<Person> result = LinqPerson.Under30YearOld(persons, userInput);
                Redraw(result);
            }
            else return;
        }

        private void TomorrowBirthdToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<Person> result = LinqPerson.TommorowBirthd(persons);
            Redraw(result);
        }

        private void AverageSalaryByDepartmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var departments = LinqPerson.GetDepartment(persons);
            UserChoose chooseDepartment = new UserChoose(departments);
            if (chooseDepartment.ShowDialog() == DialogResult.OK)
            {
                string userInput = chooseDepartment.selected;
                MessageBox.Show(LinqPerson.AverageSalaryByDepartment(persons, userInput));
            }
            else return;
        }

        private void LessAverageSalaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<Person> result = LinqPerson.LessAverageSalary(persons);
            Redraw(result);
        }

        private void AverageSalaryByAllDepartmentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(LinqPerson.AvarageSalaryByDepartments(persons));
        }

        private void SortByNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var result = LinqPerson.SortByName(persons);
            Redraw(result);
        }

        private void SortBySalaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var result = LinqPerson.SortBySalary(persons);
            Redraw(result);
        }

        private void GroupByDepartmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var groupedByDepartment = LinqPerson.GroupByDepartment(persons);
            Redraw(groupedByDepartment);
        }
    }
}