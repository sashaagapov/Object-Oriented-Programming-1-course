using System;

namespace lab4agapov_v2
{
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

        public override string GetInfo()
        {
            string info = base.GetInfo();

            info += "\nНавчальне навантаження: " + studyHours;
            info += "\nКількість студентів: " + quantityOfStudents;
            info += "\nНавчальний матеріал: " + studyMaterial;
            info += "\nЖурнал оцінок:\n" + gradesJournal;

            return info;
        }

        public void RunDemoScenario(Service service, Student student)
        {
            Person teacherAsPerson = this;
            Person studentAsPerson = student;

            service.PrintToConsole("\n--- Demo-сценарій V2 ---");
            service.PrintToConsole("У V2 клас Person є abstract, тому new Person(...) створити не можна.");
            service.PrintToConsole("Teacher через посилання Person:\n" + teacherAsPerson.GetInfo());
            service.PrintToConsole("Student через посилання Person:\n" + studentAsPerson.GetInfo());

            studyMaterial = "Демо-матеріал: abstract Person і спадкування";
            GiveMaterial(student);
            service.PrintToConsole("Викладач передав навчальний матеріал студенту.");

            GradeStudent(student, 96);
            service.PrintToConsole("Викладач виставив студенту оцінку 96.");
            service.PrintToConsole("Поточний рейтинг студента: " + student.CalculateRating());
            service.PrintToConsole("--- Demo-сценарій завершено. Далі доступне меню. ---");
        }

        public void RunScenario(Service service, Menu menu, Student student)
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
                        ShowInformation(service, student);
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
                        SaveData(service, student);
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

        private void ShowInformation(Service service, Student student)
        {
            service.PrintToConsole("\n--- Дані викладача ---");
            service.PrintToConsole(GetInfo());
            service.PrintToConsole("\n--- Дані студента ---");
            service.PrintToConsole(student.GetInfo());
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

        private void SaveData(Service service, Student student)
        {
            service.WriteToFile(service.AppendProtocol(BuildReport(student)));
            service.PrintToConsole("Дані збережено у файл");
        }

        private string BuildReport(Student student)
        {
            string report = "--- ЗВІТ ПРО ОСВІТНІЙ ПРОЦЕС ---\n";

            report += "Викладач:\n" + GetInfo() + "\n";
            report += "\nСтудент:\n" + student.GetInfo() + "\n";

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
