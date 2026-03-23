
/* * ДЕКЛАРАЦІЯ ПРО ВИКОРИСТАННЯ ШІ:

 * Штучний інтелект використовувався у цій лабораторній роботі виключно 

 * як навчальний асистент: для розбору логіки, дебагу та кращого розуміння матеріалу.

 */

using System;

namespace lab3agapov_v3
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
