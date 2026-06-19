using System;
using System.Collections.Generic;

namespace lab5agapov_v3
{
    /// <summary>
    /// Точка входу для запуску лабораторної роботи №5, версія 3.
    /// </summary>
    public class Program
    {
        public static void Main(string[] args)
        {
            Service service = new Service("text", "lab5_v3_report.txt", "");
            Teacher teacher = new Teacher("Ковалюк Т.В.", "ООП", 120, 2, "Журнал оцінок з ООП", "Методичка з ООП");
            Student student = new Student("Агапов Олександр", "ООП", new List<int>(), 0, "Методичка з ООП", 0);
            Student anotherStudent = new Student("Інший студент", "ООП", new List<int> { 70, 75 }, 2, "Конспект з ООП", 0);
            StudentGroup group = new StudentGroup();
            DiplomaProject project = new DiplomaProject("Аналітика освітніх процесів", 4, "Середня", 90, "Ковалюк Т.В.");
            Menu menu = new Menu();

            group.AddStudent(student);
            group.AddStudent(anotherStudent);

            service.PrintToConsole("Програму запущено. Початкові об'єкти створені.");
            teacher.RunDemoScenario(service, student, group, project);
            teacher.RunScenario(service, menu, student, group, project);
        }
    }
}
