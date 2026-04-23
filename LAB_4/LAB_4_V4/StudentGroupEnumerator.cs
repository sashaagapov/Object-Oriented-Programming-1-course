using System.Collections;
namespace lab4agapov;

/// <summary>
/// Перелічувач для класу StudentGroup. Реалізує IEnumerator для послідовного
/// перебору студентів групи через foreach.
/// </summary>
public class StudentGroupEnumerator : IEnumerator
{
    private readonly List<Student> students;
    private int position = -1;

    /// <summary>
    /// Ініціалізує перелічувач із переданим списком студентів.
    /// </summary>
    /// <param name="students">Список студентів для перебору.</param>
    public StudentGroupEnumerator(List<Student> students)
    {
        this.students = students;
    }

    /// <summary>
    /// Переміщує курсор до наступного елемента. Повертає false, якщо елементи закінчились.
    /// </summary>
    public bool MoveNext()
    {
        position++; // Зсуваємо позицію на один елемент вперед перед перевіркою меж колекції.
        return position < students.Count; // Поки позиція всередині списку, foreach продовжує ітерацію.
    }

    /// <summary>
    /// Скидає курсор на позицію перед першим елементом.
    /// </summary>
    public void Reset()
    {
        position = -1; // Повертаємо курсор у початковий стан "до першого елемента".
    }

    /// <summary>
    /// Повертає поточний елемент перебору.
    /// </summary>
    public object Current
    {
        get
        {
            return students[position]; // Повертаємо саме той елемент, на який зараз вказує курсор переліку.
        }
    }
}
