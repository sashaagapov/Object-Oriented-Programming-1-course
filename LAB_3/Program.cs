using System;
using System.IO;

namespace Lab3;

public static class Program
{
    private static readonly string teacherFile = "teachers.txt";
    private static readonly string studentFile = "students.txt";
    private static readonly string topicsFile = "topics.txt";

    public static void Main()
    {
        EnsureTopicsFileExists();

        Teacher currentTeacher = new Teacher("Олександр Петрович", 120, "Програмування", 30);
        Student currentStudent = new Student();
        Student.DiplomaProject currentDiploma = new Student.DiplomaProject();

        bool isRunning = true;
        while (isRunning)
        {
            ShowMenu();
            string? choice = Console.ReadLine();
            Console.WriteLine();
            isRunning = ProcessChoice(choice, currentTeacher, currentStudent, currentDiploma);
        }
    }

    private static void EnsureTopicsFileExists()
    {
        if (!File.Exists(topicsFile))
        {
            File.WriteAllLines(topicsFile, new string[] { 
                "Штучний інтелект в іграх", 
                "Веб-додаток для деканату", 
                "Аналіз даних алгоритмами машинного навчання" 
            });
        }
    }

    private static void ShowMenu()
    {
        Console.WriteLine();
        CreativeWork.PrintHeader();
        Console.WriteLine("1. Перевизначити викладача (ввести нові дані)");
        Console.WriteLine("2. Змінити кількість студентів у викладача");
        Console.WriteLine("3. Зберегти дані викладача у файл");
        Console.WriteLine("4. Ввести дані нового студента");
        Console.WriteLine("5. Розрахувати рейтинг студента");
        Console.WriteLine("6. Зберегти дані студента у файл");
        Console.WriteLine("7. Пошук теми дипломної та розрахунок оцінки");
        Console.WriteLine("8. Викликати статичні методи (тест Лаб 2)");
        Console.WriteLine("0. Вийти з програми");
        Console.Write("Ваш вибір: ");
    }

    private static bool ProcessChoice(string? choice, Teacher teacher, Student student, Student.DiplomaProject diploma)
    {
        switch (choice)
        {
            case "1": 
                teacher.InputFromConsole(); 
                teacher.PrintInfo(); 
                break;
            case "2": 
                HandleTeacherStudentCount(teacher); 
                break;
            case "3": 
                teacher.SaveToFile(teacherFile); 
                break;
            case "4": 
                student.InputFromConsole(); 
                student.PrintInfo(); 
                break;
            case "5": 
                student.CalculateRating(); 
                break;
            case "6": 
                student.SaveToFile(studentFile); 
                break;
            case "7": 
                HandleDiploma(diploma); 
                break;
            case "8": 
                HandleCreativeWork(); 
                break;
            case "0": 
                Console.WriteLine("Завершення роботи програми."); 
                return false;
            default: 
                Console.WriteLine("Невірний вибір. Спробуйте ще раз."); 
                break;
        }
        return true;
    }

    private static void HandleTeacherStudentCount(Teacher teacher)
    {
        Console.Write("Введіть зміну кількості студентів (наприклад 5 або -3): ");
        if (int.TryParse(Console.ReadLine(), out int delta))
            teacher.ChangeStudentCount(delta);
    }

    private static void HandleDiploma(Student.DiplomaProject diploma)
    {
        diploma.SelectTopic(topicsFile);
        Console.Write("Введіть кількість реалізованих алгоритмів: ");
        if (int.TryParse(Console.ReadLine(), out int algs)) diploma.AlgorithmsCount = algs;
        Console.Write("Введіть рівень складності (1-легко, 2-середньо, 3-складно): ");
        if (int.TryParse(Console.ReadLine(), out int comp)) diploma.ComplexityLevel = comp;
        diploma.CalculateGrade();
    }

    private static void HandleCreativeWork()
    {
        Console.WriteLine("--- Демонстрація методів з Лаб 2 (CreativeWork) ---");
        int[] testArray = { 15, 3, 9, 8, 22, 1, 7 };
        Console.WriteLine($"Початковий масив: {string.Join(", ", testArray)}");

        CreativeWork.QuickSortDescending(testArray, 0, testArray.Length - 1);
        Console.WriteLine($"Відсортований за спаданням: {string.Join(", ", testArray)}");

        Console.Write("Введіть число для бінарного пошуку в масиві: ");
        if (int.TryParse(Console.ReadLine(), out int target))
        {
            int index = CreativeWork.BinarySearchDescending(testArray, target);
            if (index != -1) Console.WriteLine($"Знайдено на індексі: {index}");
            else Console.WriteLine("Не знайдено.");
        }

        Console.Write("Введіть межу для решета Ератосфена (наприклад 30): ");
        if (int.TryParse(Console.ReadLine(), out int limit) && limit >= 2)
        {
            var primes = CreativeWork.SieveOfEratosthenes(limit);
            Console.WriteLine($"Прості числа до {limit}: {string.Join(", ", primes)}");
        }
    }
}