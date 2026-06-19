/*
Суть версії: Базові класи, поля та три типи конструкторів.
*/
using System;
using System.Collections.Generic;

namespace lab3agapov_v1
{
    /// <summary>
    /// Клас Program містить точку входу для запуску базової версії лабораторної роботи 3.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Створює початкові об'єкти предметної області та запускає головне меню програми.
        /// </summary>
        /// <param name="args">Аргументи командного рядка.</param>
        public static void Main(string[] args)
        {
            Console.Clear();

            Service service = new Service("text", "student_report.txt", "");

            Teacher teacher = new Teacher("Ковалюк Т.В.", "ООП", 120, 1, "", "Матеріали до лабораторної роботи 3");
            Student student = new Student("Агапов Олександр", "ООП", new List<int>(), 0, "", 0);

            service.PrintToConsole("Програму запущено. Початкові об'єкти створені.");
            teacher.RunDemoScenario(service, student);

            Menu menu = new Menu();
            teacher.RunScenario(service, menu, student);
        }
    }
}
