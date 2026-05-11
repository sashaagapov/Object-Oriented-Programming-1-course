using System;
using System.Collections;
using System.Collections.Generic;

namespace lab4agapov_v4
{
    /// <summary>
    /// Клас StudentGroup зберігає допоміжну групу студентів для перебору і сортування.
    /// </summary>
    public class StudentGroup : IEnumerable, ICloneable
    {
        /// <summary>
        /// Список студентів групи.
        /// </summary>
        private List<Student> students;

        /// <summary>
        /// Конструктор за замовчуванням створює порожню групу.
        /// </summary>
        public StudentGroup()
        {
            students = new List<Student>();
        }

        /// <summary>
        /// Конструктор з параметрами створює групу з готового списку.
        /// </summary>
        /// <param name="students">Список студентів.</param>
        public StudentGroup(List<Student> students)
        {
            this.students = new List<Student>();

            if (students != null)
            {
                foreach (Student student in students)
                {
                    this.students.Add((Student)student.Clone());
                }
            }
        }

        /// <summary>
        /// Конструктор копії створює нову групу на основі іншої групи.
        /// </summary>
        /// <param name="other">Група, з якої копіюються студенти.</param>
        public StudentGroup(StudentGroup other)
        {
            students = new List<Student>();

            foreach (Student student in other.students)
            {
                students.Add((Student)student.Clone());
            }
        }

        /// <summary>
        /// Додає студента до групи.
        /// </summary>
        /// <param name="student">Студент, якого треба додати.</param>
        public void AddStudent(Student student)
        {
            students.Add(student);
        }

        /// <summary>
        /// Повертає перебирач для foreach.
        /// </summary>
        /// <returns>Перебирач студентів.</returns>
        public IEnumerator GetEnumerator()
        {
            return new StudentGroupEnumerator(students);
        }

        /// <summary>
        /// Створює глибоку копію групи студентів.
        /// </summary>
        /// <returns>Клонований об'єкт StudentGroup.</returns>
        public object Clone()
        {
            StudentGroup clonedGroup = new StudentGroup();

            foreach (Student student in students)
            {
                clonedGroup.AddStudent((Student)student.Clone());
            }

            return clonedGroup;
        }

        /// <summary>
        /// Сортує студентів за рейтингом.
        /// </summary>
        public void SortStudents()
        {
            // Природне сортування виконується через реалізацію IComparable у класі Student.
            students.Sort();
        }

        /// <summary>
        /// Сортує студентів за кількістю виконаних робіт.
        /// </summary>
        public void SortByTasks()
        {
            StudentTasksComparer comparer = new StudentTasksComparer();
            // Альтернативне сортування виконується через IComparer за кількістю робіт.
            students.Sort(comparer);
        }
    }
}
