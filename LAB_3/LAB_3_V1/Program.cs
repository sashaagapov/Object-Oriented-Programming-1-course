using System;
using System.Collections.Generic;

namespace lab3agapov_v1
{
    /// <summary>
    /// Клас Program містить точку входу в першу версію лабораторної роботи.
    /// Тут створюються початкові об'єкти одного викладача, одного студента і сервісу.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Головний метод програми. Він очищає консоль, створює початкові дані
        /// та запускає меню для роботи з освітнім процесом.
        /// </summary>
        /// <param name="args">Аргументи командного рядка, які в цій програмі не використовуються.</param>
        static void Main(string[] args)
        {
            Console.Clear();

            Service service = new Service("text", "student_report.txt", "");

            Teacher teacher = new Teacher("Ковалюк Т.В.", "ООП", 120, 1, "", "Матеріали до лабораторної роботи 3");
            Student student = new Student("Агапов Олександр", "ООП", new List<int>(), 0, "", 0);

            service.PrintToConsole("Програму запущено. Початкові об'єкти створені.");

            Menu menu = new Menu(service, teacher, student);
            menu.Run();
        }
    }
}
