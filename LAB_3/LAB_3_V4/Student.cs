using System.Collections.Generic;

namespace lab3agapov_v1
{
    /// <summary>
    /// Частковий клас Student описує студента, його оцінки, виконані роботи,
    /// отримані матеріали та пов'язаний з ним дипломний проєкт.
    /// </summary>
    public partial class Student
    {
        /// <summary>
        /// Повне ім'я студента.
        /// </summary>
        private string studentName;

        /// <summary>
        /// Назва дисципліни, яку студент вивчає в межах лабораторної роботи.
        /// </summary>
        private string subjectName;

        /// <summary>
        /// Список оцінок студента з дисципліни.
        /// </summary>
        private List<int> gradesList;

        /// <summary>
        /// Кількість навчальних робіт, виконаних студентом.
        /// </summary>
        private int tasksDone;

        /// <summary>
        /// Навчальний матеріал, який студент отримав від викладача.
        /// </summary>
        private string downloadedMaterial;

        /// <summary>
        /// Поточний рейтинг студента, який розраховується як середнє значення оцінок.
        /// </summary>
        private double rating;

        /// <summary>
        /// Дипломний проєкт, закріплений за студентом у другій, третій та четвертій версіях роботи.
        /// </summary>
        private DiplomaProject diploma;

        /// <summary>
        /// Конструктор за замовчуванням створює студента з порожніми текстовими полями,
        /// нульовими числовими значеннями, порожнім списком оцінок і новим дипломним проєктом.
        /// </summary>
        public Student()
        {
            studentName = "";
            subjectName = "";
            gradesList = new List<int>();
            tasksDone = 0;
            downloadedMaterial = "";
            rating = 0;
            diploma = new DiplomaProject();
        }

        /// <summary>
        /// Конструктор з параметрами створює студента з уже відомими навчальними даними.
        /// </summary>
        /// <param name="studentName">Повне ім'я студента.</param>
        /// <param name="subjectName">Назва дисципліни студента.</param>
        /// <param name="gradesList">Список оцінок студента.</param>
        /// <param name="tasksDone">Кількість виконаних робіт.</param>
        /// <param name="downloadedMaterial">Матеріал, отриманий студентом.</param>
        /// <param name="rating">Початковий рейтинг студента.</param>
        /// <param name="diploma">Дипломний проєкт студента.</param>
        public Student(string studentName, string subjectName, List<int> gradesList, int tasksDone, string downloadedMaterial, double rating, DiplomaProject diploma)
        {
            this.studentName = studentName;
            this.subjectName = subjectName;
            this.gradesList = gradesList;
            this.tasksDone = tasksDone;
            this.downloadedMaterial = downloadedMaterial;
            this.rating = rating;
            this.diploma = diploma;
        }

        /// <summary>
        /// Конструктор копії створює нового студента з такими самими даними, як в іншого студента.
        /// Список оцінок і дипломний проєкт копіюються в окремі об'єкти.
        /// </summary>
        /// <param name="other">Інший студент, дані якого потрібно скопіювати.</param>
        public Student(Student other)
        {
            studentName = other.studentName;
            subjectName = other.subjectName;
            gradesList = new List<int>(other.gradesList);
            tasksDone = other.tasksDone;
            downloadedMaterial = other.downloadedMaterial;
            rating = other.rating;
            diploma = new DiplomaProject(other.diploma);
        }

        /// <summary>
        /// Властивість для читання та зміни імені студента.
        /// </summary>
        public string StudentName
        {
            get { return studentName; }
            set { studentName = value; }
        }

