
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
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Service service = new Service();
            ScientificPaper scientificPaper = new ScientificPaper();
            service.WelcomeInfo();
            StudentGroup group = new StudentGroup();
            Teacher myTeacher = new Teacher();
            Student myStudent = new Student();
            service.LoadStudentFromFile(group,"student_data.txt");
            Menu menu = new Menu(service, scientificPaper, group, myTeacher, myStudent);
            menu.Run();
        }
    }
}
