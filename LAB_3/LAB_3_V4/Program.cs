using System;
using System.Collections.Generic;

namespace lab3agapov_v1
{
    /// <summary>
    /// Клас Program містить точку входу в консольну програму четвертої версії лабораторної роботи.
    /// У цьому класі створюються початкові об'єкти сервісу, викладача, студента і дипломного проєкту.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Головний метод програми. Він очищає консоль, створює один набір об'єктів предметної області
        /// та передає керування головному меню.
        /// </summary>
        /// <param name="args">Аргументи командного рядка, які в цій лабораторній роботі не використовуються.</param>
        static void Main(string[] args)
        {
            Console.Clear();

            Service service = new Service("text", "student_report.txt", "");
            Teacher teacher = new Teacher("Ковалюк Т.В.", "ООП", 120, 1, "", "Матеріали до лабораторної роботи 3");
            Student.DiplomaProject diploma = new Student.DiplomaProject("", 0, 0, 0, "Ковалюк Т.В.");
            Student student = new Student("Агапов Олександр", "ООП", new List<int>(), 0, "", 0, diploma);

            service.PrintToConsole("Лабораторна робота 3, версія 4. Початкові об'єкти створені.");

            Menu menu = new Menu(service, teacher, student);
            menu.Run();
        }
    }
}
