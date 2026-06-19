/*
Суть версії: Властивості, інкапсуляція та асоціація між класами.
*/
using System;
using System.Collections.Generic;

namespace lab3agapov_v1
{
    /// <summary>
    /// Клас Program містить точку входу для запуску другої версії лабораторної роботи 3.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Ініціалізує об'єкти з використанням інкапсуляції та запускає роботу меню.
        /// </summary>
        /// <param name="args">Аргументи командного рядка.</param>
        public static void Main(string[] args)
        {
            Console.Clear();

            Service service = new Service("text", "student_report.txt", "");
            Teacher teacher = new Teacher("Ковалюк Т.В.", "ООП", 120, 1, "", "Матеріали до лабораторної роботи 3");
            Student.DiplomaProject diploma = new Student.DiplomaProject("", 0, 0, 0, "Ковалюк Т.В.");
            Student student = new Student("Агапов Олександр", "ООП", new List<int>(), 0, "", 0, diploma);

            service.PrintToConsole("Лабораторна робота 3, версія 2. Початкові об'єкти створені.");
            teacher.RunDemoScenario(service, student);

            Menu menu = new Menu();
            teacher.RunScenario(service, menu, student);
        }
    }
}
