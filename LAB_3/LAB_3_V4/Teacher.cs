namespace lab3agapov_v1
{
    /// <summary>
    /// Клас Teacher представляє викладача, який веде дисципліну, керує навчальним матеріалом,
    /// ставить оцінки студенту та запускає оцінювання дипломного проєкту.
    /// </summary>
    public class Teacher
    {
        /// <summary>
        /// Повне ім'я викладача.
        /// </summary>
        private string teacherName;

        /// <summary>
        /// Назва дисципліни, яку викладає викладач.
        /// </summary>
        private string subjectName;

        /// <summary>
        /// Кількість навчальних годин за дисципліною.
        /// </summary>
        private int studyHours;

        /// <summary>
        /// Кількість студентів, з якими працює викладач у межах моделі.
        /// </summary>
        private int quantityOfStudents;

        /// <summary>
        /// Текстовий журнал, у який викладач записує виставлені оцінки та факт оцінювання диплома.
        /// </summary>
        private string gradesJournal;

        /// <summary>
        /// Навчальний матеріал, який викладач може передати студенту.
        /// </summary>
        private string studyMaterial;

        /// <summary>
        /// Конструктор за замовчуванням створює викладача з порожніми текстовими полями та нульовими числами.
        /// </summary>
        public Teacher()
        {
            teacherName = "";
            subjectName = "";
            studyHours = 0;
            quantityOfStudents = 0;
            gradesJournal = "";
            studyMaterial = "";
        }

        /// <summary>
        /// Конструктор з параметрами створює викладача з усіма даними з таблиці предметної області.
        /// </summary>
        /// <param name="teacherName">Повне ім'я викладача.</param>
        /// <param name="subjectName">Назва дисципліни.</param>
        /// <param name="studyHours">Кількість навчальних годин.</param>
        /// <param name="quantityOfStudents">Поточна кількість студентів.</param>
        /// <param name="gradesJournal">Початковий текст журналу оцінок.</param>
        /// <param name="studyMaterial">Навчальний матеріал викладача.</param>
        public Teacher(string teacherName, string subjectName, int studyHours, int quantityOfStudents, string gradesJournal, string studyMaterial)
        {
            this.teacherName = teacherName;
            this.subjectName = subjectName;
            this.studyHours = studyHours;
            this.quantityOfStudents = quantityOfStudents;
            this.gradesJournal = gradesJournal;
            this.studyMaterial = studyMaterial;
        }

        /// <summary>
        /// Конструктор копії створює нового викладача з такими самими полями, як в іншого викладача.
        /// </summary>
        /// <param name="other">Об'єкт Teacher, з якого копіюються значення.</param>
        public Teacher(Teacher other)
        {
            teacherName = other.teacherName;
            subjectName = other.subjectName;
            studyHours = other.studyHours;
            quantityOfStudents = other.quantityOfStudents;
            gradesJournal = other.gradesJournal;
            studyMaterial = other.studyMaterial;
        }

        /// <summary>
        /// Властивість для читання та зміни імені викладача.
        /// </summary>
        public string TeacherName
        {
            get { return teacherName; }
            set { teacherName = value; }
        }

        /// <summary>
        /// Властивість для читання та зміни назви дисципліни викладача.
        /// </summary>
        public string SubjectName
        {
            get { return subjectName; }
            set { subjectName = value; }
        }

        /// <summary>
        /// Властивість для читання та зміни кількості навчальних годин.
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
        /// Властивість для читання та зміни журналу оцінок викладача.
        /// </summary>
        public string GradesJournal
        {
            get { return gradesJournal; }
            set { gradesJournal = value; }
        }

        /// <summary>
        /// Властивість для читання та зміни навчального матеріалу викладача.
        /// </summary>
        public string StudyMaterial
        {
            get { return studyMaterial; }
            set { studyMaterial = value; }
        }

        /// <summary>
        /// Збільшує кількість студентів у викладача на передане число.
        /// </summary>
        /// <param name="count">Кількість студентів, яку потрібно додати.</param>
        public void IncreaseStudents(int count)
        {
            quantityOfStudents = quantityOfStudents + count;
        }

        /// <summary>
        /// Зменшує кількість студентів, якщо в поточному стані їх достатньо для такого зменшення.
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
        /// Змінює навчальне навантаження викладача на нове значення.
        /// </summary>
        /// <param name="newHours">Нова кількість навчальних годин.</param>
        public void ChangeStudyHours(int newHours)
        {
            studyHours = newHours;
        }

        /// <summary>
        /// Ставить оцінку студенту через метод самого студента і одразу записує цю дію в журнал викладача.
        /// </summary>
        /// <param name="student">Студент, якому виставляється оцінка.</param>
        /// <param name="grade">Оцінка, яку отримує студент.</param>
        public void GradeStudent(Student student, int grade)
        {
            student.AddGrade(grade);
            WriteGradeToJournal(student, grade);
        }

        /// <summary>
        /// Передає студенту навчальний матеріал, який зберігається в об'єкті викладача.
        /// </summary>
        /// <param name="student">Студент, який отримує матеріал.</param>
        public void GiveMaterial(Student student)
        {
            student.DownloadMaterial(studyMaterial);
        }

        /// <summary>
        /// Додає до журналу викладача текстовий запис про оцінку, яку отримав конкретний студент.
        /// </summary>
        /// <param name="student">Студент, інформація про якого потрапляє до журналу.</param>
        /// <param name="grade">Оцінка, що записується в журнал.</param>
        public void WriteGradeToJournal(Student student, int grade)
        {
            gradesJournal = gradesJournal + "Студент " + student.StudentName + " отримав оцінку " + grade + " з дисципліни " + subjectName + ".\n";
        }

        /// <summary>
        /// Запускає оцінювання дипломного проєкту студента від імені викладача
        /// та додає результат оцінювання до журналу.
        /// </summary>
        /// <param name="student">Студент, дипломний проєкт якого оцінюється.</param>
        public void EvaluateDiploma(Student student)
        {
            student.Diploma.DetermineGrade();
            gradesJournal = gradesJournal + "Викладач оцінив дипломний проєкт студента " + student.StudentName + ". Оцінка: " + student.Diploma.Grade + ".\n";
        }
    }
}
