using System;
using System.IO;
using System.Linq;

namespace Lab3;

public partial class Student
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Address { get; set; }
    public string Passport { get; set; }
    public int Age { get; set; }
    public string Telephone { get; set; }
    public double Rating { get; private set; }

    public Student()
    {
        FirstName = ""; LastName = ""; Address = ""; Passport = ""; 
        Age = 0; Telephone = ""; Rating = 0.0;
    }

    public Student(string firstName, string lastName, string address, string passport, int age, string telephone)
    {
        FirstName = firstName; LastName = lastName; 
        Address = address; Passport = passport;
        Age = age; Telephone = telephone; Rating = 0.0;
    }

    public void InputFromConsole()
    {
        Console.Write("Введіть ім'я: "); FirstName = Console.ReadLine() ?? "";
        Console.Write("Введіть прізвище: "); LastName = Console.ReadLine() ?? "";
        Console.Write("Введіть адресу: "); Address = Console.ReadLine() ?? "";
        Console.Write("Введіть паспорт: "); Passport = Console.ReadLine() ?? "";
        Console.Write("Введіть телефон: "); Telephone = Console.ReadLine() ?? "";
        Console.Write("Введіть вік: ");
        if (int.TryParse(Console.ReadLine(), out int a)) Age = a;
    }

    public void PrintInfo()
    {
        Console.WriteLine($"Студент: {FirstName} {LastName}, Вік: {Age}, Паспорт: {Passport}, Адреса: {Address}, Тел: {Telephone}, Рейтинг: {Rating:F2}");
    }

    public void CalculateRating()
    {
        Console.WriteLine("Введіть 3 оцінки (кожна з нового рядка):");
        double sum = 0;
        for (int i = 0; i < 3; i++)
        {
            if (double.TryParse(Console.ReadLine(), out double grade)) sum += grade;
        }
        Rating = Math.Round(sum / 3, 2); 
        Console.WriteLine($"Розрахований рейтинг: {Rating}");
    }

    public void SaveToFile(string filePath)
    {
        using (StreamWriter writer = new StreamWriter(filePath, true))
        {
            writer.WriteLine($"{FirstName} {LastName} | Рейтинг: {Rating}");
        }
        Console.WriteLine("Дані студента збережено у файл.");
    }

    public partial class DiplomaProject
    {
        public string Topic { get; set; } = string.Empty;
        public int AlgorithmsCount { get; set; }
        public int ComplexityLevel { get; set; }

        public void SelectTopic(string filePath)
        {
            Console.Write("Введіть ключове слово для пошуку теми: ");
            string? keyword = Console.ReadLine();

            if (!string.IsNullOrEmpty(keyword) && File.Exists(filePath))
            {
                var foundTopic = File.ReadLines(filePath)
                                     .FirstOrDefault(line => line.Contains(keyword, StringComparison.OrdinalIgnoreCase));
                
                if (foundTopic != null)
                {
                    Console.WriteLine($"Знайдена тема: {foundTopic}");
                    Topic = foundTopic;
                    return;
                }
            }
            Console.WriteLine("Тему не знайдено.");
        }
    }
}