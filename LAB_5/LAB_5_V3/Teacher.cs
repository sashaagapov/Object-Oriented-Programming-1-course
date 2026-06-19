using System;

namespace lab5agapov_v3
{
    /// <summary>
    /// Клас Teacher представляє викладача та містить предметну логіку сценарію.
    /// </summary>
    public class Teacher : Person
    {
        private int studyHours;
        private int quantityOfStudents;
        private string gradesJournal;
        private string studyMaterial;

        public Teacher() : base()
        {
            studyHours = 0;
            quantityOfStudents = 0;
            gradesJournal = "";
            studyMaterial = "";
        }

        public Teacher(string teacherName, string subjectName, int studyHours, int quantityOfStudents, string gradesJournal, string studyMaterial) : base(teacherName, subjectName)
        {
            this.studyHours = studyHours;
            this.quantityOfStudents = quantityOfStudents;
            this.gradesJournal = gradesJournal;
            this.studyMaterial = studyMaterial;
        }

        public Teacher(Teacher other) : base(other)
        {
            studyHours = other.studyHours;
            quantityOfStudents = other.quantityOfStudents;
            gradesJournal = other.gradesJournal;
            studyMaterial = other.studyMaterial;
        }

        public string TeacherName
        {
            get { return Name; }
            set { Name = value; }
        }

        public int StudyHours
        {
            get { return studyHours; }
            set { studyHours = value; }
        }

        public int QuantityOfStudents
        {
            get { return quantityOfStudents; }
            set { quantityOfStudents = value; }
        }

        public string GradesJournal
        {
            get { return gradesJournal; }
            set { gradesJournal = value; }
        }

        public string StudyMaterial
        {
            get { return studyMaterial; }
            set { studyMaterial = value; }
        }

        public void IncreaseStudents(int count)
        {
            quantityOfStudents += count;
        }

        public void DecreaseStudents(int count)
        {
            if (quantityOfStudents >= count)
            {
                quantityOfStudents -= count;
            }
        }

        public void ChangeStudyHours(int newHours)
        {
            studyHours = newHours;
        }

        public void GradeStudent(Student student, int grade)
        {
            student.AddGrade(grade);
            WriteGradeToJournal(student, grade);
        }

        public void GiveMaterial(Student student)
        {
            student.DownloadMaterial(studyMaterial);
        }

        public void WriteGradeToJournal(Student student, int grade)
        {
            gradesJournal += "Студент " + student.StudentName + " отримав оцінку " + grade + " з дисципліни " + SubjectName + ".\n";
        }

        public static Teacher operator +(Teacher teacher, int studentsCount)
        {
            teacher.IncreaseStudents(studentsCount);
            return teacher;
        }

        public static Teacher operator -(Teacher teacher, int studentsCount)
        {
            teacher.DecreaseStudents(studentsCount);
            return teacher;
        }

        public static Teacher operator ++(Teacher teacher)
        {
            teacher.StudyHours++;
            return teacher;
        }

        public static Teacher operator --(Teacher teacher)
        {
            if (teacher.StudyHours > 0)
            {
                teacher.StudyHours--;
            }

            return teacher;
        }

        public static bool operator >(Teacher left, Teacher right)
        {
            return left.StudyHours > right.StudyHours;
        }

        public static bool operator <(Teacher left, Teacher right)
        {
            return left.StudyHours < right.StudyHours;
        }

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

        public static bool operator !=(Teacher left, Teacher right)
        {
            return !(left == right);
        }

        public override bool Equals(object obj)
        {
            return obj is Teacher other && this == other;
        }

        public override int GetHashCode()
        {
            return (Name + SubjectName).GetHashCode();
        }

        public override string GetInfo()
        {
            return base.GetInfo() + "\n" +
                   "Навчальне навантаження: " + StudyHours + "\n" +
                   "Кількість студентів: " + QuantityOfStudents + "\n" +
                   "Журнал оцінок: " + GradesJournal + "\n" +
                   "Навчальний матеріал: " + StudyMaterial;
        }

