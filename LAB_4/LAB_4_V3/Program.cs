
/* * ДЕКЛАРАЦІЯ ПРО ВИКОРИСТАННЯ ШІ:

 * Штучний інтелект використовувався у цій лабораторній роботі виключно

 * як навчальний асистент: для розбору логіки, дебагу та кращого розуміння матеріалу.

 */
/* * Версія 3.0
 * Лабораторна робота №4 з курсу "Об'єктно-орієнтоване програмування 1"
 * Виконав: Агапов Олександр | Група: ІПЗ-11(1) | Варіант: 1
 * * ЕТАПИ ЗАВДАННЯ (Версія 3):
 * 1. Створення інтерфейсу IPerson: визначення контракту для всіх учасників освітнього процесу.
 * 2. Реалізація трирівневої ієрархії: IPerson -> Person (базовий клас) -> Student/Teacher (похідні класи).
 * 3. Поліморфізм: демонстрація роботи з об'єктами класів-нащадків через посилання на інтерфейс IPerson.
 * * ОСНОВНІ ВИМОГИ:
 * - Клас Person у цій версії є не абстрактним та реалізує інтерфейс IPerson.
 * - Використання інтерфейсів для часткового обходу обмеження на множинне успадкування.
 */
using System;

namespace lab4agapov
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Service service = new Service();
            ScientificPaper scientificPaper = new ScientificPaper();
            service.WelcomeInfo();

            // --- Демонстрація поліморфізму через інтерфейс IPerson (Вимога Версії 3) ---
            Console.WriteLine("--- Демонстрація поліморфізму (Версія 3) ---");
            IPerson person1 = new Student("Олег", "Математика", new List<int> { 90, 95 }, 2);
            IPerson person2 = new Teacher("Марія Іванівна", "Фізика", 120, 30);
            person1.DisplayInfo();
            Console.WriteLine("--------------------------------------------");
            person2.DisplayInfo();
            Console.WriteLine("--------------------------------------------\n");

            Teacher myTeacher = new Teacher();
            Student myStudent = new Student();
            List<Student> students = new List<Student>();

            Menu menu = new Menu(service, scientificPaper, myTeacher, myStudent, students);
            menu.Run();
        }
    }
}
