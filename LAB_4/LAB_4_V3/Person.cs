using System;

namespace lab4agapov_v2
{
    /// <summary>
    /// Базовий клас Person описує спільні дані людини в освітньому процесі.
    /// У третій версії він реалізує інтерфейс IPerson.
    /// </summary>
    public class Person : IPerson
    {
        /// <summary>
        /// Ім'я людини.
        /// </summary>
        private string name;

        /// <summary>
        /// Назва дисципліни людини.
        /// </summary>
        private string subjectName;

        /// <summary>
        /// Конструктор за замовчуванням задає порожні значення.
        /// </summary>
        public Person()
        {
            name = "";
            subjectName = "";
        }

        /// <summary>
        /// Конструктор з параметрами задає ім'я і дисципліну.
        /// </summary>
        /// <param name="name">Ім'я людини.</param>
        /// <param name="subjectName">Назва дисципліни.</param>
        public Person(string name, string subjectName)
        {
            this.name = name;
            this.subjectName = subjectName;
        }

        /// <summary>
        /// Конструктор копії копіює спільні поля іншої людини.
        /// </summary>
        /// <param name="other">Людина, з якої копіюються дані.</param>
        public Person(Person other)
        {
            name = other.name;
            subjectName = other.subjectName;
        }

        /// <summary>
        /// Властивість для читання та зміни імені людини.
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        /// <summary>
        /// Властивість для читання та зміни назви дисципліни.
        /// </summary>
        public string SubjectName
        {
            get { return subjectName; }
            set { subjectName = value; }
        }

        /// <summary>
        /// Виводить загальну інформацію про людину.
        /// </summary>
        public virtual void DisplayInfo()
        {
            Console.WriteLine("Ім'я: " + name);
            Console.WriteLine("Дисципліна: " + subjectName);
        }

    }
}
