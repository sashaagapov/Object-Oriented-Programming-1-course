using System;
using System.Collections.Generic;

namespace lab4agapov_v2
{
    /// <summary>
    /// Клас Program містить точку входу в третю версію лабораторної роботи 4.
    /// Тут створюються початкові об'єкти викладача, студента, сервісу і меню.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Назва програми для прикладу конструктора з параметрами.
        /// </summary>
        private string programName;

        /// <summary>
        /// Конструктор за замовчуванням створює програму з порожньою назвою.
        /// </summary>
        public Program()
        {
            programName = "";
        }

        /// <summary>
        /// Конструктор з параметрами задає назву програми.
        /// </summary>
        /// <param name="programName">Назва програми.</param>
        public Program(string programName)
        {
            this.programName = programName;
        }

        /// <summary>
        /// Конструктор копії створює програму з назвою іншого об'єкта Program.
        /// </summary>
        /// <param name="other">Об'єкт Program, з якого копіюється назва.</param>
        public Program(Program other)
        {
            programName = other.programName;
        }

        /// <summary>
        /// Властивість для читання та зміни назви програми.
        /// </summary>
        public string ProgramName
        {
            get { return programName; }
            set { programName = value; }
        }

        /// <summary>
        /// Головний метод програми. Він очищає консоль, створює початкові дані
        /// та запускає меню для роботи з освітнім процесом.
        /// </summary>
        /// <param name="args">Аргументи командного рядка, які в цій програмі не використовуються.</param>
        public static void Main(string[] args)
        {
            Console.Clear();

            Service service = new Service("text", "student_report.txt", "");

            WelcomeInfo(service);
            ShowInterfaceDemo();

            Teacher teacher = new Teacher("Ковалюк Т.В.", "ООП", 120, 1, "", "Матеріали до лабораторної роботи 4");
            Student student = new Student("Агапов Олександр", "ООП", new List<int>(), 0, "", 0);

            Menu menu = new Menu(service, teacher, student);
            menu.Run();
        }

        /// <summary>
        /// Виводить початкове повідомлення програми.
        /// </summary>
        /// <param name="service">Сервіс для виведення повідомлення.</param>
        private static void WelcomeInfo(Service service)
        {
            service.PrintToConsole("Програму запущено. Початкові об'єкти створені.");
        }

        /// <summary>
        /// Демонструє роботу з об'єктами Student і Teacher через інтерфейс IPerson.
        /// </summary>
        private static void ShowInterfaceDemo()
        {
            IPerson firstPerson = new Student("Студент для інтерфейсу", "ООП", new List<int>(), 0, "", 0);
            IPerson secondPerson = new Teacher("Викладач для інтерфейсу", "ООП", 100, 1, "", "Матеріал для інтерфейсу");

            Console.WriteLine("\n--- Демонстрація інтерфейсу IPerson ---");
            Console.WriteLine("Перший об'єкт: " + firstPerson.Name);
            Console.WriteLine("Дисципліна першого об'єкта: " + firstPerson.SubjectName);
            Console.WriteLine("Другий об'єкт: " + secondPerson.Name);
            Console.WriteLine("Дисципліна другого об'єкта: " + secondPerson.SubjectName);
        }
    }
}
