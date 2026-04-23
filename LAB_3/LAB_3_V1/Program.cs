/* * ДЕКЛАРАЦІЯ ПРО ВИКОРИСТАННЯ ШІ:

 * Штучний інтелект використовувався у цій лабораторній роботі виключно 

 * як навчальний асистент: для розбору логіки, дебагу та кращого розуміння матеріалу.

 */
/* * Версія 1.0 
 * Лабораторна робота №3 з курсу "Об'єктно-орієнтоване програмування 1"
 * Виконав: Агапов Олександр | Група: ІПЗ-11(1) | Варіант: 1
 * ЕТАПИ ЗАВДАННЯ (Версія 1):
 * 1. Створення базових класів Teacher та Student з інкапсуляцією даних.
 * 2. Реалізація консольного меню (Menu) та сервісного класу (Service).
 * 3. Додавання методів для зміни навантаження викладача та розрахунку рейтингу студента.
 */



namespace lab3agapov_v1
{

    class Program
    {
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