        public void RunDemoScenario(Service service, Student student, StudentGroup group, DiplomaProject project)
        {
            Person teacherPerson = this;
            Person studentPerson = student;
            DiplomaProject projectForOperators = new DiplomaProject(project.ThemeName, project.AlgorithmsCount, project.Difficulty, project.Mark, project.SupervisorName);
            DiplomaProject secondProject = new DiplomaProject("Інформаційна система кафедри", 5, "Висока", 95, "Ковалюк Т.В.");
            Student studentForOperators = new Student("Агапов Олександр", "ООП", new System.Collections.Generic.List<int> { 90, 95 }, 2, "Методичка з ООП", 0);
            Student secondStudent = new Student("Інший студент", "ООП", new System.Collections.Generic.List<int> { 70, 75 }, 2, "Конспект з ООП", 0);
            Teacher teacherForOperators = new Teacher("Ковалюк Т.В.", "ООП", 120, 1, "Журнал оцінок з ООП", "Методичка з ООП");
            Teacher secondTeacher = new Teacher("Інший викладач", "ООП", 80, 1, "Журнал оцінок з ООП", "Конспект з ООП");
            DiplomaProject copiedProject;

            service.PrintToConsole("--- Демонстрація динамічного поліморфізму ---");
            service.PrintToConsole(teacherPerson.GetInfo());
            service.PrintToConsole("");
            service.PrintToConsole(studentPerson.GetInfo());

            studyMaterial = "Демо-матеріал: StudentGroup, індексатор і copy constructor";
            GiveMaterial(student);
            GradeStudent(student, 97);

            service.PrintToConsole("");
            service.PrintToConsole("--- Базові предметні дії ---");
            service.PrintToConsole("Викладач передав навчальний матеріал студенту.");
            service.PrintToConsole("Викладач виставив студенту оцінку 97.");
            service.PrintToConsole("Поточний рейтинг студента: " + student.CalculateRating());

            service.PrintToConsole("");
            service.PrintToConsole("--- Демонстрація статичного поліморфізму: перевантаження операторів ---");

            service.PrintToConsole("");
            service.PrintToConsole("Оператори DiplomaProject:");
            service.PrintToConsole("Початковий project1: " + projectForOperators.GetInfo());
            service.PrintToConsole("Початковий project2: " + secondProject.GetInfo());
            projectForOperators = projectForOperators + 2;
            service.PrintToConsole("Після project1 + 2: " + projectForOperators.GetInfo());
            projectForOperators = projectForOperators - 1;
            service.PrintToConsole("Після project1 - 1: " + projectForOperators.GetInfo());
            projectForOperators++;
            service.PrintToConsole("Після project1++: " + projectForOperators.GetInfo());
            projectForOperators--;
            service.PrintToConsole("Після project1--: " + projectForOperators.GetInfo());
            service.PrintToConsole("project1 > project2: " + (projectForOperators > secondProject));
            service.PrintToConsole("project1 < project2: " + (projectForOperators < secondProject));
            service.PrintToConsole("project1 == project2: " + (projectForOperators == secondProject));
            service.PrintToConsole("project1 != project2: " + (projectForOperators != secondProject));
            service.PrintToConsole("project1.Equals(project2): " + projectForOperators.Equals(secondProject));
            service.PrintToConsole("project1.GetHashCode(): " + projectForOperators.GetHashCode());

            service.PrintToConsole("");
            service.PrintToConsole("Оператори Student:");
            service.PrintToConsole("Початковий student1:");
            service.PrintToConsole(studentForOperators.GetInfo());
            service.PrintToConsole("Початковий student2:");
            service.PrintToConsole(secondStudent.GetInfo());
            studentForOperators = studentForOperators + 100;
            service.PrintToConsole("Після student1 + 100:");
            service.PrintToConsole(studentForOperators.GetInfo());
            studentForOperators = studentForOperators - 90;
            service.PrintToConsole("Після student1 - 90:");
            service.PrintToConsole(studentForOperators.GetInfo());
            studentForOperators++;
            service.PrintToConsole("Після student1++:");
            service.PrintToConsole(studentForOperators.GetInfo());
            studentForOperators--;
            service.PrintToConsole("Після student1--:");
            service.PrintToConsole(studentForOperators.GetInfo());
            service.PrintToConsole("student1 > student2: " + (studentForOperators > secondStudent));
            service.PrintToConsole("student1 < student2: " + (studentForOperators < secondStudent));
            service.PrintToConsole("student1 == student2: " + (studentForOperators == secondStudent));
            service.PrintToConsole("student1 != student2: " + (studentForOperators != secondStudent));
            service.PrintToConsole("student1.Equals(student2): " + studentForOperators.Equals(secondStudent));
            service.PrintToConsole("student1.GetHashCode(): " + studentForOperators.GetHashCode());

            service.PrintToConsole("");
            service.PrintToConsole("Оператори Teacher:");
            service.PrintToConsole("Початковий teacher1:");
            service.PrintToConsole(teacherForOperators.GetInfo());
            service.PrintToConsole("Початковий teacher2:");
            service.PrintToConsole(secondTeacher.GetInfo());
            teacherForOperators = teacherForOperators + 3;
            service.PrintToConsole("Після teacher1 + 3:");
            service.PrintToConsole(teacherForOperators.GetInfo());
            teacherForOperators = teacherForOperators - 1;
            service.PrintToConsole("Після teacher1 - 1:");
            service.PrintToConsole(teacherForOperators.GetInfo());
            teacherForOperators++;
            service.PrintToConsole("Після teacher1++:");
            service.PrintToConsole(teacherForOperators.GetInfo());
            teacherForOperators--;
            service.PrintToConsole("Після teacher1--:");
            service.PrintToConsole(teacherForOperators.GetInfo());
            service.PrintToConsole("teacher1 > teacher2: " + (teacherForOperators > secondTeacher));
            service.PrintToConsole("teacher1 < teacher2: " + (teacherForOperators < secondTeacher));
            service.PrintToConsole("teacher1 == teacher2: " + (teacherForOperators == secondTeacher));
            service.PrintToConsole("teacher1 != teacher2: " + (teacherForOperators != secondTeacher));
            service.PrintToConsole("teacher1.Equals(teacher2): " + teacherForOperators.Equals(secondTeacher));
            service.PrintToConsole("teacher1.GetHashCode(): " + teacherForOperators.GetHashCode());

            service.PrintToConsole("");
            service.PrintToConsole("--- Демонстрація StudentGroup та індексатора ---");
            service.PrintToConsole("Кількість студентів у групі: " + group.Count);
            service.PrintToConsole("group[0]:");
            service.PrintToConsole(group[0].GetInfo());
            service.PrintToConsole("group[1]:");
            service.PrintToConsole(group[1].GetInfo());
            group[1] = new Student("Замінений студент", "ООП", new System.Collections.Generic.List<int> { 88, 92 }, 2, "Новий конспект", 0);
            service.PrintToConsole("Після заміни group[1]:");
            service.PrintToConsole(group[1].GetInfo());

            try
            {
                service.PrintToConsole("Спроба звернення до group[10]:");
                service.PrintToConsole(group[10].GetInfo());
            }
            catch (IndexOutOfRangeException ex)
            {
                service.PrintToConsole("Помилка індексатора: " + ex.Message);
            }

            service.PrintToConsole("");
            service.PrintToConsole("--- Демонстрація конструктора копії DiplomaProject ---");
            copiedProject = new DiplomaProject(project);
            service.PrintToConsole("Оригінал: " + project.GetInfo());
            service.PrintToConsole("Копія після створення: " + copiedProject.GetInfo());
            copiedProject.ThemeName = "Модифікована тема копії";
            copiedProject.Mark = 75;
            service.PrintToConsole("Оригінал після змін копії: " + project.GetInfo());
            service.PrintToConsole("Копія після змін: " + copiedProject.GetInfo());

            service.WriteToFile(service.AppendProtocol(BuildReport(student, group, project)));
            service.SaveProtocolToFile("lab5_v3_protocol.txt");
            service.PrintToConsole("Демонстраційний звіт і протокол сформовано.");
        }

