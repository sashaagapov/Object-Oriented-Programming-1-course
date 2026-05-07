using System;
using System.Collections.Generic;

namespace lab4agapov_v4
{
    /// <summary>
    /// Клас Program містить точку входу в четверту версію лабораторної роботи 4.
    /// Тут створюються початкові об'єкти викладача, студента, сервісу і меню.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Головний метод програми. Він очищає консоль, створює початкові дані
        /// та запускає меню для роботи з освітнім процесом.
        /// </summary>
        /// <param name="args">Аргументи командного рядка, які в цій програмі не використовуються.</param>
        public static void Main(string[] args)
        {
            Console.Clear();

            Service service = new Service("text", "student_report.txt", "");

            WelcomeInfo(service);

            Teacher teacher = new Teacher("Ковалюк Т.В.", "ООП", 120, 1, "", "Матеріали до лабораторної роботи 4");
            IPerson demoPerson = teacher;
            service.PrintToConsole("Демонстрація IPerson: " + demoPerson.Name);

            Student student = new Student("Агапов Олександр", "ООП", new List<int>(), 0, "", 0);

            StudentGroup group = CreateStudentGroup(student);

            DemonstrateMainLogic(service, teacher, student, group);

            Menu menu = new Menu(service, teacher, student, group);
            menu.Run();

            service.PrintToConsole("Фінальний звіт буде збережено у файл student_report.txt.");
            service.SaveReport(teacher, student);
        }

        /// <summary>
        /// Виводить початкове повідомлення програми.
        /// </summary>
        /// <param name="service">Сервіс для виведення повідомлення.</param>
        private static void WelcomeInfo(Service service)
        {
            service.PrintToConsole("Програму запущено.");
        }

        /// <summary>
        /// Створює допоміжну групу студентів для демонстрації стандартних інтерфейсів.
        /// </summary>
        /// <param name="student">Основний студент програми.</param>
        /// <returns>Група студентів для версії 4.</returns>
        private static StudentGroup CreateStudentGroup(Student student)
        {
            StudentGroup group = new StudentGroup();
            List<int> gradesOne = new List<int>();
            List<int> gradesTwo = new List<int>();
            List<int> gradesThree = new List<int>();
            Student secondStudent;
            Student thirdStudent;
            Student fourthStudent;

            gradesOne.Add(90);
            gradesOne.Add(95);
            gradesOne.Add(88);

            gradesTwo.Add(75);
            gradesTwo.Add(80);

            gradesThree.Add(100);
            gradesThree.Add(96);
            gradesThree.Add(98);
            gradesThree.Add(94);

            secondStudent = new Student("Іваненко Марія", "ООП", gradesOne, 3, "Матеріал до ЛР4", 0);
            thirdStudent = new Student("Петренко Назар", "ООП", gradesTwo, 2, "Матеріал до ЛР4", 0);
            fourthStudent = new Student("Сидоренко Олена", "ООП", gradesThree, 4, "Матеріал до ЛР4", 0);

            group.AddStudent(student);
            group.AddStudent(secondStudent);
            group.AddStudent(thirdStudent);
            group.AddStudent(fourthStudent);

            return group;
        }

        /// <summary>
        /// Демонструє просту взаємодію викладача зі студентом і сортування групи.
        /// </summary>
        /// <param name="service">Сервіс для виведення повідомлень.</param>
        /// <param name="teacher">Основний викладач.</param>
        /// <param name="student">Основний студент.</param>
        /// <param name="group">Допоміжна група студентів.</param>
        private static void DemonstrateMainLogic(Service service, Teacher teacher, Student student, StudentGroup group)
        {
            teacher.GiveMaterial(student);
            teacher.GradeStudent(student, 95);
            student.CalculateRating();
            service.PrintToConsole("Викладач передав матеріал і поставив оцінку основному студенту.");

            group.SortStudents();
            service.PrintToConsole("Групу відсортовано за рейтингом через IComparable<Student>.");

            group.SortByTasks();
            service.PrintToConsole("Групу відсортовано за кількістю робіт через IComparer<Student>.");
        }
    }
}
