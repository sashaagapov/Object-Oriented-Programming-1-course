namespace lab4agapov;

/// <summary>
/// Інтерфейс IPerson визначає контракт для всіх учасників освітнього процесу:
/// наявність властивостей Name, SubjectName та методу DisplayInfo.
/// </summary>
public interface IPerson
{
    /// <summary>Ім'я особи.</summary>
    string Name { get; set; }
    /// <summary>Назва дисципліни.</summary>
    string SubjectName { get; set; }
    /// <summary>Виводить інформацію про особу на консоль.</summary>
    void DisplayInfo();
}