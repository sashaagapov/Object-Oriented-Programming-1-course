namespace lab4agapov
{
    /// <summary>
    /// Клас Menu відповідає виключно за відображення меню та обробку вибору користувача.
    /// Відповідає принципу SRP: одна відповідальність — управління навігацією в меню.
    /// </summary>
    public class Menu
    {
        private readonly Service _service;
        private readonly ScientificPaper _scientificPaper;
        private readonly StudentGroup _group;
        private Teacher _myTeacher;
        private Student _myStudent;
        private bool _isStudentCreated;

        public Menu(Service service, ScientificPaper scientificPaper, StudentGroup group, Teacher myTeacher, Student myStudent)
        {
            _service = service;
            _scientificPaper = scientificPaper;
            _group = group;
            _myTeacher = myTeacher;
            _myStudent = myStudent;
            _isStudentCreated = false;
        }

        public void Run()
        {
            bool isRunning = true;
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
                Console.WriteLine("8. Відсортувати студентів за рейтингом (Акт 8)");
                Console.WriteLine("9. Відсортувати студентів за обсягом робіт");
                Console.WriteLine("0. Вихід");
                Console.WriteLine("------------------------------------------");
                Console.Write("Ваш вибір: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.WriteLine("\n--- Акт 1: Викладач ---");
                        _myTeacher.UpdateStudentCount(5);
                        Console.WriteLine($"Навантаження оновлено. Поточна кількість студентів: {_myTeacher.QuantityOfStudents}");
                        break;

                    case "2":
                        Console.WriteLine("\n--- Акт 2: Створення студента ---");
                        _myStudent = _service.ReadStudentFromConsole();
                        _group.AddStudent(_myStudent);
                        _isStudentCreated = true;
                        Console.WriteLine($"Студента {_myStudent.Name} успішно додано до бази.");
                        break;

                    case "3":
                        if (!_isStudentCreated)
                        {
                            Console.WriteLine("Помилка: Спочатку створіть студента (пункт 2)!");
                            break;
                        }
                        Console.WriteLine("\n--- Акт 3: Додавання оцінок ---");
                        Console.Write("Введіть оцінку (від 0 до 100): ");
                        if (int.TryParse(Console.ReadLine(), out int grade))
                        {
                            _myStudent.AddGrade(grade);
                            Console.WriteLine($"Оцінку {grade} успішно додано студенту {_myStudent.Name}.");
                        }
                        else
                        {
                            Console.WriteLine("Помилка: введіть коректне число.");
                        }
                        break;

                    case "4":
                        if (!_isStudentCreated)
                        {
                            Console.WriteLine("Помилка: Спочатку створіть студента (пункт 2)!");
                            break;
                        }
                        Console.WriteLine("\n--- Акт 4: Робота з даними (Service) ---");
                        _service.PrintStudentInfo(_myStudent);
                        string fileName = "student_data.txt";
                        _service.SaveStudentToFile(_myStudent, fileName);
                        _service.ReadStudentFromFile(fileName);
                        break;

                    case "5":
                        if (!_isStudentCreated)
                        {
                            Console.WriteLine("Помилка: Спочатку створіть студента (пункт 2)!");
                            break;
                        }
                        Console.WriteLine("\n--- Акт 5: Дипломний проєкт ---");
                        _service.ChooseDiplomaTheme(_myStudent);
                        _myStudent.Diploma.CalculateDifficulty();
                        _myStudent.Diploma.AssignMark();
                        Console.WriteLine($"\nРезультат: {_myStudent.Diploma.NameOfTheme}");
                        Console.WriteLine($"Підсумкова оцінка за диплом: {_myStudent.Diploma.Mark} балів");
                        break;

                    case "6":
                        Console.WriteLine("\n--- Акт 6: Наукова стаття ---");
                        int[] references = { 12, 34, 56, 78, 90 };
                        int targetId = 56;
                        Console.WriteLine($"Пошук ID {targetId} у масиві...");
                        int foundIndex = _scientificPaper.SearchReference(references, targetId);
                        if (foundIndex != -1)
                            Console.WriteLine($"ID знайдено. Позиція в списку: {foundIndex}");
                        else
                            Console.WriteLine("ID в списку літератури не знайдено.");
                        break;

                    case "7":
                        Console.WriteLine("\n--- Акт 7: Перебір студентів (Версія 4) ---");
                        foreach (Student s in _group)
                        {
                            Console.WriteLine($"Студент: {s.Name}, Предмет: {s.SubjectName}");
                        }
                        break;

                    case "8":
                        Console.WriteLine("\n--- Акт 8: Сортування студентів за рейтингом (Версія 4) ---");
                        _group.SortStudents();
                        foreach (Student s in _group)
                        {
                            Console.WriteLine($"Студент: {s.Name}, Рейтинг: {s.CalculateRating()}");
                        }
                        break;

                    case "9":
                        Console.WriteLine("\n--- Акт 9: Сортування студентів за обсягом робіт (Версія 4) ---");
                        _group.SortByTasks();
                        foreach (Student s in _group)
                        {
                            Console.WriteLine($"Студент: {s.Name}, Кількість завдань: {s.TasksDone}");
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
