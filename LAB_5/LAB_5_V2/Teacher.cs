namespace lab5agapov_v2
{
    /// <summary>
    /// Клас Teacher представляє викладача лабораторної роботи 4.
    /// Викладач успадковує ім'я та дисципліну від класу Person.
    /// </summary>
    public class Teacher : Person

    {
        /// <summary>
        /// Кількість навчальних годин за дисципліною.
        /// </summary>
        private int studyHours;

        /// <summary>
        /// Кількість студентів, закріплених за викладачем.
        /// </summary>
        private int quantityOfStudents;

        /// <summary>
        /// Журнал, у який викладач записує виставлені оцінки.
        /// </summary>
        private string gradesJournal;

        /// <summary>
        /// Навчальний матеріал, який викладач передає студенту.
        /// </summary>
        private string studyMaterial;

        /// <summary>
        /// Конструктор за замовчуванням створює викладача з порожніми рядками та нульовими числами.
        /// </summary>
        public Teacher() : base()
        {
            studyHours = 0;
            quantityOfStudents = 0;
            gradesJournal = "";
            studyMaterial = "";
        }

        /// <summary>
        /// Конструктор з параметрами створює викладача з усіма значеннями полів.
        /// </summary>
        /// <param name="teacherName">Повне ім'я викладача.</param>
        /// <param name="subjectName">Назва дисципліни.</param>
        /// <param name="studyHours">Кількість навчальних годин.</param>
        /// <param name="quantityOfStudents">Кількість студентів.</param>
        /// <param name="gradesJournal">Початковий журнал оцінок.</param>
        /// <param name="studyMaterial">Навчальний матеріал.</param>
        public Teacher(string teacherName, string subjectName, int studyHours, int quantityOfStudents, string gradesJournal, string studyMaterial) : base(teacherName, subjectName)
        {
            this.studyHours = studyHours;
            this.quantityOfStudents = quantityOfStudents;
            this.gradesJournal = gradesJournal;
            this.studyMaterial = studyMaterial;
        }

        /// <summary>
        /// Конструктор копії створює нового викладача з даними іншого викладача.
        /// </summary>
        /// <param name="other">Викладач, з якого копіюються поля.</param>
        public Teacher(Teacher other) : base(other)
        {
            studyHours = other.studyHours;
            quantityOfStudents = other.quantityOfStudents;
            gradesJournal = other.gradesJournal;
            studyMaterial = other.studyMaterial;
        }

        /// <summary>
        /// Властивість для читання та зміни імені викладача через базовий клас.
        /// </summary>
        public string TeacherName
        {
            get { return Name; }
            set { Name = value; }
        }

        /// <summary>
        /// Властивість для читання та зміни навчального навантаження викладача.
        /// </summary>
        public int StudyHours
        {
            get { return studyHours; }
            set { studyHours = value; }
        }

        /// <summary>
        /// Властивість для читання та зміни кількості студентів.
        /// </summary>
        public int QuantityOfStudents
        {
            get { return quantityOfStudents; }
            set { quantityOfStudents = value; }
        }

        /// <summary>
        /// Властивість для читання та зміни журналу оцінок.
        /// </summary>
        public string GradesJournal
        {
            get { return gradesJournal; }
            set { gradesJournal = value; }
        }

        /// <summary>
        /// Властивість для читання та зміни навчального матеріалу.
        /// </summary>
        public string StudyMaterial
        {
            get { return studyMaterial; }
            set { studyMaterial = value; }
        }

        /// <summary>
        /// Збільшує кількість студентів на задане число.
        /// </summary>
        /// <param name="count">Кількість студентів, яку потрібно додати.</param>
        public void IncreaseStudents(int count)
        {
            quantityOfStudents = quantityOfStudents + count;
        }

        /// <summary>
        /// Зменшує кількість студентів, якщо поточна кількість дозволяє це зробити.
        /// </summary>
        /// <param name="count">Кількість студентів, яку потрібно відняти.</param>
        public void DecreaseStudents(int count)
        {
            if (quantityOfStudents >= count)
            {
                quantityOfStudents = quantityOfStudents - count;
            }
        }

        /// <summary>
        /// Змінює кількість навчальних годин викладача.
        /// </summary>
        /// <param name="newHours">Нове значення навчального навантаження.</param>
        public void ChangeStudyHours(int newHours)
        {
            studyHours = newHours;
        }

        /// <summary>
        /// Виставляє студенту оцінку через метод студента і записує результат у журнал.
        /// </summary>
        /// <param name="student">Студент, який отримує оцінку.</param>
        /// <param name="grade">Оцінка студента.</param>
        public void GradeStudent(Student student, int grade)
        {
            student.AddGrade(grade);
            WriteGradeToJournal(student, grade);
        }

        /// <summary>
        /// Передає студенту поточний навчальний матеріал викладача.
        /// </summary>
        /// <param name="student">Студент, який отримує матеріал.</param>
        public void GiveMaterial(Student student)
        {
            student.DownloadMaterial(studyMaterial);
        }

        /// <summary>
        /// Додає до журналу текстовий запис про оцінку конкретного студента.
        /// </summary>
        /// <param name="student">Студент, про якого створюється запис.</param>
        /// <param name="grade">Оцінка, яка записується в журнал.</param>
        public void WriteGradeToJournal(Student student, int grade)
        {
            gradesJournal = gradesJournal + "Студент " + student.StudentName + " отримав оцінку " + grade + " з дисципліни " + SubjectName + ".\n";
        }
        /// <summary>
        /// Збільшує кількість студентів, закріплених за викладачем.
        /// </summary>
        /// <param name="teacher">Викладач, якого змінюємо.</param>
        /// <param name="studentsCount">Скільки студентів додати.</param>
        /// <returns>Той самий об'єкт після зміни.</returns>
        public static Teacher operator +(Teacher teacher, int studentsCount)
        {
            teacher.IncreaseStudents(studentsCount);
            return teacher;
        }

        /// <summary>
        /// Зменшує кількість студентів, закріплених за викладачем.
        /// </summary>
        /// <param name="teacher">Викладач, якого змінюємо.</param>
        /// <param name="studentsCount">Скільки студентів відняти.</param>
        /// <returns>Той самий об'єкт після зміни.</returns>
        public static Teacher operator -(Teacher teacher, int studentsCount)
        {
            teacher.DecreaseStudents(studentsCount);
            return teacher;
        }

        /// <summary>
        /// Збільшує навчальне навантаження викладача на 1.
        /// </summary>
        /// <param name="teacher">Викладач, якого змінюємо.</param>
        /// <returns>Той самий об'єкт після зміни.</returns>
        public static Teacher operator ++(Teacher teacher)
        {
            teacher.StudyHours++;
            return teacher;
        }

        /// <summary>
        /// Зменшує навчальне навантаження викладача на 1, але не нижче нуля.
        /// </summary>
        /// <param name="teacher">Викладач, якого змінюємо.</param>
        /// <returns>Той самий об'єкт після зміни.</returns>
        public static Teacher operator --(Teacher teacher)
        {
            // Лімітуємо нижню межу, щоб не отримати від'ємне навантаження.
            if (teacher.StudyHours > 0)
            {
                teacher.StudyHours--;
            }

            return teacher;
        }

        /// <summary>
        /// Порівнює двох викладачів за навчальним навантаженням.
        /// </summary>
        /// <param name="left">Лівий операнд.</param>
        /// <param name="right">Правий операнд.</param>
        /// <returns><c>true</c>, якщо навантаження лівого більше.</returns>
        public static bool operator >(Teacher left, Teacher right)
        {
            return left.StudyHours > right.StudyHours;
        }

        /// <summary>
        /// Порівнює двох викладачів за навчальним навантаженням.
        /// </summary>
        /// <param name="left">Лівий операнд.</param>
        /// <param name="right">Правий операнд.</param>
        /// <returns><c>true</c>, якщо навантаження лівого менше.</returns>
        public static bool operator <(Teacher left, Teacher right)
        {
            return left.StudyHours < right.StudyHours;
        }

        /// <summary>
        /// Перевіряє рівність викладачів за іменем і дисципліною.
        /// </summary>
        /// <param name="left">Лівий операнд.</param>
        /// <param name="right">Правий операнд.</param>
        /// <returns><c>true</c>, якщо ключові поля збігаються.</returns>
        public static bool operator ==(Teacher left, Teacher right)
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
        /// Перевіряє нерівність викладачів.
        /// </summary>
        /// <param name="left">Лівий операнд.</param>
        /// <param name="right">Правий операнд.</param>
        /// <returns><c>true</c>, якщо об'єкти не рівні.</returns>
        public static bool operator !=(Teacher left, Teacher right)
        {
            return !(left == right);
        }

        /// <summary>
        /// Перевизначає порівняння для стандартних колекцій і API .NET.
        /// </summary>
        /// <param name="obj">Об'єкт для порівняння.</param>
        /// <returns><c>true</c>, якщо об'єкти еквівалентні.</returns>
        public override bool Equals(object obj)
        {
            // Підтримуємо ту саму логіку, що і в операторі ==.
            return obj is Teacher other && this == other;
        }

        /// <summary>
        /// Повертає хеш-код на основі полів, які використовуються в рівності.
        /// </summary>
        /// <returns>Хеш-код об'єкта.</returns>
        public override int GetHashCode()
        {
            return (Name + SubjectName).GetHashCode();
        }
        /// <summary>
        /// Повертає повну інформацію про викладача з урахуванням поточного стану полів.
        /// </summary>
        /// <returns>Текстовий опис об'єкта викладача.</returns>
        public override string GetInfo()
        {
            return base.GetInfo() + "\n" +
                   "Навчальне навантаження: " + StudyHours + "\n" +
                   "Кількість студентів: " + QuantityOfStudents + "\n" +
                   "Журнал оцінок: " + GradesJournal + "\n" +
                   "Навчальний матеріал: " + StudyMaterial;
        }
    }
}
