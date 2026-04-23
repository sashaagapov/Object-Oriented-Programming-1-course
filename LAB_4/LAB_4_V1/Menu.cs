namespace lab4agapov
{
    /// <summary>
    /// Клас Menu відповідає виключно за відображення меню та обробку вибору користувача.
    /// Відповідає принципу SRP: одна відповідальність — управління навігацією в меню.
    /// </summary>
    public class Menu
    {
        private readonly Service service;
        private Teacher myTeacher;
        private Student myStudent;
        private List<Student> students;
        private bool isStudentCreated;

        /// <summary>
        /// Ініціалізує меню з посиланнями на сервіс, наукову статтю та об'єкти даних.
        /// </summary>
        public Menu(Service service, Teacher myTeacher, Student myStudent, List<Student> students)
        {
            this.service = service;
            this.myTeacher = myTeacher;
            this.myStudent = myStudent;
            this.students = students;
            isStudentCreated = false;
        }

        /// <summary>
        /// Запускає головний цикл меню програми та обробляє вибір користувача.
        /// </summary>
        public void Run()
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.WriteLine("\n==========================================");
                Console.WriteLine("          ГОЛОВНЕ МЕНЮ ПРОГРАМИ           ");
                Console.WriteLine("==========================================");
                Console.WriteLine("1. Створити викладача (Акт 1)");
                Console.WriteLine("2. Оновити навантаження викладача (Акт 1)");
                Console.WriteLine("3. Ввести дані студента з консолі (Акт 2)");
                Console.WriteLine("4. Додати оцінки студенту (Акт 3)");
                Console.WriteLine("5. Вивести дані та зберегти у файл (Акт 4)");
                Console.WriteLine("6. Робота з дипломним проєктом (Акт 5)");
                Console.WriteLine("7. Пошук у науковій статті (Акт 6)");
                Console.WriteLine("0. Вихід");
                Console.WriteLine("------------------------------------------");
                Console.Write("Ваш вибір: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.WriteLine("\n--- Акт 1: Створення викладача ---");
                        myTeacher = service.ReadTeacherFromConsole();
                        service.PrintTeacherInfo(myTeacher);
                        service.SaveTeacherToFile(myTeacher, "teacher_data.txt");
                        service.ReadTeacherFromFile("teacher_data.txt");
                        break;

                    case "2":
                        if (myTeacher == null || string.IsNullOrEmpty(myTeacher.Name)) // Перевірка наявності викладача перед оновленням навантаження
                        {
                            Console.WriteLine("Помилка: Спочатку створіть викладача");
                            break;
                        }
                        Console.WriteLine("\n--- Акт 1: Оновлення навантаження викладача ---");
                        myTeacher.UpdateStudentCount(5);
                        Console.WriteLine($"Навантаження оновлено. Поточна кількість студентів: {myTeacher.QuantityOfStudents}");
                        service.PrintTeacherInfo(myTeacher);
                        service.SaveTeacherToFile(myTeacher, "teacher_data.txt");
                        service.ReadTeacherFromFile("teacher_data.txt");
                        break;

                    case "3":
                        Console.WriteLine("\n--- Акт 2: Створення студента ---");
                        myStudent = service.ReadStudentFromConsole();
                        students.Add(myStudent);
                        isStudentCreated = true;
                        Console.WriteLine($"Студента {myStudent.Name} успішно додано до бази. Всього студентів у базі: {students.Count}");
                        break;

                    case "4":
                        if (!isStudentCreated)
                        {
                            Console.WriteLine("Помилка: Спочатку створіть студента (пункт 3)!");
                            break;
                        }
                        Console.WriteLine("\n--- Акт 3: Додавання оцінок ---");
                        Console.Write("Введіть оцінку (від 0 до 100): ");
                        if (int.TryParse(Console.ReadLine(), out int grade))
                        {
                            myStudent.AddGrade(grade);
                            Console.WriteLine($"Оцінку {grade} успішно додано студенту {myStudent.Name}.");
                        }
                        else
                        {
                            Console.WriteLine("Помилка: введіть коректне число.");
                        }
                        break;

                    case "5":
                        if (!isStudentCreated)
                        {
                            Console.WriteLine("Помилка: Спочатку створіть студента (пункт 3)!");
                            break;
                        }
                        Console.WriteLine("\n--- Акт 4: Робота з даними (Service) ---");
                        service.PrintStudentInfo(myStudent);
                        string fileName = "student_data.txt";
                        service.SaveStudentToFile(myStudent, fileName);
                        service.ReadStudentFromFile(fileName);
                        break;

                    case "6":
                        if (!isStudentCreated)
                        {
                            Console.WriteLine("Помилка: Спочатку створіть студента (пункт 3)!");
                            break;
                        }
                        Console.WriteLine("\n--- Акт 5: Дипломний проєкт ---");
                        bool themeWasSelected = service.ChooseDiplomaTheme(myStudent);
                        if (themeWasSelected)
                        {
                            myStudent.Diploma.CalculateDifficulty();
                            myStudent.Diploma.AssignMark();
                            Console.WriteLine($"\nРезультат: {myStudent.Diploma.NameOfTheme}");
                            Console.WriteLine($"Підсумкова оцінка за диплом: {myStudent.Diploma.Mark} балів");
                        }
                        break;

                    case "7":
                        Console.WriteLine("\n--- Акт 6: Наукова стаття ---");
                        int[] references = [12, 34, 56, 78, 90];
                        int targetId = 56;
                        Console.WriteLine($"Пошук ID {targetId} у масиві...");
                        int foundIndex = ScientificPaper.SearchReference(references, targetId);
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
