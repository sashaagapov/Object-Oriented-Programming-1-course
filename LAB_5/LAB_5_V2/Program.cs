using System;
using System.Collections.Generic;

namespace lab5agapov_v2
{
    /// <summary>
    /// Точка входу для запуску лабораторної роботи №5, версія 2.
    /// </summary>
    public class Program
    {
        public static void Main(string[] args)
        {
            Service service = new Service("text", "lab5_v2_report.txt", "");
            Teacher teacher = new Teacher("Ковалюк Т.В.", "ООП", 120, 1, "Журнал оцінок з ООП", "Методичка з ООП");
            Student student = new Student("Агапов Олександр", "ООП", new List<int>(), 0, "Методичка з ООП", 0);
            DiplomaProject project = new DiplomaProject("Система обліку навчальних результатів", 3, "Середня", 85, "Ковалюк Т.В.");
            Menu menu = new Menu();

            service.PrintToConsole("Програму запущено. Початкові об'єкти створені.");
            teacher.RunDemoScenario(service, student, project);
            teacher.RunScenario(service, menu, student, project);
        }
    }
}
