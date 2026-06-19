using System.Collections.Generic;

namespace lab5agapov_v3
{
    /// <summary>
    /// Клас Student представляє студента лабораторної роботи 4.
    /// Студент успадковує ім'я та дисципліну від класу Person.
    /// </summary>
    public class Student : Person

    {
        /// <summary>
        /// Список оцінок студента.
        /// </summary>
        private List<int> gradesList;

        /// <summary>
        /// Кількість робіт, виконаних студентом.
        /// </summary>
        private int tasksDone;

        /// <summary>
        /// Матеріал, отриманий студентом від викладача.
        /// </summary>
        private string downloadedMaterial;

        /// <summary>
        /// Середній рейтинг студента за оцінками.
        /// </summary>
        private double rating;

        /// <summary>
        /// Конструктор за замовчуванням створює студента з порожніми значеннями.
        /// </summary>
        public Student() : base()
        {
            gradesList = new List<int>();
            tasksDone = 0;
            downloadedMaterial = "";
            rating = 0;
        }

        /// <summary>
        /// Конструктор з параметрами створює студента з готовими навчальними даними.
        /// </summary>
        /// <param name="studentName">Повне ім'я студента.</param>
        /// <param name="subjectName">Назва дисципліни.</param>
        /// <param name="gradesList">Список оцінок.</param>
        /// <param name="tasksDone">Кількість виконаних робіт.</param>
        /// <param name="downloadedMaterial">Отриманий навчальний матеріал.</param>
        /// <param name="rating">Початковий рейтинг студента.</param>
        public Student(string studentName, string subjectName, List<int> gradesList, int tasksDone, string downloadedMaterial, double rating) : base(studentName, subjectName)
        {
            this.gradesList = new List<int>(gradesList);
            this.tasksDone = tasksDone;
            this.downloadedMaterial = downloadedMaterial;
            this.rating = rating;
        }

        /// <summary>
        /// Конструктор копії створює нового студента на основі іншого студента.
        /// </summary>
        /// <param name="other">Студент, дані якого копіюються.</param>
        public Student(Student other) : base(other)
        {
            gradesList = new List<int>(other.gradesList);
            tasksDone = other.tasksDone;
            downloadedMaterial = other.downloadedMaterial;
            rating = other.rating;
        }

        /// <summary>
        /// Властивість для читання та зміни імені студента через базовий клас.
        /// </summary>
        public string StudentName
        {
            get { return Name; }
            set { Name = value; }
        }

        /// <summary>
        /// Властивість для доступу до списку оцінок студента.
        /// </summary>
        public List<int> GradesList
        {
            get { return gradesList; }
            set { gradesList = value; }
        }

        /// <summary>
        /// Властивість для читання та зміни кількості виконаних робіт.
        /// </summary>
        public int TasksDone
        {
            get { return tasksDone; }
            set { tasksDone = value; }
        }

        /// <summary>
        /// Властивість для читання та зміни отриманого навчального матеріалу.
        /// </summary>
        public string DownloadedMaterial
        {
            get { return downloadedMaterial; }
            set { downloadedMaterial = value; }
        }

        /// <summary>
        /// Властивість для читання та зміни рейтингу студента.
        /// </summary>
        public double Rating
        {
            get { return rating; }
            set { rating = value; }
        }

        /// <summary>
        /// Додає оцінку до списку студента і збільшує кількість виконаних робіт.
        /// </summary>
        /// <param name="grade">Оцінка, яку отримав студент.</param>
        public void AddGrade(int grade)
        {
            gradesList.Add(grade);
            tasksDone += 1;
        }

        /// <summary>
        /// Повертає оцінки студента як один текстовий рядок.
        /// </summary>
        /// <returns>Список оцінок або повідомлення про відсутність оцінок.</returns>
        public string ViewGrades()
        {
            string result = "";
            int i;

            if (gradesList.Count == 0)
            {
                return "Оцінок немає";
            }

            for (i = 0; i < gradesList.Count; i++)
            {
                result = result + gradesList[i];

                if (i < gradesList.Count - 1)
                {
                    result = result + ", ";
                }
            }

            return result;
        }

        /// <summary>
        /// Обчислює середній рейтинг студента, записує його в поле rating і повертає результат.
        /// </summary>
        /// <returns>Поточний розрахований рейтинг студента.</returns>
        public double CalculateRating()
        {
            double sum = 0;
            int i;

            if (gradesList.Count == 0)
            {
                rating = 0;
                return rating;
            }

            for (i = 0; i < gradesList.Count; i++)
            {
                sum += gradesList[i];
            }

            rating = sum / gradesList.Count;
            return rating;
        }

