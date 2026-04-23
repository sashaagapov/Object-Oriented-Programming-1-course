namespace lab4agapov;

/// <summary>
/// Компаратор для сортування студентів за кількістю виконаних завдань (TasksDone).
/// Використовується методом StudentGroup.SortByTasks().
/// </summary>
public class StudentTasksComparer : IComparer<Student>
{
    /// <summary>Порівнює двох студентів за кількістю виконаних завдань.</summary>
    public int Compare(Student x, Student y)
    {
       return y.TasksDone.CompareTo(x.TasksDone); // !
    }
}
