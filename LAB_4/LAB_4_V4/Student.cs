using System;
using System.Collections.Generic;

namespace lab4agapov_v4
{
    /// <summary>
    /// Клас Student представляє студента лабораторної роботи 4.
    /// Студент успадковує ім'я та дисципліну від класу Person.
    /// </summary>
    public partial class Student : Person, IComparable<Student>, ICloneable
    {
        private List<int> gradesList;
        private int tasksDone;
        private string downloadedMaterial;
        private double rating;

        public Student() : base()
        {
            gradesList = new List<int>();
            tasksDone = 0;
            downloadedMaterial = "";
            rating = 0;
        }

        public Student(string studentName, string subjectName, List<int> gradesList, int tasksDone, string downloadedMaterial, double rating) : base(studentName, subjectName)
        {
            this.gradesList = gradesList == null ? new List<int>() : new List<int>(gradesList);
            this.tasksDone = tasksDone;
            this.downloadedMaterial = downloadedMaterial;
            this.rating = rating;
        }

        public Student(Student other) : base(other)
        {
            gradesList = new List<int>(other.gradesList);
            tasksDone = other.tasksDone;
            downloadedMaterial = other.downloadedMaterial;
            rating = other.rating;
        }

        public string StudentName
        {
            get { return Name; }
            set { Name = value; }
        }

        public List<int> GradesList
        {
            get { return new List<int>(gradesList); }
            set { gradesList = value == null ? new List<int>() : new List<int>(value); }
        }

        public int TasksDone
        {
            get { return tasksDone; }
            set { tasksDone = value; }
        }

        public string DownloadedMaterial
        {
            get { return downloadedMaterial; }
            set { downloadedMaterial = value; }
        }

        public double Rating
        {
            get { return rating; }
            set { rating = value; }
        }

        public void AddGrade(int grade)
        {
            gradesList.Add(grade);
            tasksDone += 1;
        }

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
                result += gradesList[i];

                if (i < gradesList.Count - 1)
                {
                    result += ", ";
                }
            }

            return result;
        }

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

        public void DownloadMaterial(string material)
        {
            downloadedMaterial = material;
        }

        public override string GetInfo()
        {
            string info = base.GetInfo();

            info += "\nОцінки: " + ViewGrades();
            info += "\nВиконано робіт: " + tasksDone;
            info += "\nРейтинг: " + CalculateRating();
            info += "\nОтриманий матеріал: " + downloadedMaterial;

            return info;
        }

        public object Clone()
        {
            return new Student(this);
        }

        public int CompareTo(Student other)
        {
            if (other == null)
            {
                return 1;
            }

            return other.CalculateRating().CompareTo(CalculateRating());
        }
    }
}
