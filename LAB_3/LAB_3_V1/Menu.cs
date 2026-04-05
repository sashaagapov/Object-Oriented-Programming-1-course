namespace lab3agapov_v1;

public class Menu
{
    private Service _service;
    private Teacher _teacher;
    private Student _student;
    private List<Student> _students;
    private bool _isStudentCreated;

    public Menu(Service service, Teacher teacher, Student student, List<Student> students)
    {
        _service = service;
        _teacher = teacher;
        _student = student;
        _students = students;
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
            Console.WriteLine("0. Вихід");
            Console.WriteLine("------------------------------------------");
            Console.Write("Ваш вибір: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.WriteLine("\n--- Акт 1: Викладач ---");
                    _teacher.UpdateStudentCount(5);
                    Console.WriteLine($"Навантаження оновлено. Поточна кількість студентів: {_teacher.QuantityOfStudents}");
                    _service.PrintTeacherInfo(_teacher);
                    _service.SaveTeacherToFile(_teacher, "teacher_data.txt");
                    break;

                case "2":
                    Console.WriteLine("\n--- Акт 2: Створення студента ---");
                    _student = _service.ReadStudentFromConsole();
                    _students.Add(_student);
                    _isStudentCreated = true;
                    Console.WriteLine($"Студента {_student.StudentName} успішно додано до бази. Всього студентів у базі: {_students.Count}");
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
                        _student.AddGrade(grade);
                        Console.WriteLine($"Оцінку {grade} успішно додано студенту {_student.StudentName}.");
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
                    _service.PrintStudentInfo(_student);
                    string fileName = "student_data.txt";
                    _service.SaveStudentToFile(_student, fileName);
                    _service.ReadStudentFromFile(fileName);
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
