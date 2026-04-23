
/* * ДЕКЛАРАЦІЯ ПРО ВИКОРИСТАННЯ ШІ:

 * Штучний інтелект використовувався у цій лабораторній роботі виключно

 * як навчальний асистент: для розбору логіки, дебагу та кращого розуміння матеріалу.

 */
/* * Версія 2.0
 * * ЕТАПИ ЗАВДАННЯ (Версія 2):
 * 1. Модифікація класу Person: перетворення базового класу на абстрактний (abstract).
 * 2. Перевірка обмежень: підтвердження неможливості створення екземплярів класу Person.
 * 3. Успадкування: збереження можливості використання Person як базового типу для Student та Teacher.
 * 4. Дотримання принципів SOLID: реалізація принципів OCP (відкритості/закритості) та LSP (підстановки Лісков).
 * - Використання ключового слова abstract для запобігання нерелевантній ініціалізації базового класу.
 * - Демонстрація роботи з об'єктами через посилання на базовий абстрактний клас.
 */

namespace lab4agapov
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Service service = new Service(); // Person testPerson = new Person(); // Помилка компіляції: неможливо створити екземпляр абстрактного класу Person
            service.WelcomeInfo();

            Teacher myTeacher = new Teacher();
            Student myStudent = new Student();
            List<Student> students = new List<Student>();

            Menu menu = new Menu(service, myTeacher, myStudent, students);
            menu.Run();
        }
    }
}
