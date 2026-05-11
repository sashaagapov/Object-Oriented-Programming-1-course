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
        /// Захищений конструктор за замовчуванням задає порожні значення.
        /// </summary>
        protected Person()
        {
            name = "";
            subjectName = "";
        }

        /// <summary>
        /// Захищений конструктор з параметрами задає ім'я і дисципліну.
        /// </summary>
        /// <param name="name">Ім'я людини.</param>
        /// <param name="subjectName">Назва дисципліни.</param>
        protected Person(string name, string subjectName)
        {
            this.name = name;
            this.subjectName = subjectName;
        }

        /// <summary>
        /// Захищений конструктор копії копіює спільні поля іншої людини.
        /// </summary>
        /// <param name="other">Людина, з якої копіюються дані.</param>
        protected Person(Person other)
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
        /// Формує загальну інформацію про людину як один текстовий блок.
        /// </summary>
        /// <returns>Рядок з іменем і назвою дисципліни.</returns>
        public virtual string GetInfo()
        {
            return "Ім'я: " + name + "\nДисципліна: " + subjectName;
        }

        /// <summary>
        /// Базова реалізація виведення інформації про людину.
        /// </summary>
        public virtual void DisplayInfo()
        {
            Console.WriteLine(GetInfo());
        }

    }
}
