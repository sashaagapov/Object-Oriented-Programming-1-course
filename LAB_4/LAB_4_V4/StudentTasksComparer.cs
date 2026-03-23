namespace lab4agapov;

public class StudentTasksComparer : IComparer<Student>
{
    public int Compare(Student x, Student y)
    {
       return x.TasksDone.CompareTo(y.TasksDone);
    }
}