/* * Версія 5.0 
 * Лабораторна робота №3 з курсу "Об'єктно-орієнтоване програмування 1"
 * Виконав: Агапов Олександр | Група: ІПЗ-11(1) | Варіант: 1
 * * ЕТАПИ ЗАВДАННЯ:
 * 1. Клас Teacher: зберігання інформації про викладача та зміна його навантаження.
 * 2. Клас Student: зберігання даних студента, додавання оцінок, розрахунок рейтингу.
 * 3. Клас Service: реалізація вводу/виводу даних на консоль та роботи з файлами (робота через екземпляри об'єктів).
 * 4. Вкладений клас DiplomaProject (Версія 2): вибір теми з текстового файлу, обчислення складності 
 * алгоритмів та автоматичне виставлення оцінки.
 * 5. Часткові класи (Версія 3): використання модифікатора partial для розділення 
 * класу Student та його вкладеного класу на кілька фізичних файлів.
 * 6. Клас ScientificPaper (Версія 4): бінарний пошук ідентифікатора джерела.
 * * ОСНОВНІ ВИМОГИ:
 * - Інкапсуляція даних (приватні поля + публічні властивості).
 * - Наявність конструкторів (за замовчуванням, з параметрами, копіювання).
 * - Перевірка вводу (захист від некоректних даних користувача).
 * - Дотримання принципу єдиної відповідальності (SRP).
 */
using System;

namespace lab3agapov
{

    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Service service = new Service();// Створюємо екземпляр сервісного класу для виклику його методів
            ScientificPaper scientificPaper = new ScientificPaper(); // Створюємо екземпляр класу для роботи з науковою статтею
            service.WelcomeInfo();
            bool isRunning = true;

            // Ініціалізуємо об'єкти на старті програми
            // Ініціалізуємо об'єкти на старті програми
            Teacher myTeacher = new Teacher();
            Student myStudent = new Student(); // Повертаємо змінну поточного студента
            List<Student> students = new List<Student>(); // ДОДАЄМО НАШ СПИСОК (БАЗУ ДАНИХ)
            bool isStudentCreated = false;     // Повертаємо прапорець
            while (isRunning)
            {
                Console.WriteLine("\n==========================================");
                Console.WriteLine("          ГОЛОВНЕ МЕНЮ ПРОГРАМИ           ");
                Console.WriteLine("==========================================");
                Console.WriteLine("1. Оновити навантаження викладача (Акт 1)");
                Console.WriteLine("2. Ввести дані студента з консолі (Акт 2)");
                Console.WriteLine("3. Додати оцінки студенту (Акт 3)");
                Console.WriteLine("4. Вивести дані та зберегти у файл (Акт 4)");
                Console.WriteLine("5. Робота з дипломним проєктом (Акт 5)");
                Console.WriteLine("6. Пошук у науковій статті (Акт 6)");
                Console.WriteLine("0. Вихід");
                Console.WriteLine("------------------------------------------");
                Console.Write("Ваш вибір: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.WriteLine("\n--- Акт 1: Викладач ---");
                        myTeacher.UpdateStudentCount(5);
                        Console.WriteLine($"Навантаження оновлено. Поточна кількість студентів: {myTeacher.QuantityOfStudents}");
                        break;

                    case "2":
                        Console.WriteLine("\n--- Акт 2: Створення студента ---");
                        myStudent = service.ReadStudentFromConsole(); // Створюємо
                        students.Add(myStudent); // ВИПРАВЛЕНО НА students
                        isStudentCreated = true;
                        Console.WriteLine($"Студента {myStudent.StudentName} успішно додано до бази. Всього студентів у базі: {students.Count}"); // ВИПРАВЛЕНО НА students
                        break;

                    case "3":
                        if (!isStudentCreated)
                        {
                            Console.WriteLine("Помилка: Спочатку створіть студента (пункт 2)!");
                            break;
                        }
                        Console.WriteLine("\n--- Акт 3: Додавання оцінок ---");
                        myStudent.AddGrade(90);
                        myStudent.AddGrade(85);
                        myStudent.AddGrade(95);
                        Console.WriteLine("Додано тестові оцінки: 90, 85, 95.");
                        break;

                    case "4":
                        if (!isStudentCreated)
                        {
                            Console.WriteLine("Помилка: Спочатку створіть студента (пункт 2)!");
                            break;
                        }
                        Console.WriteLine("\n--- Акт 4: Робота з даними (Service) ---");
                        service.PrintStudentInfo(myStudent);
                        string fileName = "student_data.txt";
                        service.SaveStudentToFile(myStudent, fileName);
                        service.ReadStudentFromFile(fileName);
                        break;

                    case "5":
                        if (!isStudentCreated)
                        {
                            Console.WriteLine("Помилка: Спочатку створіть студента (пункт 2)!");
                            break;
                        }
                        Console.WriteLine("\n--- Акт 5: Дипломний проєкт ---");
                        // Використовуємо новий сервісний метод для вибору теми
                        service.ChooseDiplomaTheme(myStudent);

                        // Обчислюємо складність та виставляємо оцінку
                        myStudent.Diploma.CalculateDifficulty();
                        myStudent.Diploma.AssignMark();

                        Console.WriteLine($"\nРезультат: {myStudent.Diploma.NameOfTheme}");
                        Console.WriteLine($"Підсумкова оцінка за диплом: {myStudent.Diploma.Mark} балів");
                        break;

                    case "6":
                        Console.WriteLine("\n--- Акт 6: Наукова стаття (Версія 4) ---");
                        int[] references = { 12, 34, 56, 78, 90 };
                        int targetId = 56;
                        Console.WriteLine($"Пошук ID {targetId} у масиві...");

                        int foundIndex = scientificPaper.SearchReference(references, targetId);
                        if (foundIndex != -1)
                            Console.WriteLine($"ID знайдено. Позиція в списку: {foundIndex}");
                        else
                            Console.WriteLine("ID в списку літератури не знайдено.");
                        break;

                    case "0":
                        Console.WriteLine("Завершення роботи.");
                        isRunning = false;
                        break;

                    default:
                        Console.WriteLine("Некоректний вибір. Спробуйте ще раз.");
                        break;
                }
            }
        }
    }
}