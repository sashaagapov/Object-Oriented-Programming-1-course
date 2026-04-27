
/* * ДЕКЛАРАЦІЯ ПРО ВИКОРИСТАННЯ ШІ:

 * Штучний інтелект використовувався у цій лабораторній роботі виключно 

 * як навчальний асистент: для розбору логіки, дебагу та кращого розуміння матеріалу.

 */
/* * Версія 4.0 
 * Лабораторна робота №3 з курсу "Об'єктно-орієнтоване програмування 1"
 * Виконав: Агапов Олександр | Група: ІПЗ-11(1) | Варіант: 1
 * ЕТАПИ ЗАВДАННЯ (Версія 4 = Версія 3 + п.9):
 * 1. Усі класи з Версії 3.
 * 2. Додано статичний клас ScientificPaper з методом бінарного пошуку SearchReference.
 * 3. Метод SearchReference взято з лабораторної роботи №2 (алгоритми пошуку).
 */

namespace lab3agapov
{

    /// <summary>
    /// Клас Program є точкою входу в консольний застосунок і запускає основний сценарій роботи програми.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Головний метод програми. Ініціалізує основні об'єкти та запускає головне меню.
        /// </summary>
        /// <param name="args">Аргументи командного рядка, передані під час запуску програми.</param>
        static void Main(string[] args)
        {
            Console.Clear();
            Service service = new Service();
            service.WelcomeInfo();

            Teacher myTeacher = new Teacher();
            Student myStudent = new Student();
            List<Student> students = new List<Student>();

            Menu menu = new Menu(service, myTeacher, myStudent, students);
            menu.Run();
        }
    }
}
