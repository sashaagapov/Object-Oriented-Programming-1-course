
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
            Service service = new Service();// Створюємо екземпляр сервісного класу для виклику його методів
            ScientificPaper scientificPaper = new ScientificPaper(); // Створюємо екземпляр класу для роботи з науковою статтею
            service.WelcomeInfo();
            bool isRunning = true;

            // Ініціалізуємо об'єкти на старті програми
            StudentGroup group = new StudentGroup();
            Teacher myTeacher = new Teacher();
            Student myStudent = new Student(); // Повертаємо змінну поточного студента
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
                Console.WriteLine("7. Перебір студентів через foreach (Версія 4)");
                Console.WriteLine("8. Відсортувати студентів (Акт 8)");
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
                        group.AddStudent(myStudent);
                        isStudentCreated = true;
                        Console.WriteLine($"Студента {myStudent.Name} успішно додано до бази.");
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
                    case "7":
                        Console.WriteLine("\n--- Акт 7: Перебір студентів (Версія 4) ---");
                        // Цей foreach працює саме завдяки тим інтерфейсам, які щойно написали
                        foreach (Student s in group)
                        {
                            Console.WriteLine($"Студент: {s.Name}, Предмет: {s.SubjectName}");
                        }
                        break;

                    case "8":
                        Console.WriteLine("\n--- Акт 8: Сортування студентів за рейтингом (Версія 4) ---");
                        group.SortStudents(); // Сортуємо шафу
                        
                        // Виводимо вже відсортований список
                        foreach (Student s in group)
                        {
                            Console.WriteLine($"Студент: {s.Name}, Рейтинг: {s.CalculateRating()}");
                        }
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