        /// <summary>
        /// Властивість для читання та зміни назви дисципліни студента.
        /// </summary>
        public string SubjectName
        {
            get { return subjectName; }
            set { subjectName = value; }
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
        /// Властивість для читання та зміни матеріалу, який студент отримав від викладача.
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
        /// Властивість для доступу до дипломного проєкту студента.
        /// </summary>
        public DiplomaProject Diploma
        {
            get { return diploma; }
            set { diploma = value; }
        }

        /// <summary>
        /// Додає нову оцінку до списку студента і збільшує кількість виконаних робіт.
        /// </summary>
        /// <param name="grade">Оцінка, яку потрібно додати студенту.</param>
        public void AddGrade(int grade)
        {
            gradesList.Add(grade);
            tasksDone += 1;
        }

        /// <summary>
        /// Повертає всі оцінки студента у вигляді одного простого текстового рядка.
        /// </summary>
        /// <returns>Текст зі списком оцінок або повідомлення про їх відсутність.</returns>
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
        /// Розраховує середній рейтинг студента за всіма оцінками та записує результат у поле rating.
        /// </summary>
        /// <returns>Поточний рейтинг студента після розрахунку.</returns>
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
        /// Зберігає в об'єкті студента навчальний матеріал, отриманий від викладача.
        /// </summary>
        /// <param name="material">Текст або назва навчального матеріалу.</param>
        public void DownloadMaterial(string material)
        {
            downloadedMaterial = material;
        }

        /// <summary>
        /// Частковий вкладений клас DiplomaProject описує дипломний проєкт студента:
        /// тему, кількість методів, складність, оцінку та наукового керівника.
        /// </summary>
        public partial class DiplomaProject
        {
            /// <summary>
            /// Назва теми дипломного проєкту.
            /// </summary>
            private string themeName;

            /// <summary>
            /// Кількість методів, реалізованих у дипломному проєкті.
            /// </summary>
            private int methodsCount;

            /// <summary>
            /// Загальна складність теми, отримана як сума складностей окремих методів.
            /// </summary>
            private int themeComplexity;

            /// <summary>
            /// Оцінка за дипломний проєкт.
            /// </summary>
            private int grade;

            /// <summary>
            /// Ім'я керівника дипломного проєкту.
            /// </summary>
            private string supervisorName;

            /// <summary>
            /// Конструктор за замовчуванням створює порожній дипломний проєкт з нульовими числовими значеннями.
            /// </summary>
            public DiplomaProject()
            {
                themeName = "";
                methodsCount = 0;
                themeComplexity = 0;
                grade = 0;
                supervisorName = "";
            }

            /// <summary>
            /// Конструктор з параметрами створює дипломний проєкт з усіма основними характеристиками.
            /// </summary>
            /// <param name="themeName">Назва теми дипломного проєкту.</param>
            /// <param name="methodsCount">Кількість методів у проєкті.</param>
            /// <param name="themeComplexity">Сумарна складність теми.</param>
            /// <param name="grade">Оцінка за дипломний проєкт.</param>
            /// <param name="supervisorName">Ім'я керівника дипломного проєкту.</param>
            public DiplomaProject(string themeName, int methodsCount, int themeComplexity, int grade, string supervisorName)
            {
                this.themeName = themeName;
                this.methodsCount = methodsCount;
                this.themeComplexity = themeComplexity;
                this.grade = grade;
                this.supervisorName = supervisorName;
            }

            /// <summary>
            /// Конструктор копії створює новий дипломний проєкт з такими самими значеннями,
            /// як у вже існуючого дипломного проєкту.
            /// </summary>
            /// <param name="other">Інший дипломний проєкт, з якого копіюються дані.</param>
            public DiplomaProject(DiplomaProject other)
            {
                themeName = other.themeName;
                methodsCount = other.methodsCount;
                themeComplexity = other.themeComplexity;
                grade = other.grade;
                supervisorName = other.supervisorName;
            }

            /// <summary>
            /// Властивість для читання та зміни назви теми дипломного проєкту.
            /// </summary>
            public string ThemeName
            {
                get { return themeName; }
                set { themeName = value; }
            }

            /// <summary>
            /// Властивість для читання та зміни кількості методів у дипломному проєкті.
            /// </summary>
            public int MethodsCount
            {
                get { return methodsCount; }
                set { methodsCount = value; }
            }

            /// <summary>
            /// Властивість для читання та зміни сумарної складності теми.
            /// </summary>
            public int ThemeComplexity
            {
                get { return themeComplexity; }
                set { themeComplexity = value; }
            }

            /// <summary>
            /// Властивість для читання та зміни оцінки за дипломний проєкт.
            /// </summary>
            public int Grade
            {
                get { return grade; }
                set { grade = value; }
            }

            /// <summary>
            /// Властивість для читання та зміни імені керівника дипломного проєкту.
            /// </summary>
            public string SupervisorName
            {
                get { return supervisorName; }
                set { supervisorName = value; }
            }
        }
    }
}
