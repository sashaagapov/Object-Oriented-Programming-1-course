using System;
using System.Collections.Generic;

namespace lab5agapov_v1
{
    /// <summary>
    /// Точка входу для демонстрації функціоналу лабораторної роботи (Версія 1).
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Запускає демонстрацію динамічного поліморфізму та записує протокол у файл.
        /// </summary>
        /// <param name="args">Аргументи командного рядка.</param>
        public static void Main(string[] args)
        {
            Service service = new Service();

            DiplomaProject diplomaProject = new DiplomaProject(
                "Система обліку навчальних результатів",
                3,
                "Середня",
                0,
                "Ковалюк Т.В."
            );

            Teacher teacherObject = new Teacher("Ковалюк Т.В.", "ООП", 120, 1, "", "Матеріали до лабораторної роботи 5");
            teacherObject.DiplomaProject = diplomaProject;

            Student studentObject = new Student("Агапов Олександр", "ООП", new List<int>(), 0, "Методичка з ООП", 85.0);
            studentObject.DiplomaProject = diplomaProject;

            // Через базовий тип Person показуємо поліморфний виклик GetInfo().
            Person teacher = teacherObject;
            Person student = studentObject;

            service.PrintAndSave("--- Демонстрація динамічного поліморфізму ---");
            service.PrintAndSave(teacher.GetInfo());
            service.PrintAndSave("");
            service.PrintAndSave(student.GetInfo());
            service.SaveProtocolToFile("lab5_v1_protocol.txt");
        }
    }
}
