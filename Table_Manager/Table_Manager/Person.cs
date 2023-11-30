using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Table_Manager
{
    public class Person
    {   // Описание класса "Человек" - закрытые поля
        private string _name;           // Поле "имя"
        private DateTime _birthDate;    // Поле "Дата рождения"
        private string _post;           // Поле "Должность"
        private string _department;     // Поле "Отдел"
        private decimal _salary;        // Поле "Оклад"

        //Свойства доступа к полям
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public DateTime BirthDate
        {
            get { return _birthDate; }
            set { _birthDate = value; }
        }

        public string Position
        {
            get { return _post; }
            set { _post = value; }
        }

        public string Department
        {
            get { return _department; }
            set { _department = value; }
        }

        public decimal Salary
        {
            get { return _salary; }
            set { _salary = value; }
        }

        // Конструкторы
        public Person()
        {
            // Конструктор по умолчанию
        }

        public Person(string name, DateTime birthDate, string position, string department, decimal salary)
        {
            // Конструктор с параметрами
            _name = name;
            _birthDate = birthDate;
            _post = position;
            _department = department;
            _salary = salary;
        }

        // Перегрузка метода ToString
        public override string ToString()
        {
            return $"Имя: {_name}, Дата рождения: {_birthDate.ToShortDateString()}, Должность: {_post}, Отдел: {_department}, Оклад: {_salary:C}\n";
        }

        // Метод для композиции объекта Person в строку
        public string Compose()
        {
            return $"{_name},{_birthDate.ToShortDateString()},{_post},{_department},{_salary:C}";
        }

        // Метод для парсинга строки и создания объекта Person
        public static Person Parse(string record)
        {
            string[] fields = record.Split(',');
            Person worker = new Person(fields[0], Convert.ToDateTime(fields[1]), fields[2], fields[3], Convert.ToDecimal(fields[4]));
            return worker;
        }
    }
}