        /// <summary>
        /// Зберігає навчальний матеріал, який студент отримав від викладача.
        /// </summary>
        /// <param name="material">Текст або назва отриманого матеріалу.</param>
        public void DownloadMaterial(string material)
        {
            downloadedMaterial = material;
        }
        /// <summary>
        /// Перевизначений метод для динамічного поліморфізму.
        /// Повертає повну інформацію про студента.
        /// </summary>
        public override string GetInfo()
        {
            return base.GetInfo() + "\n" +
                   "Оцінки студента: " + ViewGrades() + "\n" +
                   "Обсяг виконаних робіт: " + TasksDone + "\n" +
                   "Рейтинг студента: " + CalculateRating() + "\n" +
                   "Завантажений матеріал: " + DownloadedMaterial;
        }
        /// <summary>
        /// Додає оцінку студенту через оператор <c>+</c>.
        /// </summary>
        /// <param name="student">Студент, якого змінюємо.</param>
        /// <param name="grade">Оцінка для додавання.</param>
        /// <returns>Той самий об'єкт після зміни.</returns>
        public static Student operator +(Student student, int grade)
        {
            // Після зміни списку одразу перераховуємо рейтинг.
            student.AddGrade(grade);
            student.CalculateRating();
            return student;
        }

        /// <summary>
        /// Видаляє одну оцінку студента через оператор <c>-</c>, якщо така існує.
        /// </summary>
        /// <param name="student">Студент, якого змінюємо.</param>
        /// <param name="grade">Оцінка для видалення.</param>
        /// <returns>Той самий об'єкт після зміни.</returns>
        public static Student operator -(Student student, int grade)
        {
            // Логіка видаляє лише один збіг, щоб операція була передбачуваною.
            if (student.gradesList.Contains(grade))
            {
                student.gradesList.Remove(grade);

                if (student.tasksDone > 0)
                {
                    student.tasksDone--;
                }
            }

            student.CalculateRating();
            return student;
        }

        /// <summary>
        /// Підвищує рейтинг студента через оператор <c>++</c>.
        /// </summary>
        /// <param name="student">Студент, якого змінюємо.</param>
        /// <returns>Той самий об'єкт після зміни.</returns>
        public static Student operator ++(Student student)
        {
            // Для демонстрації додаємо максимальну оцінку.
            student.AddGrade(100);
            student.CalculateRating();
            return student;
        }

        /// <summary>
        /// Знижує рейтинг студента через оператор <c>--</c> без збільшення кількості робіт.
        /// </summary>
        /// <param name="student">Студент, якого змінюємо.</param>
        /// <returns>Той самий об'єкт після зміни.</returns>
        public static Student operator --(Student student)
        {
            if (student.gradesList.Count == 0)
            {
                return student;
            }

            // Шукаємо найбільшу оцінку, щоб м'яко знизити загальний рейтинг.
            int maxIndex = 0;

            for (int i = 1; i < student.gradesList.Count; i++)
            {
                if (student.gradesList[i] > student.gradesList[maxIndex])
                {
                    maxIndex = i;
                }
            }

            if (student.gradesList[maxIndex] > 0)
            {
                student.gradesList[maxIndex]--;
            }

            student.CalculateRating();
            return student;
        }

        /// <summary>
        /// Порівнює студентів за рейтингом.
        /// </summary>
        /// <param name="left">Лівий операнд.</param>
        /// <param name="right">Правий операнд.</param>
        /// <returns><c>true</c>, якщо рейтинг лівого більший.</returns>
        public static bool operator >(Student left, Student right)
        {
            return left.CalculateRating() > right.CalculateRating();
        }

        /// <summary>
        /// Порівнює студентів за рейтингом.
        /// </summary>
        /// <param name="left">Лівий операнд.</param>
        /// <param name="right">Правий операнд.</param>
        /// <returns><c>true</c>, якщо рейтинг лівого менший.</returns>
        public static bool operator <(Student left, Student right)
        {
            return left.CalculateRating() < right.CalculateRating();
        }

        /// <summary>
        /// Перевіряє рівність студентів за іменем і дисципліною.
        /// </summary>
        /// <param name="left">Лівий операнд.</param>
        /// <param name="right">Правий операнд.</param>
        /// <returns><c>true</c>, якщо ключові поля збігаються.</returns>
        public static bool operator ==(Student left, Student right)
        {
            if (ReferenceEquals(left, right))
            {
                return true;
            }

            if (left is null || right is null)
            {
                return false;
            }

            return left.Name == right.Name &&
                   left.SubjectName == right.SubjectName;
        }

        /// <summary>
        /// Перевіряє нерівність студентів.
        /// </summary>
        /// <param name="left">Лівий операнд.</param>
        /// <param name="right">Правий операнд.</param>
        /// <returns><c>true</c>, якщо об'єкти не рівні.</returns>
        public static bool operator !=(Student left, Student right)
        {
            return !(left == right);
        }

        /// <summary>
        /// Перевизначає порівняння для стандартних механізмів .NET.
        /// </summary>
        /// <param name="obj">Об'єкт для порівняння.</param>
        /// <returns><c>true</c>, якщо об'єкти еквівалентні.</returns>
        public override bool Equals(object obj)
        {
            // Перевизначаємо Equals, бо використовуємо власну логіку ==.
            return obj is Student other && this == other;
        }

        /// <summary>
        /// Повертає хеш-код на основі полів, що беруть участь у рівності.
        /// </summary>
        /// <returns>Хеш-код об'єкта.</returns>
        public override int GetHashCode()
        {
            return (Name + SubjectName).GetHashCode();
        }
    }
}
