/* * Версія 3.0
 * Лабораторна робота №3 з курсу "Об'єктно-орієнтоване програмування 1"
 * Виконав: Агапов Олександр | Група: ІПЗ-11(1) | Варіант: 1
 * * ЕТАПИ ЗАВДАННЯ:
 * 1. Клас Teacher: зберігання інформації про викладача та зміна його навантаження.
 * 2. Клас Student: зберігання даних студента, додавання оцінок, розрахунок рейтингу.
 * 3. Статичний клас Service: реалізація вводу/виводу даних на консоль та роботи з файлами.
 * 4. Вкладений клас DiplomaProject (Версія 2): вибір теми з файлу, обчислення складності 
 * алгоритмів та автоматичне виставлення оцінки.
 * 5. Часткові класи (Версія 3): використання модифікатора partial для розділення 
 * класу Student та його вкладеного класу на кілька фізичних файлів.
 * * ОСНОВНІ ВИМОГИ:
 * - Інкапсуляція даних (приватні поля + публічні властивості).
 * - Наявність конструкторів (за замовчуванням, з параметрами, копіювання).
 * - Перевірка вводу (захист від некоректних даних користувача).
 */
using System;

namespace lab3agapov;

class Program
{
    static void Main(string[] args)
    {

        // --- 1. Робота з класом Teacher ---
        Console.WriteLine("\n--- Акт 1: Викладач ---");
        // Створюємо викладача (використовуючи конструктор за замовчуванням або з параметрами)
        Teacher myTeacher = new Teacher();

        // Викликаємо метод для зміни кількості студентів та годин
        Console.WriteLine("Оновлюємо навантаження викладача (додаємо 5 студентів)...");
        myTeacher.UpdateStudentCount(5);
        Console.WriteLine("Навантаження успішно оновлено.");


        // --- 2. Робота з класом Student через Service ---
        Console.WriteLine("\n--- Акт 2: Створення студента ---");
        // Створюємо студента, зчитуючи дані з консолі
        Student myStudent = Service.ReadStudentFromConsole();


        // --- 3. Додавання оцінок студенту ---
        Console.WriteLine("\n--- Акт 3: Додавання оцінок ---");
        myStudent.AddGrade(90);
        myStudent.AddGrade(85);
        myStudent.AddGrade(95);
        Console.WriteLine("Студенту додано 3 оцінки (90, 85, 95).");


        // --- 4. Використання методів Service (Вивід, Запис, Читання) ---
        Console.WriteLine("\n--- Акт 4: Робота з даними (Service) ---");

        // Виводимо інформацію на екран
        Service.PrintStudentInfo(myStudent);

        // Зберігаємо у файл
        string fileName = "student_data.txt";
        Service.SaveStudentToFile(myStudent, fileName);

        // Читаємо з файлу
        Service.ReadStudentFromFile(fileName);

        Console.WriteLine("\n--- Акт 5: Дипломний проєкт ---");
        myStudent.Diploma.ChooseTheme();
        myStudent.Diploma.CalculateDifficulty();
        myStudent.Diploma.AssignMark();
        Console.WriteLine($"Підсумкова оцінка за диплом: {myStudent.Diploma.Mark} балів");

        Console.ReadLine(); // Щоб консоль не закрилася миттєво
    }
}