        public void RunScenario(Service service, Menu menu, Student student, StudentGroup group, DiplomaProject project)
        {
            bool isRunning = true;
            int command;

            while (isRunning)
            {
                menu.PrintOptions(service);
                command = menu.ReadCommand(service);

                switch (command)
                {
                    case 1:
                        ShowInformation(service, student, group, project);
                        break;
                    case 2:
                        ChangeTeacherHoursFromInput(service);
                        break;
                    case 3:
                        GiveMaterialToStudentFromInput(service, student);
                        break;
                    case 4:
                        GradeStudentFromInput(service, student);
                        break;
                    case 5:
                        SaveData(service, student, group, project);
                        break;
                    case 6:
                        ShowGroupInformation(service, group);
                        break;
                    case 0:
                        isRunning = false;
                        service.PrintToConsole("Програму завершено");
                        break;
                    default:
                        service.PrintToConsole("Невідома команда");
                        break;
                }
            }
        }

        private void ShowInformation(Service service, Student student, StudentGroup group, DiplomaProject project)
        {
            service.PrintToConsole("\n--- Дані викладача ---");
            service.PrintToConsole(GetInfo());
            service.PrintToConsole("\n--- Дані студента ---");
            service.PrintToConsole(student.GetInfo());
            service.PrintToConsole("\n--- Дані групи ---");
            service.PrintToConsole(group.GetInfo());
            service.PrintToConsole("\n--- Дані дипломного проєкту ---");
            service.PrintToConsole(project.GetInfo());
        }

