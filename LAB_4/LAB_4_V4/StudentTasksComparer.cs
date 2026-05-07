using System.Collections.Generic;

namespace lab4agapov_v4
{
    /// <summary>
    /// Клас StudentTasksComparer порівнює студентів за кількістю виконаних робіт.
    /// </summary>
    public class StudentTasksComparer : IComparer<Student>
    {
        /// <summary>
        /// Умовний режим сортування.
        /// </summary>
        private int mode;

        /// <summary>
        /// Конструктор за замовчуванням задає стандартний режим.
        /// </summary>
        public StudentTasksComparer()
        {
            mode = 0;
        }

        /// <summary>
        /// Конструктор з параметрами задає умовний режим.
        /// </summary>
        /// <param name="mode">Умовний режим сортування.</param>
        public StudentTasksComparer(int mode)
        {
            this.mode = mode;
        }

        /// <summary>
        /// Конструктор копії копіює режим іншого компаратора.
        /// </summary>
        /// <param name="other">Компаратор, з якого копіюється режим.</param>
        public StudentTasksComparer(StudentTasksComparer other)
        {
            mode = other.mode;
        }

        /// <summary>
        /// Порівнює студентів за кількістю виконаних робіт, а потім за рейтингом.
        /// </summary>
        /// <param name="x">Перший студент.</param>
        /// <param name="y">Другий студент.</param>
        /// <returns>Результат порівняння.</returns>
        public int Compare(Student x, Student y)
        {
            if (x == null && y == null)
            {
                return 0;
            }

            if (x == null)
            {
                return 1;
            }

            if (y == null)
            {
                return -1;
            }

            if (x.TasksDone != y.TasksDone)
            {
                return y.TasksDone.CompareTo(x.TasksDone);
            }

            return y.CalculateRating().CompareTo(x.CalculateRating());
        }
    }
}
