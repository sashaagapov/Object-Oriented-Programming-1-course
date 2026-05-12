/*
Суть версії: Використання partial-класів та вкладених класів (Composition).
Декларація про ШІ: Під час написання та рефакторингу коду використовувався штучний інтелект (AI) як асистент для навчальних цілей та дотримання принципів Clean Code.
*/
using System;
using System.Collections.Generic;

namespace lab3agapov_v1
{
    /// <summary>
    /// Клас Program містить точку входу для запуску третьої версії лабораторної роботи 3.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Налаштовує сутності з partial та вкладеними структурами і запускає меню взаємодії.
        /// </summary>
        /// <param name="args">Аргументи командного рядка.</param>
        public static void Main(string[] args)
        {
            Console.Clear();

            Service service = new Service("text", "student_report.txt", "");
            Teacher teacher = new Teacher("Ковалюк Т.В.", "ООП", 120, 1, "", "Матеріали до лабораторної роботи 3");
            Student.DiplomaProject diploma = new Student.DiplomaProject("", 0, 0, 0, "Ковалюк Т.В.");
            Student student = new Student("Агапов Олександр", "ООП", new List<int>(), 0, "", 0, diploma);

            service.PrintToConsole("Лабораторна робота 3, версія 3. Початкові об'єкти створені.");

            Menu menu = new Menu(service, teacher, student);
            menu.Run();
        }
    }
}
