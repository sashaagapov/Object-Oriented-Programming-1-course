using System;
using System.IO;
using System.Collections.Generic;

namespace lab3agapov_v1;
/// <summary>
/// Сервісний клас service, який містить статичні методи для роботи з об'єктами 
/// класу Student, включаючи читання та запис даних у файл, а також виведення інформації про студента на консоль.
/// </summary>
public class Service
{
    public void WelcomeInfo()
    {
        Console.WriteLine("-------------------------------------------------------------------");
        Console.WriteLine("Агапов Олександр, ІПЗ-11(1), 1 курс, sasha_agapov@knu.ua");
        Console.WriteLine("                  Лабораторна робота №3(Варіант 1)                 ");
        Console.WriteLine("-------------------------------------------------------------------");
    }
    /// <summary>
    /// Метод ReadStudentFromConsole, який зчитує інформацію про студента 
    /// з консолі, включаючи його ім'я та назву предмету, і повертає об'єкт
    ///  класу Student з цією інформацією. Цей метод використовується для 
    /// створення нового студента на основі введених користувачем даних.
    /// </summary>
    /// <returns></returns>
    public Student ReadStudentFromConsole()
    {
        Console.WriteLine("Введіть ім'я студента:");
        string name = Console.ReadLine() ?? "";

        Console.WriteLine("Введіть назву предмета:");
        string subject = Console.ReadLine() ?? "";
        return new Student(name, subject, new List<int>(), 0);
    }
    /// <summary>
    /// Метод PrintStudentInfo, який приймає об'єкт класу Student і виводить його інформацію на консоль 
    /// у форматі: "Ім'я студента: [ім'я]. Назва предмету: [назва предмету]. Його поточний рейтинг: [рейтинг]".
    ///  Цей метод використовується для відображення інформації про студента, включаючи його ім'я, назву предмету та поточний рейтинг, 
    /// який обчислюється на основі його оцінок та кількості виконаних завдань.
    /// </summary>
    /// <param name="student"></param>
    public void PrintStudentInfo(Student student)
    {
        Console.WriteLine($"Ім'я студента: {student.StudentName}. Назва предмету: {student.SubjectName}. Його поточний рейтинг: {student.CalculateRating()}");
    }
    /// <summary>
    /// Метод SaveStudentToFile, який приймає об'єкт класу Student та ім'я файлу, 
    /// і зберігає інформацію про студента у вказаний файл у форматі: 
    /// "Ім'я студента;Назва предмету;Рейтинг". Цей метод використовується 
    /// для збереження даних студента у текстовому файлі, що дозволяє зберігати 
    /// інформацію про студентів для подальшого використання або аналізу.
    /// </summary>
    /// <param name="student"></param>
    /// <param name="fileName"></param>
    public void SaveStudentToFile(Student student, string fileName)
    {
        // Додаємо \n в кінці, щоб кожен студент був з нового рядка
        string data = $"{student.StudentName};{student.SubjectName};{student.CalculateRating()}\n";
        File.AppendAllText(fileName, data); // AppendAllText ДОДАЄ в кінець файлу, а не стирає!
        Console.WriteLine($"\nДані студента збережено у файл: {fileName}");
    }
    /// <summary>
    /// Метод ReadStudentFromFile, який приймає ім'я файлу,
    ///  зчитує інформацію про студента з цього файлу та виводить 
    /// її на консоль у форматі: "Ім'я: [ім'я]. Предмет: [назва предмету]. 
    /// Рейтинг: [рейтинг]". Цей метод використовується для читання даних
    /// студента з текстового файлу та відображення цієї інформації на консоль для користувача.
    /// </summary>
    /// <param name="fileName"></param>
    public void ReadStudentFromFile(string fileName)
    {
        if (File.Exists(fileName))
        {
            string[] lines = File.ReadAllLines(fileName);

            Console.WriteLine("\n--- Дані з файлу ---");
            foreach (string line in lines)
            {
                if (!string.IsNullOrWhiteSpace(line))
                {
                    string[] parts = line.Split(';');
                    if (parts.Length >= 3)
                    {
                        Console.WriteLine($"Ім'я: {parts[0]}");
                        Console.WriteLine($"Предмет: {parts[1]}");
                        Console.WriteLine($"Рейтинг: {parts[2]}");
                        Console.WriteLine("-------------------");
                    }
                }
            }
        }
        else
        {
            Console.WriteLine("Файл не знайдено!");
        }
    }

    /// <summary>
    /// Метод для вибору теми диплома. Реалізує логіку взаємодії з файлом та користувачем.
    /// </summary>
    /// <param name="student">Об'єкт студента, якому призначається тема.</param>
    public void ChooseDiplomaTheme(Student student)
    {
        string filePath = "themes.txt";
        if (!File.Exists(filePath))
        {
            Console.WriteLine("Помилка: Файл 'themes.txt' не знайдено!");
            return;
        }

        string[] allThemes = File.ReadAllLines(filePath);
        bool themeSelected = false;

        while (!themeSelected)
        {
            Console.WriteLine("\n--- Пошук теми дипломного проєкту ---");
            Console.Write("Введіть ключове слово для пошуку теми (або '0' для відміни): ");
            string keyword = Console.ReadLine()?.ToLower() ?? "";

            if (keyword == "0")
            {
                return; // Вихід, якщо користувач передумав
            }

            var matched = new List<string>();
            Console.WriteLine("\nЗнайдені варіанти:");
            for (int i = 0; i < allThemes.Length; i++)
            {
                if (allThemes[i].ToLower().Contains(keyword))
                {
                    matched.Add(allThemes[i]);
                    Console.WriteLine($"{matched.Count}. {allThemes[i]}");
                }
            }

            // Замість continue використовуємо if-else
            if (matched.Count == 0)
            {
                Console.WriteLine("За вашим запитом нічого не знайдено. Спробуйте інше слово.");
            }
            else
            {
                Console.Write("\nОберіть номер теми: ");
                if (int.TryParse(Console.ReadLine(), out int choice) && choice > 0 && choice <= matched.Count)
                {
                    student.Diploma.NameOfTheme = matched[choice - 1];
                    Console.WriteLine($"Тема '{student.Diploma.NameOfTheme}' успішно закріплена!");
                    themeSelected = true; // Завершуємо цикл
                }
                else
                {
                    Console.WriteLine("Некоректний вибір номера. Спробуйте ще раз.");
                }
            }
        }
    }
}