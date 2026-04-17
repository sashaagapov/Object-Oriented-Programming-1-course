
namespace lab4agapov;
/// <summary>
/// Сервісний клас service, який містить статичні методи для роботи з об'єктами 
/// класу Student, включаючи читання та запис даних у файл, а також виведення інформації про студента на консоль.
/// </summary>
public class Service
{
    /// <summary>Виводить привітальне повідомлення з інформацією про автора та номер лабораторної роботи.</summary>
    public void WelcomeInfo()
    {
        Console.WriteLine("-------------------------------------------------------------------");
        Console.WriteLine("Агапов Олександр, ІПЗ-11(1), 1 курс, sasha_agapov@knu.ua");
        Console.WriteLine("                  Лабораторна робота №4(Варіант 1)                 ");
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
        string name;
        do
        {
            Console.WriteLine("Введіть ім'я студента:");
            name = Console.ReadLine() ?? "";
        } while (string.IsNullOrWhiteSpace(name));

        string subject;
        do
        {
            Console.WriteLine("Введіть назву предмета:");
            subject = Console.ReadLine() ?? "";
        } while (string.IsNullOrWhiteSpace(subject));

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
        Console.WriteLine($"Ім'я студента: {student.Name}. Назва предмету: {student.SubjectName}. Його поточний рейтинг: {student.CalculateRating()}");
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
        string data = $"{student.Name};{student.SubjectName};{student.CalculateRating()}\n";
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
    /// Зчитує студентів з файлу та додає їх до групи StudentGroup.
    /// Кожен рядок файлу містить: ім'я;предмет;рейтинг.
    /// </summary>
    /// <param name="group">Група, до якої додаються студенти.</param>
    /// <param name="fileName">Ім'я файлу для читання.</param>
    public void LoadStudentFromFile(StudentGroup group, string fileName)
    {
        if (File.Exists(fileName))
        {
            string[] lines = File.ReadAllLines(fileName);
            foreach (string line in lines)
            {
                if (!(string.IsNullOrWhiteSpace(line)))
                {
                    string[] parts = line.Split(';');
                    int rating = int.Parse(parts[2]);
                    List<int> grades = new List<int>();
                    grades.Add(rating);
                    Student student = new Student(parts[0], parts[1], grades, 1);
                    group.AddStudent(student);
                }
            }
        }
    }

    /// <summary>
    /// Метод для вибору теми диплома. Делегує логіку вибору методу Student.SelectTheme (Версія 4).
    /// </summary>
    /// <param name="student">Об'єкт студента, якому призначається тема.</param>
    public void ChooseDiplomaTheme(Student student)
    {
        student.SelectTheme("themes.txt");
    }

    /// <summary>Виводить інформацію про викладача на консоль.</summary>
    /// <param name="teacher">Об'єкт викладача.</param>
    public void PrintTeacherInfo(Teacher teacher)
    {
        Console.WriteLine($"Викладач: {teacher.Name}, Предмет: {teacher.SubjectName}, Годин: {teacher.SubjectHours}, Студентів: {teacher.QuantityOfStudents}");
    }

    /// <summary>Зберігає дані викладача у текстовий файл.</summary>
    /// <param name="teacher">Об'єкт викладача.</param>
    /// <param name="fileName">Ім'я файлу для збереження.</param>
    public void SaveTeacherToFile(Teacher teacher, string fileName)
    {
        string data = $"{teacher.Name};{teacher.SubjectName};{teacher.SubjectHours};{teacher.QuantityOfStudents}\n";
        File.AppendAllText(fileName, data);
        Console.WriteLine($"Дані викладача збережено у файл: {fileName}");
    }

}