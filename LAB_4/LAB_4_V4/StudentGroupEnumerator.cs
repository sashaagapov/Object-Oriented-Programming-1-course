using System.Collections;
namespace lab4agapov;

/// <summary>
/// Перелічувач для класу StudentGroup. Реалізує IEnumerator для послідовного
/// перебору студентів групи через foreach.
/// </summary>
public class StudentGroupEnumerator : IEnumerator
{
    private readonly List<Student> _students;
    private int _position = -1;

    /// <summary>Ініціалізує перелічувач із переданим списком студентів.</summary>
    /// <param name="students">Список студентів для перебору.</param>
    public StudentGroupEnumerator(List<Student> students)
    {
        _students = students;
    }

    /// <summary>Переміщує курсор до наступного елемента. Повертає false, якщо елементи закінчились.</summary>
    public bool MoveNext()
    {
        _position++;
        return _position < _students.Count;
    }

    /// <summary>Скидає курсор на позицію перед першим елементом.</summary>
    public void Reset()
    {
        _position = -1;
    }

    /// <summary>Повертає поточний елемент перебору.</summary>
    public object Current
    {
        get { return _students[_position]; }
    }
}
