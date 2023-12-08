using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Table_Manager
{
    internal class LinqPerson
    {
        public static  List<Person> FindBy(Func<Person, bool> criteria, List<Person> personsCollection)
        {
            return personsCollection.Where(criteria).ToList();
        }

        public static List<Person> FindByFio(List<Person> personsCollection, string userInput)
        {
            return personsCollection.Where(p => p.Name.Contains(userInput)).ToList();
        }

        public static List<Person> FindByDepartment(List<Person> personsCollection, string userInput)
        {
            return personsCollection.Where(p => p.Department == userInput).ToList();
        }

        public static List<Person> FindByPosition(List<Person> personsCollection, string userInput)
        {
            return personsCollection.Where(p => p.Position == userInput).ToList();
        }

        public static List<string> GetPosition(List<Person> persons)
        {
            // Запрос LINQ для получения списка всех должностей
            var allPositions = persons.Select(p => p.Position).Distinct().ToList();
            return allPositions;
        }

        public static List<string> GetDepartment(List<Person> persons)
        {
            // Запрос LINQ для получения списка всех отделов
            var allDepartment = persons.Select(p => p.Department).Distinct().ToList();
            return allDepartment;
        }

        public static List<Person> Under30YearOld(List<Person> personsCollection)
        {
            DateTime today = DateTime.Today;
            int ageLimit = 30;
            List<Person> resultUnder30 = FindBy(p => (today - p.BirthDate).TotalDays < (365.25 * ageLimit), personsCollection);
            return resultUnder30;
        }

        public static List<Person> Under30YearOld(List<Person> personsCollection, string position)
        {
            DateTime today = DateTime.Today;
            int ageLimit = 30;
            List<Person> resultUnder30 = FindBy(
                 p => (today - p.BirthDate).TotalDays < (365 * ageLimit) && p.Position == position,
                 personsCollection);
            return resultUnder30;
        }

        public static List<Person> TommorowBirthd(List<Person> personsCollection)
        {
            // Дата завтрашнего дня
            DateTime tomorrow = DateTime.Now.AddDays(1);

            var personsTomorrow = personsCollection.Where(p => p.BirthDate.Day == tomorrow.Day && p.BirthDate.Month == tomorrow.Month).ToList();
            return personsTomorrow;
        }

        public static List<Person> LessAverageSalary(List<Person> personsCollection)
        {
            decimal averageSalary = personsCollection.Average(p => p.Salary);
            var belowAverage = personsCollection.Where(p => p.Salary < averageSalary).ToList();
            return belowAverage;
        }

        public static string AvarageSalaryByDepartments(List<Person> personsCollection) 
        {
            var averageSalaryByDepartment = personsCollection
                .GroupBy(p => p.Department)
                .Select(g => new
                {
                    Department = g.Key,
                    AverageSalary = g.Average(p => p.Salary)
                });

            string message = "Средняя зарплата по отделам:\n";
            foreach (var item in averageSalaryByDepartment)
            {
                message += $"{item.Department}: {item.AverageSalary:C}\n";
            }

            return message;
        }

        public static string AverageSalaryByDepartment(List<Person> personsCollection, string department)
        {
            var averageSalaryByDepartment = personsCollection
            .Where(p => p.Department == department)
            .Average(p => p.Salary);

            return $"Средняя зарплата по отделу {department}: {averageSalaryByDepartment:C}";
        }

        public static List<Person> SortByName(List<Person> personsCollection)
        {
            var sortedByName = personsCollection.OrderBy(p => p.Name).ToList();
            return sortedByName;
        }

        public static List<Person> SortBySalary(List<Person> personsCollection)
        {
            var sortedBySalary= personsCollection.OrderBy(p => p.Salary).ToList();
            return sortedBySalary;
        }
        public static IEnumerable<IGrouping<string,Person>> GroupByDepartment(List<Person> personsCollection)
        {
            var groupedByDepartment = personsCollection.GroupBy(p => p.Department);
            return groupedByDepartment;
        }

    }
}
