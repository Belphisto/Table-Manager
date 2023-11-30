
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Wordprocessing;


using System.Data.Common;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
using Text = DocumentFormat.OpenXml.Wordprocessing.Text;
using Run = DocumentFormat.OpenXml.Wordprocessing.Run;

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

            // ������������� ������ �������
            persons = new List<Person>
            {
                new Person("������ ��������", new DateTime(1881, 8, 15), "��������", "��������", 5000000),
                new Person("������� �����������", new DateTime(1935, 10, 4), "���������", "��������", 600000),
                new Person("������ ������", new DateTime(1928, 12, 6), "��������", "��������", 55000),
                new Person("�����-��-����", new DateTime(1995, 12, 5), "������ ����", "���������� ������", 700000000),
                new Person("���������� ����������", new DateTime(1951, 7, 18), "���������", "���������� ������", 650000),
            };

            Redraw();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Redraw();
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

        private void EditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int current = dataGridView1.CurrentRow.Index;
            Rec = persons[current];
            // �������� ������� ������ � ������ ���������
            DialogChange dialog = new DialogChange();

            dialog.ShowDialog();
            if (dialog.DialogResult == DialogResult.OK)
            {
                // ���������� ������ � �������
                persons[current] = Rec; // ����� GetRecord ���������� ���������� ������ �� �������

                // ���������� DataGridView
                Redraw();
            }

        }

        private void DeleteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int current = dataGridView1.CurrentRow.Index;
            Person Rec = persons[current];
            var result = MessageBox.Show("������� ������� ������" + Rec.ToString(), "��������",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            // ��������� ������ ������������
            if (result == DialogResult.OK)
            {
                // �������� ������ �� �������
                persons.RemoveAt(current);

                // ���������� DataGridView
                Redraw();
            }
        }

        private void OpenToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // �������� ��� ���������� �����
                string fileName = openFileDialog1.FileName;

                // ������� ������ StreamReader ��� ������ �����
                using (StreamReader sr = new StreamReader(fileName))
                {
                    // ������� ������������ ������
                    persons.Clear();

                    // ������ ���� ��������� � ��������� ������ � ������
                    while (!sr.EndOfStream)
                    {
                        string record = sr.ReadLine();
                        Person worker = Person.Parse(record);
                        persons.Add(worker);
                    }
                    saveFileName = fileName + ".txt";

                    // ��������� ����������� ������
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
            // ������� ������ StreamWriter ��� ������ � ����
            using (StreamWriter sw = new StreamWriter(saveFileDialog1.FileName))
            {
                // ���������� ������ ������ � ����
                foreach (Person worker in persons)
                {
                    sw.WriteLine(worker.Compose());
                }
            }
            saveFileName = saveFileDialog1.FileName + ".txt";
            MessageBox.Show("������ ��������� �������", "����������", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void CreateToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (!TableIsEmpty())
            {
                DialogResult result = MessageBox.Show("��������� ������� ������ � ����?", "����������", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
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
                    MessageBox.Show("������ ������������� � Excel", "������", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("���� �� ������. ������ �� ������", "������", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else MessageBox.Show("������� �����. ������ �� ������", "������", MessageBoxButtons.OK, MessageBoxIcon.Information);


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
                    MessageBox.Show("������ ������������� � Word", "������", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("���� �� ������. ������ �� ������", "������", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else MessageBox.Show("������� �����. ������ �� ������", "������", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
    }
}