
/* * ДЕКЛАРАЦІЯ ПРО ВИКОРИСТАННЯ ШІ:

 * Штучний інтелект використовувався у цій лабораторній роботі виключно

 * як навчальний асистент: для розбору логіки, дебагу та кращого розуміння матеріалу.

 */
/* * Версія 4.0
 * Лабораторна робота №4 з курсу "Об'єктно-орієнтоване програмування 1"
 * Виконав: Агапов Олександр | Група: ІПЗ-11(1) | Варіант: 1
 * * ЕТАПИ ЗАВДАННЯ (Версія 4):
 * 1. Реалізація інтерфейсів IEnumerable та IEnumerator для перебору колекції студентів через foreach.
 * 2. Реалізація інтерфейсу IComparable для сортування студентів за рейтингом.
 * 3. Створення класу StudentGroup для управління колекцією студентів.
 * * ОСНОВНІ ВИМОГИ:
 * - Робота зі стандартними інтерфейсами .NET.
 * - Демонстрація перебору власної колекції через foreach.
 * - Сортування об'єктів за допомогою стандартних алгоритмів сортування.
 */
namespace lab4agapov
{
    /// <summary>
    /// Клас Program є точкою входу в консольний застосунок версії LAB_4_V4.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Головний метод програми. Створює основні об'єкти, завантажує дані студентів і запускає головне меню.
        /// </summary>
        /// <param name="args">Аргументи командного рядка, передані під час запуску програми.</param>
        static void Main(string[] args)
        {
            Console.Clear();
            Service service = new Service();
            service.WelcomeInfo();
            StudentGroup group = new StudentGroup();
            Teacher myTeacher = new Teacher();
            Student myStudent = new Student();
            service.LoadStudentFromFile(group,"student_data.txt");
            Menu menu = new Menu(service, group, myTeacher, myStudent);
            menu.Run();
        }
    }
}
