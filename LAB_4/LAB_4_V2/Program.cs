/*
 * Лабораторна робота №4 — Версія 2
 * Суть версії: Абстрактний базовий клас і розділення інтерфейсу сутності від її конкретних реалізацій.
 */
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
            Teacher teacher = new Teacher("Ковалюк Т.В.", "ООП", 120, 1, "", "Матеріали до лабораторної роботи 4");
            Student student = new Student("Агапов Олександр", "ООП", new List<int>(), 0, "", 0);

            service.PrintToConsole("Програму запущено. Початкові об'єкти створені.");
            teacher.RunDemoScenario(service, student);

            Menu menu = new Menu();
            teacher.RunScenario(service, menu, student);
        }
    }
}