        private void ShowGroupInformation(Service service, StudentGroup group)
        {
            service.PrintToConsole("\n--- Склад групи ---");
            service.PrintToConsole(group.GetInfo());
        }

        private void ChangeTeacherHoursFromInput(Service service)
        {
            int newHours = ReadNumberInRange(service, "Введіть нову кількість годин навчального навантаження", 0, 300);

            ChangeStudyHours(newHours);
            service.PrintToConsole("Години успішно змінено");
        }

        private void GiveMaterialToStudentFromInput(Service service, Student student)
        {
            string material = ReadNotEmptyText(service, "Введіть назву матеріалу");

            studyMaterial = material;
            GiveMaterial(student);
            service.PrintToConsole("Матеріал передано студенту");
        }

        private void GradeStudentFromInput(Service service, Student student)
        {
            int grade = ReadNumberInRange(service, "Введіть оцінку студента", 0, 100);

            GradeStudent(student, grade);
            service.PrintToConsole("Оцінку виставлено і записано в журнал");
        }

        private void SaveData(Service service, Student student, StudentGroup group, DiplomaProject project)
        {
            service.WriteToFile(service.AppendProtocol(BuildReport(student, group, project)));
            service.PrintToConsole("Дані збережено у файл");
        }

        private string BuildReport(Student student, StudentGroup group, DiplomaProject project)
        {
            string report = "--- ЗВІТ ПРО ОСВІТНІЙ ПРОЦЕС ---\n";

            report += "Викладач:\n" + GetInfo() + "\n";
            report += "\nСтудент:\n" + student.GetInfo() + "\n";
            report += "\nГрупа:\n" + group.GetInfo() + "\n";
            report += "\nДипломний проєкт:\n" + project.GetInfo() + "\n";

            return report;
        }

        private int ReadNumberInRange(Service service, string message, int min, int max)
        {
            int number;

            while (true)
            {
                service.PrintToConsole(message + " (" + min + "-" + max + "):");

                if (int.TryParse(service.ReadFromConsole(), out number))
                {
                    if (number >= min && number <= max)
                    {
                        return number;
                    }
                }

                service.PrintToConsole("Некоректне введення. Введіть ціле число в межах від " + min + " до " + max + ".");
            }
        }

        private string ReadNotEmptyText(Service service, string message)
        {
            string text;

            while (true)
            {
                service.PrintToConsole(message + ":");
                text = service.ReadFromConsole();

                if (!string.IsNullOrWhiteSpace(text))
                {
                    return text;
                }

                service.PrintToConsole("Поле не може бути порожнім. Введіть текст ще раз.");
            }
        }
    }
}
