
/* * ДЕКЛАРАЦІЯ ПРО ВИКОРИСТАННЯ ШІ:

 * Штучний інтелект використовувався у цій лабораторній роботі виключно 

 * як навчальний асистент: для розбору логіки, дебагу та кращого розуміння матеріалу.

 */
/* * Версія 3.0 
* Лабораторна робота №3 з курсу "Об'єктно-орієнтоване програмування 1"
* Виконав: Агапов Олександр | Група: ІПЗ-11(1) | Варіант: 1
* ЕТАПИ ЗАВДАННЯ (Версія 3 = Версія 2 + п.8):
* 1. Усі класи з Версії 2.
* 2. Клас Student розділено на часткові класи (partial) у окремих файлах.
* 3. Метод SelectTheme перенесено до часткового класу Student (SRP).
* 4. Метод CalculateDifficulty та AssignMark у окремому частковому файлі DiplomaProject.
*/


namespace lab3agapov_v3
{

    /// <summary>
    /// Клас Program є точкою входу в консольний застосунок версії LAB_3_V3.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Головний метод програми. Створює основні об'єкти та запускає головне меню.
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
