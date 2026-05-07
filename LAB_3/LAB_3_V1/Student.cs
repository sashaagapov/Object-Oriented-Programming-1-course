using System.Collections.Generic;

namespace lab3agapov_v1
{
    /// <summary>
    /// Клас Student представляє студента першої версії лабораторної роботи.
    /// Він зберігає оцінки, виконані роботи, отриманий матеріал і власний рейтинг.
    /// </summary>
    public class Student
    {
        /// <summary>
        /// Повне ім'я студента.
        /// </summary>
        private string studentName;
        /// <summary>
        /// Назва дисципліни, яку вивчає студент.
        /// </summary>
        private string subjectName;
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
        /// Конструктор за замовчуванням створює студента з порожніми текстовими значеннями,
        /// нульовими числами та порожнім списком оцінок.
        /// </summary>
        public Student()
        {
            studentName = "";
            subjectName = "";
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
        public Student(string studentName, string subjectName, List<int> gradesList, int tasksDone, string downloadedMaterial, double rating)
        {
            this.studentName = studentName;
            this.subjectName = subjectName;
            this.gradesList = gradesList;
            this.tasksDone = tasksDone;
            this.downloadedMaterial = downloadedMaterial;
            this.rating = rating;
        }

        /// <summary>
        /// Конструктор копії створює нового студента на основі іншого студента.
        /// </summary>
        /// <param name="other">Студент, дані якого копіюються.</param>
        public Student(Student other)
        {
            studentName = other.studentName;
            subjectName = other.subjectName;
            gradesList = new List<int>(other.gradesList);
            tasksDone = other.tasksDone;
            downloadedMaterial = other.downloadedMaterial;
            rating = other.rating;
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
            tasksDone = tasksDone + 1;
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
                sum = sum + gradesList[i];
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
    }
}
