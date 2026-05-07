using System.Collections;
using System.Collections.Generic;

namespace lab4agapov_v4
{
    /// <summary>
    /// Клас StudentGroupEnumerator виконує ручний перебір студентів групи.
    /// </summary>
    public class StudentGroupEnumerator : IEnumerator
    {
        /// <summary>
        /// Список студентів для перебору.
        /// </summary>
        private List<Student> students;

        /// <summary>
        /// Поточна позиція перебору.
        /// </summary>
        private int position = -1;

        /// <summary>
        /// Конструктор за замовчуванням створює порожній перебирач.
        /// </summary>
        public StudentGroupEnumerator()
        {
            students = new List<Student>();
            position = -1;
        }

        /// <summary>
        /// Конструктор з параметрами задає список студентів.
        /// </summary>
        /// <param name="students">Список студентів.</param>
        public StudentGroupEnumerator(List<Student> students)
        {
            this.students = students;
            position = -1;
        }

        /// <summary>
        /// Конструктор копії копіює перебирач.
        /// </summary>
        /// <param name="other">Перебирач, з якого копіюються дані.</param>
        public StudentGroupEnumerator(StudentGroupEnumerator other)
        {
            students = new List<Student>(other.students);
            position = other.position;
        }

        /// <summary>
        /// Переходить до наступного студента.
        /// </summary>
        /// <returns>true, якщо студент існує.</returns>
        public bool MoveNext()
        {
            position = position + 1;
            return position < students.Count;
        }

        /// <summary>
        /// Скидає перебір на початок.
        /// </summary>
        public void Reset()
        {
            position = -1;
        }

        /// <summary>
        /// Повертає поточного студента.
        /// </summary>
        public object Current
        {
            get { return students[position]; }
        }
    }
}
