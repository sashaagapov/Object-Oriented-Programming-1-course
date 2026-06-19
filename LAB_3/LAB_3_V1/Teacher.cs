using System;

namespace lab3agapov_v1
{
    /// <summary>
    /// Клас Teacher представляє викладача першої версії лабораторної роботи.
    /// Викладач має навчальне навантаження, матеріал, журнал оцінок і напряму взаємодіє зі студентом.
    /// </summary>
    public class Teacher
    {
        /// <summary>
        /// Повне ім'я викладача.
        /// </summary>
        private string teacherName;
        /// <summary>
        /// Назва дисципліни, яку веде викладач.
        /// </summary>
        private string subjectName;
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
        /// Конструктор з параметрами створює викладача з усіма значеннями полів таблиці 1.1.
        /// </summary>
        /// <param name="teacherName">Повне ім'я викладача.</param>
        /// <param name="subjectName">Назва дисципліни.</param>
        /// <param name="studyHours">Кількість навчальних годин.</param>
        /// <param name="quantityOfStudents">Кількість студентів.</param>
        /// <param name="gradesJournal">Початковий журнал оцінок.</param>
        /// <param name="studyMaterial">Навчальний матеріал.</param>
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
        /// Конструктор копії створює нового викладача з даними іншого об'єкта Teacher.
        /// </summary>
        /// <param name="other">Викладач, з якого копіюються поля.</param>
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
            quantityOfStudents += count;
        }

        /// <summary>
        /// Зменшує кількість студентів, якщо поточна кількість дозволяє це зробити.
        /// </summary>
        /// <param name="count">Кількість студентів, яку потрібно відняти.</param>
        public void DecreaseStudents(int count)
        {
            if (quantityOfStudents >= count)
            {
                quantityOfStudents -= count;
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
        /// Виставляє студенту оцінку через метод студента і записує результат у журнал викладача.
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
            gradesJournal = gradesJournal + "Студент " + student.StudentName + " отримав оцінку " + grade + " з дисципліни " + subjectName + ".\n";
        }

        /// <summary>
        /// Запускає короткий готовий demo-сценарій перед переходом до меню.
        /// </summary>
        /// <param name="service">Сервіс для показу повідомлень.</param>
        /// <param name="student">Студент, з яким працює викладач.</param>
        public void RunDemoScenario(Service service, Student student)
        {
            service.PrintToConsole("\n--- Demo-сценарій V1 ---");
            service.PrintToConsole("Створено викладача: " + teacherName);
            service.PrintToConsole("Створено студента: " + student.StudentName);

            studyMaterial = "Демо-матеріал: класи та інкапсуляція";
            GiveMaterial(student);
            service.PrintToConsole("Викладач передав матеріал студенту.");

            GradeStudent(student, 95);
            service.PrintToConsole("Викладач виставив студенту оцінку 95.");
            service.PrintToConsole("Поточний рейтинг студента: " + student.CalculateRating());
            service.PrintToConsole("--- Demo-сценарій завершено. Далі доступне меню. ---");
        }

        /// <summary>
        /// Запускає інтерактивний предметний сценарій через допоміжне меню.
        /// </summary>
        /// <param name="service">Сервіс для введення, виведення та роботи з файлами.</param>
        /// <param name="menu">Допоміжне меню вибору команд.</param>
        /// <param name="student">Студент, з яким працює викладач.</param>
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
            service.PrintToConsole("\nВикладач: " + teacherName);
            service.PrintToConsole("Дисципліна викладача: " + subjectName);
            service.PrintToConsole("Навчальне навантаження: " + studyHours);
            service.PrintToConsole("Кількість студентів: " + quantityOfStudents);
            service.PrintToConsole("Навчальний матеріал викладача: " + studyMaterial);
            service.PrintToConsole("Журнал оцінок:\n" + gradesJournal);
            service.PrintToConsole("Студент: " + student.StudentName);
            service.PrintToConsole("Дисципліна студента: " + student.SubjectName);
            service.PrintToConsole("Оцінки студента: " + student.ViewGrades());
            service.PrintToConsole("Обсяг виконаних робіт: " + student.TasksDone);
            service.PrintToConsole("Рейтинг студента: " + student.CalculateRating());
            service.PrintToConsole("Отриманий матеріал: " + student.DownloadedMaterial);
        }

        private void ChangeTeacherHoursFromInput(Service service)
        {
            int newHours;

            newHours = ReadNumberInRange(service, "Введіть нову кількість годин навчального навантаження", 0, 300);
            ChangeStudyHours(newHours);
            service.PrintToConsole("Години успішно змінено");
        }

        private void GiveMaterialToStudentFromInput(Service service, Student student)
        {
            string material;

            material = ReadNotEmptyText(service, "Введіть назву матеріалу");
            studyMaterial = material;
            GiveMaterial(student);
            service.PrintToConsole("Матеріал передано студенту");
        }

        private void GradeStudentFromInput(Service service, Student student)
        {
            int grade;

            grade = ReadNumberInRange(service, "Введіть оцінку студента", 0, 100);
            GradeStudent(student, grade);
            service.PrintToConsole("Оцінку виставлено і записано в журнал");
        }

        private void SaveData(Service service, Student student)
        {
            service.WriteToFile(BuildReport(student));
            service.PrintToConsole("Дані успішно оброблені та збережені у файл student_report.txt");
        }

        private string BuildReport(Student student)
        {
            string report = "--- ЗВІТ ПРО ОСВІТНІЙ ПРОЦЕС ---\n";

            report = report + "Викладач: " + teacherName + "\n";
            report = report + "Дисципліна: " + subjectName + "\n";
            report = report + "Навантаження: " + studyHours + " год.\n";
            report = report + "Студентів у групі: " + quantityOfStudents + "\n";
            report = report + "Матеріал: " + studyMaterial + "\n";
            report = report + "Журнал оцінок:\n" + gradesJournal + "\n";
            report = report + "Студент: " + student.StudentName + "\n";
            report = report + "Оцінки: " + student.ViewGrades() + "\n";
            report = report + "Виконано робіт: " + student.TasksDone + "\n";
            report = report + "Рейтинг: " + student.CalculateRating() + "\n";
            report = report + "Матеріал у студента: " + student.DownloadedMaterial + "\n";

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
