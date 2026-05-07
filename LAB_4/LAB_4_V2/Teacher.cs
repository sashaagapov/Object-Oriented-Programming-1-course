namespace lab4agapov_v2
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
    }
}
