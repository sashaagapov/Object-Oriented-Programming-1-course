using System;
using System.Collections.Generic;

namespace lab3agapov_v1
{
    /// <summary>
    /// Клас Program містить точку входу в другу версію лабораторної роботи.
    /// У цій версії разом зі студентом створюється його вкладений дипломний проєкт.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Головний метод програми створює сервіс, одного викладача, один дипломний проєкт,
        /// одного студента і запускає меню для роботи з ними.
        /// </summary>
        /// <param name="args">Аргументи командного рядка, які не використовуються у програмі.</param>
        static void Main(string[] args)
        {
            Console.Clear();

            Service service = new Service("text", "student_report.txt", "");
            Teacher teacher = new Teacher("Ковалюк Т.В.", "ООП", 120, 1, "", "Матеріали до лабораторної роботи 3");
            Student.DiplomaProject diploma = new Student.DiplomaProject("", 0, 0, 0, "Ковалюк Т.В.");
            Student student = new Student("Агапов Олександр", "ООП", new List<int>(), 0, "", 0, diploma);

            service.PrintToConsole("Лабораторна робота 3, версія 2. Початкові об'єкти створені.");

            Menu menu = new Menu(service, teacher, student);
            menu.Run();
        }
    }
}
