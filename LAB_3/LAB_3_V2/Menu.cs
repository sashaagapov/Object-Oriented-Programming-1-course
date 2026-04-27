using System;
using System.Collections.Generic;

namespace lab3agapov_v2;

/// <summary>
/// Клас Menu відповідає виключно за відображення меню та обробку вибору користувача.
/// Відповідає принципу SRP: одна відповідальність — управління навігацією в меню.
/// </summary>
public class Menu
{
    private Service service;
    private Teacher teacher;
    private Student student;
    private List<Student> students;
    private bool isStudentCreated;

    /// <summary>
    /// Ініціалізує меню з посиланнями на сервіс та об'єкти даних.
    /// </summary>
    public Menu(Service service, Teacher teacher, Student student, List<Student> students)
    {
        this.service = service;
        this.teacher = teacher;
        this.student = student;
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
            Console.WriteLine("1. Створити викладача");
            Console.WriteLine("2. Оновити навантаження викладача");
            Console.WriteLine("3. Ввести дані студента з консолі");
            Console.WriteLine("4. Додати оцінки студенту");
            Console.WriteLine("5. Вивести дані та зберегти у файл");
            Console.WriteLine("6. Робота з дипломним проєктом");
            Console.WriteLine("0. Вихід");
            Console.WriteLine("------------------------------------------");
            Console.Write("Ваш вибір: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.WriteLine("\n--- Пункт 1: Створення викладача ---");
                    teacher = service.ReadTeacherFromConsole();
                    service.PrintTeacherInfo(teacher);
                    service.SaveTeacherToFile(teacher, "teacher_data.txt");
                    service.ReadTeacherFromFile("teacher_data.txt");
                    break;

                case "2":
                    if (teacher == null || string.IsNullOrEmpty(teacher.TeacherName)) // Перевірка наявності викладача перед оновленням навантаження
                    {
                        Console.WriteLine("Помилка: Спочатку створіть викладача");
                        break;
                    }
                    Console.WriteLine("\n--- Пункт 2: Оновлення навантаження викладача ---");
                    teacher.UpdateStudentCount(5);
                    Console.WriteLine($"Навантаження оновлено. Поточна кількість студентів: {teacher.QuantityOfStudents}");
                    service.PrintTeacherInfo(teacher);
                    service.SaveTeacherToFile(teacher, "teacher_data.txt");
                    service.ReadTeacherFromFile("teacher_data.txt");
                    break;

                case "3":
                    Console.WriteLine("\n--- Пункт 3: Створення студента ---");
                    student = service.ReadStudentFromConsole();
                    students.Add(student);
                    isStudentCreated = true;
                    Console.WriteLine($"Студента {student.StudentName} успішно додано до бази. Всього студентів у базі: {students.Count}");
                    break;

                case "4":
                    if (!isStudentCreated)
                    {
                        Console.WriteLine("Помилка: Спочатку створіть студента (пункт 3)!");
                        break;
                    }
                    Console.WriteLine("\n--- Пункт 4: Додавання оцінок студенту ---");
                    Console.Write("Введіть оцінку (від 0 до 100): ");
                    if (int.TryParse(Console.ReadLine(), out int grade) && grade >= 0 && grade <= 100)
                    {
                        student.AddGrade(grade);
                        Console.WriteLine($"Оцінку {grade} успішно додано студенту {student.StudentName}.");
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
                    Console.WriteLine("\n--- Пункт 5: Виведення та збереження даних ---");
                    service.PrintStudentInfo(student);
                    string fileName = "student_data.txt";
                    service.SaveStudentToFile(student, fileName);
                    service.ReadStudentFromFile(fileName);
                    break;

                case "6":
                    if (!isStudentCreated)
                    {
                        Console.WriteLine("Помилка: Спочатку створіть студента (пункт 3)!");
                        break;
                    }
                    Console.WriteLine("\n--- Пункт 6: Робота з дипломним проєктом ---");
                    bool success = service.ChooseDiplomaTheme(student); // Результат зберігається для умовної обробки після вибору теми
                    if (success)
                    {
                        student.Diploma.CalculateDifficulty();
                        student.Diploma.AssignMark();
                        Console.WriteLine($"\nРезультат: {student.Diploma.NameOfTheme}");
                        Console.WriteLine($"Підсумкова оцінка за диплом: {student.Diploma.Mark} балів");
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
