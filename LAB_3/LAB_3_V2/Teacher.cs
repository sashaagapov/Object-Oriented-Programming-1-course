using System;

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
            quantityOfStudents += count;
        }

        /// <summary>
        /// Зменшує кількість студентів, якщо в поточному стані їх достатньо для такого зменшення.
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

        /// <summary>
        /// Запускає короткий demo-сценарій перед переходом до меню.
        /// </summary>
        public void RunDemoScenario(Service service, Student student)
        {
            service.PrintToConsole("\n--- Demo-сценарій V2 ---");
            service.PrintToConsole("Створено викладача: " + teacherName);
            service.PrintToConsole("Створено студента: " + student.StudentName);

            studyMaterial = "Демо-матеріал: інкапсуляція та вкладені класи";
            GiveMaterial(student);
            service.PrintToConsole("Викладач передав матеріал студенту.");

            GradeStudent(student, 96);
            service.PrintToConsole("Викладач виставив студенту оцінку 96.");
            service.PrintToConsole("Поточний рейтинг студента: " + student.CalculateRating());

            student.Diploma.ThemeName = "Демо-тема: інформаційна система кафедри";
            student.Diploma.MethodsCount = 4;
            student.Diploma.ThemeComplexity = 28;
            EvaluateDiploma(student);
            service.PrintToConsole("Дипломний проєкт оцінено викладачем.");
            service.PrintToConsole("Поточна оцінка за диплом: " + student.Diploma.Grade);
            service.PrintToConsole("--- Demo-сценарій завершено. Далі доступне меню. ---");
        }

        /// <summary>
        /// Запускає інтерактивний предметний сценарій через допоміжне меню.
        /// </summary>
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
                    case 6:
                        WorkWithDiplomaProject(service, student);
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
            service.PrintToConsole("Тема дипломного проєкту: " + student.Diploma.ThemeName);
            service.PrintToConsole("Оцінка за дипломний проєкт: " + student.Diploma.Grade);
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
            service.PrintToConsole("Дані збережено у файл");
        }

        private void WorkWithDiplomaProject(Service service, Student student)
        {
            service.PrintToConsole("--- Робота з дипломним проєктом ---");
            student.Diploma.ChooseTheme(service, "themes.txt");
            student.Diploma.DetermineComplexity(service);
            EvaluateDiploma(student);

            service.PrintToConsole("Тема дипломного проєкту: " + student.Diploma.ThemeName);
            service.PrintToConsole("Складність теми: " + student.Diploma.ThemeComplexity);
            service.PrintToConsole("Оцінка за дипломний проєкт: " + student.Diploma.Grade);
        }

        private string BuildReport(Student student)
        {
            string report = "--- ЗВІТ ПРО ОСВІТНІЙ ПРОЦЕС ---\n";

            report = report + "Викладач: " + teacherName + "\n";
            report = report + "Дисципліна: " + subjectName + "\n";
            report = report + "Навантаження: " + studyHours + " год.\n";
            report = report + "Кількість студентів: " + quantityOfStudents + "\n";
            report = report + "Матеріал викладача: " + studyMaterial + "\n";
            report = report + "Журнал оцінок:\n" + gradesJournal + "\n";
            report = report + "Студент: " + student.StudentName + "\n";
            report = report + "Дисципліна студента: " + student.SubjectName + "\n";
            report = report + "Оцінки: " + student.ViewGrades() + "\n";
            report = report + "Виконано робіт: " + student.TasksDone + "\n";
            report = report + "Рейтинг: " + student.CalculateRating() + "\n";
            report = report + "Матеріал студента: " + student.DownloadedMaterial + "\n";
            report = report + "Тема дипломного проєкту: " + student.Diploma.ThemeName + "\n";
            report = report + "Кількість методів: " + student.Diploma.MethodsCount + "\n";
            report = report + "Складність теми: " + student.Diploma.ThemeComplexity + "\n";
            report = report + "Оцінка за диплом: " + student.Diploma.Grade + "\n";
            report = report + "Керівник: " + student.Diploma.SupervisorName + "\n";

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
