using System.Collections;
namespace lab4agapov;

public class StudentGroup : IEnumerable, IEnumerator
{
    private List<Student> students = new List<Student>();
    private int position = -1;

    public void AddStudent(Student student)
    {
        students.Add(student);
    }

    public bool MoveNext()
    {
        position++;
        if (students.Count > position)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public void Reset()
    {
        position = -1;
    }

    public object Current
    {
        get
        {
            return students[position];
        }
    }

    public IEnumerator GetEnumerator()
    {

        Reset();
        return this;
    }
    public void SortStudents()
    {
        students.Sort(); 
    }
}