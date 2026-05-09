using System;
using System.Collections.Generic;

namespace lab4agapov_v2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Clear();

            Service service = new Service("text", "student_report.txt", "");

            service.PrintToConsole("Програму запущено. Початкові об'єкти створені.");

            IPerson firstPerson = new Student("Студент для інтерфейсу", "ООП", new List<int>(), 0, "", 0);
            IPerson secondPerson = new Teacher("Викладач для інтерфейсу", "ООП", 100, 1, "", "Матеріал для інтерфейсу");

            Console.WriteLine("\n--- Демонстрація інтерфейсу IPerson ---");
            Console.WriteLine("Перший об'єкт: " + firstPerson.Name);
            Console.WriteLine("Дисципліна першого об'єкта: " + firstPerson.SubjectName);
            Console.WriteLine("Другий об'єкт: " + secondPerson.Name);
            Console.WriteLine("Дисципліна другого об'єкта: " + secondPerson.SubjectName);

            Teacher teacher = new Teacher("Ковалюк Т.В.", "ООП", 120, 1, "", "Матеріали до лабораторної роботи 4");
            Student student = new Student("Агапов Олександр", "ООП", new List<int>(), 0, "", 0);

            Menu menu = new Menu(service, teacher, student);
            menu.Run();
        }
    }
}
