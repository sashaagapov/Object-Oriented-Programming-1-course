using System;
using System.IO;

namespace Lab3;

public class Teacher
{
    public string Name { get; set; }
    public int Workload { get; set; }
    public string Discipline { get; set; }
    public int StudentCount { get; set; }

    public Teacher() 
    { 
        Name = ""; Workload = 0; Discipline = ""; StudentCount = 0; 
    }

    public Teacher(string name, int workload, string discipline, int studentCount)
    {
        Name = name; 
        Workload = workload; 
        Discipline = discipline; 
        StudentCount = studentCount;
    }

    public void InputFromConsole()
    {
        Console.Write("Введіть ім'я викладача: "); 
        Name = Console.ReadLine() ?? "";
        Console.Write("Введіть назву дисципліни: "); 
        Discipline = Console.ReadLine() ?? "";
        Console.Write("Введіть кількість студентів: ");
        if (int.TryParse(Console.ReadLine(), out int sc)) StudentCount = sc;
        Console.Write("Введіть обсяг навантаження (год): ");
        if (int.TryParse(Console.ReadLine(), out int wl)) Workload = wl;
    }

    public void PrintInfo()
    {
        Console.WriteLine($"Викладач: {Name}, Дисципліна: {Discipline}, Студентів: {StudentCount}, Навантаження: {Workload} год.");
    }

    public void SaveToFile(string filePath)
    {
        using (StreamWriter writer = new StreamWriter(filePath, true))
        {
            writer.WriteLine($"{Name} | Навантаження: {Workload} год. | Дисципліна: {Discipline} | Студентів: {StudentCount}");
        }
        Console.WriteLine("Дані викладача успішно збережено у файл.");
    }

    public void ChangeStudentCount(int delta)
    {
        StudentCount += delta;
        Workload += delta * 2; 
        Console.WriteLine($"Кількість студентів змінено. Нова кількість: {StudentCount}, нове навантаження: {Workload} год.");
    }
}