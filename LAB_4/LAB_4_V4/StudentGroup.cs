using System.Collections;
namespace lab4agapov;

/// <summary>
/// Клас StudentGroup представляє групу студентів та реалізує інтерфейс IEnumerable
/// для підтримки перебору елементів через foreach. Надає методи для додавання студентів
/// та їх сортування за різними критеріями.
/// </summary>
public class StudentGroup : IEnumerable
{
    private List<Student> students = new List<Student>();

    /// <summary>
    /// Додає студента до групи.
    /// </summary>
    /// <param name="student">Об'єкт студента для додавання.</param>
    public void AddStudent(Student student)
    {
        students.Add(student);
    }

    /// <summary>
    /// Повертає перелічувач для перебору студентів групи через foreach.
    /// </summary>
    public IEnumerator GetEnumerator()
    {
        return new StudentGroupEnumerator(students); // Повертаємо власний перелічувач, щоб foreach проходив по внутрішньому списку студентів.
    }

    /// <summary>
    /// Сортує студентів за рейтингом (використовує IComparable&lt;Student&gt;).
    /// </summary>
    public void SortStudents()
    {
        students.Sort(); // Викликається CompareTo у Student, тому сортування виконується за рейтингом.
    }

    /// <summary>
    /// Сортує студентів за кількістю виконаних завдань.
    /// </summary>
    public void SortByTasks()
    {
        StudentTasksComparer studentComparer = new StudentTasksComparer();
        students.Sort(studentComparer); // Користувацький компаратор задає правило порівняння за кількістю виконаних робіт.
    }
}
