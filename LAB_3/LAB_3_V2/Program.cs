
/* * ДЕКЛАРАЦІЯ ПРО ВИКОРИСТАННЯ ШІ:

 * Штучний інтелект використовувався у цій лабораторній роботі виключно 

 * як навчальний асистент: для розбору логіки, дебагу та кращого розуміння матеріалу.

 */
/* * Версія 2.0 
 * Лабораторна робота №3 з курсу "Об'єктно-орієнтоване програмування 1"
 * Виконав: Агапов Олександр | Група: ІПЗ-11(1) | Варіант: 1
 * ЕТАПИ ЗАВДАННЯ (Версія 2 = Версія 1 + п.7):
 * 1. Усі класи з Версії 1.
 * 2. Додано вкладений клас DiplomaProject у клас Student.
 * 3. Вибір теми диплому з текстового файлу за ключовим словом.
 * 4. Обчислення складності алгоритмів та автоматичне виставлення оцінки.
 */


namespace lab3agapov_v2
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
