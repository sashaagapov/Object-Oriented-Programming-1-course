using System;

namespace lab4agapov;
/// <summary>
/// Клас Teacher, який містить поля для зберігання інформації про викладача
/// та метод для зміни кількості студентів та годин викладання.
/// Успадкування від класу Person, який містить загальні властивості
/// для викладача та студента, такі як ім'я та назва предмету. 
/// Додано метод UpdateStudentCount для зміни кількості студентів та відповідного оновлення годин викладання.
/// </summary>
public class Teacher : Person // Успадкування
{
    private int subjectHours = 0;
    private int quantityOfStudents = 0;
    /// <summary>
    /// Конструктор за замовчуванням, конструктор з параметрами та конструктор копіювання 
    /// для класу Teacher, які викликають відповідні конструктори
    ///  базового класу Person для ініціалізації загальних властивостей.
    /// </summary>
    public Teacher() : base() // Виклик базового порожнього конструктора
    {
        subjectHours = 0;
        quantityOfStudents = 0;
    }
    /// <summary>
    /// Конструктор з параметрами для класу Teacher, який ініціалізує всі поля 
    /// класу відповідно до переданих аргументів та викликає конструктор
    ///  базового класу Person для ініціалізації загальних властивостей.
    /// </summary>
    /// <param name="teacherName"></param>
    /// <param name="subjectName"></param>
    /// <param name="subjectHours"></param>
    /// <param name="quantityOfStudents"></param>
    public Teacher(string teacherName, string subjectName, int subjectHours, int quantityOfStudents)
        : base(teacherName, subjectName) // Передаємо ім'я та предмет у клас Person
    {
        this.subjectHours = subjectHours;
        this.quantityOfStudents = quantityOfStudents;
    }
    /// <summary>
    /// Конструктор копіювання для класу Teacher, який створює новий об'єкт на
    ///  основі існуючого об'єкта Teacher, копіюючи всі його поля та викликаючи 
    /// конструктор копіювання базового класу Person для ініціалізації загальних властивостей.
    /// </summary>
    /// <param name="previousTeacher"></param>
    public Teacher(Teacher previousTeacher)
        : base(previousTeacher.Name, previousTeacher.SubjectName)
    {
        this.subjectHours = previousTeacher.subjectHours;
        this.quantityOfStudents = previousTeacher.quantityOfStudents;
    }
    /// <summary>
    /// Властивості для доступу до полів класу Teacher: SubjectHours та QuantityOfStudents. 
    /// Вони дозволяють отримувати та встановлювати значення відповідних полів.
    /// </summary>
    public int SubjectHours
    {
        get { return subjectHours; }
        set { subjectHours = value; }
    }
    /// <summary>
    /// Кількість студентів, закріплених за викладачем або навчальною групою.
    /// </summary>
    public int QuantityOfStudents
    {
        get { return quantityOfStudents; }
        set { quantityOfStudents = value; }
    }
    /// <summary>
    /// Метод UpdateStudentCount для зміни кількості студентів та відповідного оновлення годин викладання.
    /// Метод приймає різницю у кількості студентів (positive для збільшення, negative для зменшення) та оновлює відповідно кількість студентів
    /// та годин викладання (припускаючи, що кожен студент додає 2 години викладання). Метод також перевіряє, щоб кількість студентів не стала від'ємною.
    /// </summary>
    /// <param name="difference"></param>
    public void UpdateStudentCount(int difference)
    {
        if (quantityOfStudents + difference >= 0)
        {
            quantityOfStudents += difference;
            subjectHours += difference * 2;
        }
        else
        {
            Console.WriteLine("Некоректні данні");
            return;
        }

    }
    /// <summary>
    /// Перевизначає базовий метод DisplayInfo — виводить загальну інформацію про особу,
    /// а також специфічні дані викладача: кількість студентів та годин.
    /// </summary>
    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine($"[Викладач] Кількість студентів: {QuantityOfStudents}, Годин: {SubjectHours}");
    }
}
