using System;
using System.IO;
using System.Collections.Generic;

namespace lab3agapov;
/// <summary>
/// Сервісний клас Service, який містить статичні методи для роботи з об'єктами класу Student, включаючи читання та запис даних у файл, а також виведення інформації про студента на консоль.
/// </summary>
public static class Service
{
    /// <summary>
    /// Метод ReadStudentFromConsole, який зчитує інформацію про студента з консолі, включаючи його ім'я та назву предмету, і повертає об'єкт класу Student з цією інформацією. Цей метод використовується для створення нового студента на основі введених користувачем даних.
    /// </summary>
    /// <returns></returns>
    public static Student ReadStudentFromConsole()
    {
        Console.WriteLine("Введіть ім'я студента:");
        string name = Console.ReadLine();
        
        Console.WriteLine("Введіть назву предмета:");
        string subject = Console.ReadLine();
        return new Student(name, subject, new List<int>(), 0);
    }
    /// <summary>
    /// Метод PrintStudentInfo, який приймає об'єкт класу Student і виводить його інформацію на консоль у форматі: "Ім'я студента: [ім'я]. Назва предмету: [назва предмету]. Його поточний рейтинг: [рейтинг]". Цей метод використовується для відображення інформації про студента, включаючи його ім'я, назву предмету та поточний рейтинг, який обчислюється на основі його оцінок та кількості виконаних завдань.
    /// </summary>
    /// <param name="student"></param>
    public static void PrintStudentInfo(Student student)
    {
        Console.WriteLine($"Ім'я студента: {student.StudentName}. Назва предмету: {student.SubjectName}. Його поточний рейтинг: {student.CalculateRating()}");
    }
    /// <summary>
    /// Метод SaveStudentToFile, який приймає об'єкт класу Student та ім'я файлу, і зберігає інформацію про студента у вказаний файл у форматі: "Ім'я студента;Назва предмету;Рейтинг". Цей метод використовується для збереження даних студента у текстовому файлі, що дозволяє зберігати інформацію про студентів для подальшого використання або аналізу.
    /// </summary>
    /// <param name="student"></param>
    /// <param name="fileName"></param>
    public static void SaveStudentToFile(Student student, string fileName)
    {
        string data = $"{student.StudentName};{student.SubjectName};{student.CalculateRating()}";
        File.WriteAllText(fileName, data);
        Console.WriteLine($"\nДані студента збережено у файл: {fileName}");
    }
    /// <summary>
    /// Метод ReadStudentFromFile, який приймає ім'я файлу, зчитує інформацію про студента з цього файлу та виводить її на консоль у форматі: "Ім'я: [ім'я]. Предмет: [назва предмету]. Рейтинг: [рейтинг]". Цей метод використовується для читання даних студента з текстового файлу та відображення цієї інформації на консоль для користувача.
    /// </summary>
    /// <param name="fileName"></param>
    public static void ReadStudentFromFile(string fileName)
    {
        if (File.Exists(fileName))
        {
            string content = File.ReadAllText(fileName);
            string[] parts = content.Split(';');

            Console.WriteLine("\n--- Дані з файлу ---");
            Console.WriteLine($"Ім'я: {parts[0]}");
            Console.WriteLine($"Предмет: {parts[1]}");
            Console.WriteLine($"Рейтинг: {parts[2]}");
        }
        else
        {
            Console.WriteLine("Файл не знайдено!");
        }
    }
}