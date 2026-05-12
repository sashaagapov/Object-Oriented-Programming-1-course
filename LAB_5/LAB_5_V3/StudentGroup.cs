using System;
using System.Collections.Generic;

namespace lab5agapov_v3
{
    /// <summary>
    /// Модель академічної групи, яка зберігає набір студентів.
    /// </summary>
    public class StudentGroup
    {
        /// <summary>
        /// Внутрішній список студентів групи.
        /// </summary>
        private List<Student> students;

        /// <summary>
        /// Створює порожню групу без студентів.
        /// </summary>
        public StudentGroup()
        {
            students = new List<Student>();
        }

        /// <summary>
        /// Додає студента до групи.
        /// </summary>
        /// <param name="student">Студент, якого додаємо.</param>
        public void AddStudent(Student student)
        {
            students.Add(student);
        }

        /// <summary>
        /// Поточна кількість студентів у групі.
        /// </summary>
        public int Count
        {
            get { return students.Count; }
        }

        /// <summary>
        /// Надає доступ до студента за індексом.
        /// </summary>
        /// <param name="index">Позиція студента у списку.</param>
        /// <returns>Студент за вказаним індексом.</returns>
        /// <exception cref="IndexOutOfRangeException">Викидається, якщо індекс поза межами списку.</exception>
        public Student this[int index]
        {
            get
            {
                // Явно перевіряємо межі, щоб отримати зрозуміле повідомлення про помилку.
                if (index < 0 || index >= students.Count)
                {
                    throw new IndexOutOfRangeException("Некоректний індекс студента.");
                }

                return students[index];
            }
            set
            {
                // Ту саму перевірку робимо і при записі через індексатор.
                if (index < 0 || index >= students.Count)
                {
                    throw new IndexOutOfRangeException("Некоректний індекс студента.");
                }

                students[index] = value;
            }
        }

        /// <summary>
        /// Формує текстовий опис усіх студентів групи.
        /// </summary>
        /// <returns>Інформація по кожному студенту групи.</returns>
        public string GetInfo()
        {
            if (students.Count == 0)
            {
                return "У групі немає студентів.";
            }

            string info = "Склад групи:\n";

            for (int i = 0; i < students.Count; i++)
            {
                // Нумерація допомагає швидко звірити елемент із індексом.
                info = info + "Студент #" + i + ":\n" + students[i].GetInfo() + "\n";
            }

            return info;
        }
    }
}
