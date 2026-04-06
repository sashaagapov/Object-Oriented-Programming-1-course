using System;
using System.Collections.Generic;

namespace lab3agapov_v2;

public class Menu
{
    private Service service;
    private Teacher teacher;
    private Student student;
    private List<Student> students;
    private bool isStudentCreated;

    public Menu(Service service, Teacher teacher, Student student, List<Student> students)
    {
        this.service = service;
        this.teacher = teacher;
        this.student = student;
        this.students = students;
        isStudentCreated = false;
    }

    public void Run()
    {
        bool isRunning = true;
        while (isRunning)
        {
            Console.WriteLine("\n==========================================");
            Console.WriteLine("          ГОЛОВНЕ МЕНЮ ПРОГРАМИ           ");
            Console.WriteLine("==========================================");
            Console.WriteLine("1. Ввести данні про викладача та оновити навантаження викладача (Акт 1)");
            Console.WriteLine("2. Ввести дані студента з консолі (Акт 2)");
            Console.WriteLine("3. Додати оцінки студенту (Акт 3)");
            Console.WriteLine("4. Вивести дані та зберегти у файл (Акт 4)");
            Console.WriteLine("5. Робота з дипломним проєктом (Акт 5)");
            Console.WriteLine("0. Вихід");
            Console.WriteLine("------------------------------------------");
            Console.Write("Ваш вибір: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.WriteLine("\n--- Акт 1: Викладач ---");
                    teacher = service.ReadTeacherFromConsole();
                    teacher.UpdateStudentCount(5);
                    Console.WriteLine($"Навантаження оновлено. Поточна кількість студентів: {teacher.QuantityOfStudents}");
                    service.PrintTeacherInfo(teacher);
                    service.SaveTeacherToFile(teacher, "teacher_data.txt");
                    service.ReadTeacherFromFile("teacher_data.txt");
                    break;

                case "2":
                    Console.WriteLine("\n--- Акт 2: Створення студента ---");
                    student = service.ReadStudentFromConsole();
                    students.Add(student);
                    isStudentCreated = true;
                    Console.WriteLine($"Студента {student.StudentName} успішно додано до бази. Всього студентів у базі: {students.Count}");
                    break;

                case "3":
                    if (!isStudentCreated)
                    {
                        Console.WriteLine("Помилка: Спочатку створіть студента (пункт 2)!");
                        break;
                    }
                    Console.WriteLine("\n--- Акт 3: Додавання оцінок ---");
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

                case "4":
                    if (!isStudentCreated)
                    {
                        Console.WriteLine("Помилка: Спочатку створіть студента (пункт 2)!");
                        break;
                    }
                    Console.WriteLine("\n--- Акт 4: Робота з даними (Service) ---");
                    service.PrintStudentInfo(student);
                    string fileName = "student_data.txt";
                    service.SaveStudentToFile(student, fileName);
                    service.ReadStudentFromFile(fileName);
                    break;

                case "5":
                    if (!isStudentCreated)
                    {
                        Console.WriteLine("Помилка: Спочатку створіть студента (пункт 2)!");
                        break;
                    }
                    Console.WriteLine("\n--- Акт 5: Дипломний проєкт ---");
                    service.ChooseDiplomaTheme(student);
                    student.Diploma.CalculateDifficulty();
                    student.Diploma.AssignMark();
                    Console.WriteLine($"\nРезультат: {student.Diploma.NameOfTheme}");
                    Console.WriteLine($"Підсумкова оцінка за диплом: {student.Diploma.Mark} балів");
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
