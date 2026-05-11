/*
Суть версії: Власний інтерфейс IPerson та демонстрація поліморфізму.
Декларація про ШІ: Під час написання та рефакторингу коду використовувався штучний інтелект (AI) як асистент для навчальних цілей та дотримання принципів Clean Code.
*/
using System;
using System.Collections.Generic;

namespace lab4agapov_v2
{
    /// <summary>
    /// Клас Program містить точку входу для запуску третьої версії лабораторної роботи 4.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Демонструє використання інтерфейсу IPerson та запускає головне меню програми.
        /// </summary>
        /// <param name="args">Аргументи командного рядка.</param>
        public static void Main(string[] args)
        {
            Console.Clear();

            Service service = new Service("text", "student_report.txt", "");

            service.PrintToConsole("Програму запущено. Початкові об'єкти створені.");

            IPerson firstPerson = new Student("Студент для інтерфейсу", "ООП", new List<int>(), 0, "", 0);
            IPerson secondPerson = new Teacher("Викладач для інтерфейсу", "ООП", 100, 1, "", "Матеріал для інтерфейсу");

            service.PrintToConsole("\n--- Демонстрація інтерфейсу IPerson ---");
            service.PrintToConsole("Перший об'єкт через IPerson (Student):");
            firstPerson.DisplayInfo();
            service.PrintAndSave(((Person)firstPerson).GetInfo());
            service.PrintToConsole("Другий об'єкт через IPerson (Teacher):");
            secondPerson.DisplayInfo();
            service.PrintAndSave(((Person)secondPerson).GetInfo());

            Teacher teacher = new Teacher("Ковалюк Т.В.", "ООП", 120, 1, "", "Матеріали до лабораторної роботи 4");
            Student student = new Student("Агапов Олександр", "ООП", new List<int>(), 0, "", 0);

            Menu menu = new Menu(service, teacher, student);
            menu.Run();
        }
    }
}
