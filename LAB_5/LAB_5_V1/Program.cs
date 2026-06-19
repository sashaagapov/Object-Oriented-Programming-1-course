using System;
using System.Collections.Generic;

namespace lab5agapov_v1
{
    /// <summary>
    /// Точка входу для запуску лабораторної роботи №5, версія 1.
    /// </summary>
    public class Program
    {
        public static void Main(string[] args)
        {
            Service service = new Service("text", "lab5_v1_report.txt", "");
            DiplomaProject diplomaProject = new DiplomaProject(
                "Система обліку навчальних результатів",
                3,
                "Середня",
                0,
                "Ковалюк Т.В."
            );
            Teacher teacher = new Teacher("Ковалюк Т.В.", "ООП", 120, 1, "", "Матеріали до лабораторної роботи 5");
            Student student = new Student("Агапов Олександр", "ООП", new List<int>(), 0, "Методичка з ООП", 0);
            Menu menu = new Menu();

            teacher.DiplomaProject = diplomaProject;
            student.DiplomaProject = diplomaProject;

            service.PrintToConsole("Програму запущено. Початкові об'єкти створені.");
            teacher.RunDemoScenario(service, student);
            teacher.RunScenario(service, menu, student);
        }
    }
}
