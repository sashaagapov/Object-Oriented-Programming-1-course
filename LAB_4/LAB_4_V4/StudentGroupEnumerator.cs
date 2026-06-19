using System.Collections;
using System.Collections.Generic;

namespace lab4agapov_v4
{
    /// <summary>
    /// Клас StudentGroupEnumerator виконує ручний перебір студентів групи.
    /// </summary>
    public class StudentGroupEnumerator : IEnumerator
    {
        private List<Student> students;
        private int position = -1;

        public StudentGroupEnumerator()
        {
            students = new List<Student>();
            position = -1;
        }

        public StudentGroupEnumerator(List<Student> students)
        {
            this.students = students;
            position = -1;
        }

        public StudentGroupEnumerator(StudentGroupEnumerator other)
        {
            students = new List<Student>(other.students);
            position = other.position;
        }

        public bool MoveNext()
        {
            position += 1;
            return position < students.Count;
        }

        public void Reset()
        {
            position = -1;
        }

        public object Current
        {
            get { return students[position]; }
        }
    }
}
