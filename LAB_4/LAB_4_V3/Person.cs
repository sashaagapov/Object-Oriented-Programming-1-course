namespace lab4agapov;

/// <summary>
/// Базовий клас Person, що реалізує інтерфейс IPerson.
/// Зберігає загальні дані для учасників освітнього процесу: ім'я та назву предмету.
/// Конструктори protected — клас призначений тільки для успадкування.
/// </summary>
public class Person : IPerson
{
    protected string name;
    protected string subjectName;

    /// <summary>Конструктор за замовчуванням — ініціалізує поля порожніми рядками.</summary>
    protected Person()
    {
        name = string.Empty;
        subjectName = string.Empty;
    }

    /// <summary>Конструктор з параметрами для ініціалізації імені та предмету.</summary>
    /// <param name="name">Ім'я особи.</param>
    /// <param name="subjectName">Назва дисципліни.</param>
    protected Person(string name, string subjectName)
    {
        this.name = name;
        this.subjectName = subjectName;
    }

    /// <summary>Ім'я особи.</summary>
    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    /// <summary>Назва дисципліни.</summary>
    public string SubjectName
    {
        get { return subjectName; }
        set { subjectName = value; }
    }

    /// <summary>Виводить базову інформацію про особу. Virtual — дозволяє перевизначення у спадкоємцях.</summary>
    public virtual void DisplayInfo()
    {
        Console.WriteLine($"Особа: {Name}, Предмет: {SubjectName}");
    }
}