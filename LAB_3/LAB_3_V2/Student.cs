using System.Collections.Generic;

namespace lab3agapov_v1
{
    /// <summary>
    /// Клас Student описує студента другої версії лабораторної роботи.
    /// Крім звичайних навчальних даних, студент має вкладений дипломний проєкт.
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
        /// Кількість виконаних студентом робіт.
        /// </summary>
        private int tasksDone;
        /// <summary>
        /// Матеріал, отриманий студентом від викладача.
        /// </summary>
        private string downloadedMaterial;
        /// <summary>
        /// Середній рейтинг студента.
        /// </summary>
        private double rating;
        /// <summary>
        /// Дипломний проєкт, який належить студенту.
        /// </summary>
        private DiplomaProject diploma;

        /// <summary>
        /// Конструктор за замовчуванням створює студента з порожніми значеннями
        /// та новим порожнім дипломним проєктом.
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
        /// Конструктор з параметрами створює студента з повним набором навчальних даних.
        /// </summary>
        /// <param name="studentName">Повне ім'я студента.</param>
        /// <param name="subjectName">Назва дисципліни.</param>
        /// <param name="gradesList">Список оцінок.</param>
        /// <param name="tasksDone">Кількість виконаних робіт.</param>
        /// <param name="downloadedMaterial">Отриманий навчальний матеріал.</param>
        /// <param name="rating">Початковий рейтинг.</param>
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
        /// Конструктор копії створює нового студента з даними іншого студента.
        /// Список оцінок і дипломний проєкт копіюються окремо.
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
        /// Властивість для читання та зміни назви дисципліни.
        /// </summary>
        public string SubjectName
        {
            get { return subjectName; }
            set { subjectName = value; }
        }

        /// <summary>
        /// Властивість для доступу до списку оцінок.
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
        /// Властивість для читання та зміни отриманого матеріалу.
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
        /// Додає оцінку студенту і збільшує кількість виконаних робіт.
        /// </summary>
        /// <param name="grade">Оцінка, яку отримав студент.</param>
        public void AddGrade(int grade)
        {
            gradesList.Add(grade);
            tasksDone += 1;
        }

        /// <summary>
        /// Повертає всі оцінки студента у вигляді одного текстового рядка.
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
        /// Розраховує середній рейтинг студента, записує його в поле rating і повертає результат.
        /// </summary>
        /// <returns>Поточний рейтинг студента.</returns>
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
        /// Зберігає навчальний матеріал, отриманий студентом від викладача.
        /// </summary>
        /// <param name="material">Текст або назва навчального матеріалу.</param>
        public void DownloadMaterial(string material)
        {
            downloadedMaterial = material;
        }

        /// <summary>
        /// Вкладений клас DiplomaProject описує дипломний проєкт студента:
        /// тему, кількість методів, складність, оцінку та керівника.
        /// </summary>
        public class DiplomaProject
        {
            /// <summary>
            /// Назва теми дипломного проєкту.
            /// </summary>
            private string themeName;
            /// <summary>
            /// Кількість методів у дипломному проєкті.
            /// </summary>
            private int methodsCount;
            /// <summary>
            /// Загальна складність теми.
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
            /// Конструктор за замовчуванням створює порожній дипломний проєкт.
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
            /// Конструктор з параметрами створює дипломний проєкт з усіма характеристиками.
            /// </summary>
            /// <param name="themeName">Назва теми.</param>
            /// <param name="methodsCount">Кількість методів.</param>
            /// <param name="themeComplexity">Сумарна складність теми.</param>
            /// <param name="grade">Оцінка за диплом.</param>
            /// <param name="supervisorName">Ім'я керівника.</param>
            public DiplomaProject(string themeName, int methodsCount, int themeComplexity, int grade, string supervisorName)
            {
                this.themeName = themeName;
                this.methodsCount = methodsCount;
                this.themeComplexity = themeComplexity;
                this.grade = grade;
                this.supervisorName = supervisorName;
            }

            /// <summary>
            /// Конструктор копії створює дипломний проєкт з даними іншого дипломного проєкту.
            /// </summary>
            /// <param name="other">Дипломний проєкт, який копіюється.</param>
            public DiplomaProject(DiplomaProject other)
            {
                themeName = other.themeName;
                methodsCount = other.methodsCount;
                themeComplexity = other.themeComplexity;
                grade = other.grade;
                supervisorName = other.supervisorName;
            }

            /// <summary>
            /// Властивість для читання та зміни назви теми.
            /// </summary>
            public string ThemeName
            {
                get { return themeName; }
                set { themeName = value; }
            }

            /// <summary>
            /// Властивість для читання та зміни кількості методів.
            /// </summary>
            public int MethodsCount
            {
                get { return methodsCount; }
                set { methodsCount = value; }
            }

            /// <summary>
            /// Властивість для читання та зміни складності теми.
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
            /// Властивість для читання та зміни імені керівника.
            /// </summary>
            public string SupervisorName
            {
                get { return supervisorName; }
                set { supervisorName = value; }
            }

            /// <summary>
            /// Обирає тему дипломного проєкту з файлу за ключовим словом, яке вводить користувач.
            /// </summary>
            /// <param name="service">Сервіс для читання файлу та роботи з консоллю.</param>
            /// <param name="themesFilePath">Шлях до файлу зі списком тем.</param>
            public void ChooseTheme(Service service, string themesFilePath)
            {
                string[] themes = service.ReadAllLines(themesFilePath);
                string keyword;
                int i;
                bool isFound = false;

                if (themes.Length == 0)
                {
                    service.PrintToConsole("Файл з темами порожній або не знайдений. Неможливо обрати тему.");
                    return;
                }

                while (!isFound)
                {
                    service.PrintToConsole("Введіть непорожнє ключове слово для пошуку теми дипломного проєкту:");
                    keyword = service.ReadFromConsole();

                    if (string.IsNullOrWhiteSpace(keyword))
                    {
                        service.PrintToConsole("Ключове слово не може бути порожнім.");
                    }
                    else
                    {
                        for (i = 0; i < themes.Length; i++)
                        {
                            if (themes[i].Contains(keyword))
                            {
                                themeName = themes[i];
                                isFound = true;
                                service.PrintToConsole("Обрана тема: " + themeName);
                                break;
                            }
                        }

                        if (!isFound)
                        {
                            service.PrintToConsole("Тему за таким ключовим словом не знайдено. Спробуйте інше слово.");
                        }
                    }
                }
            }

            /// <summary>
            /// Визначає загальну складність дипломного проєкту через введення складності кожного методу.
            /// </summary>
            /// <param name="service">Сервіс для введення чисел і показу повідомлень.</param>
            public void DetermineComplexity(Service service)
            {
                int i;
                int currentComplexity;
                int sum = 0;
                bool isCorrect;

                isCorrect = false;
                while (!isCorrect)
                {
                    service.PrintToConsole("Введіть кількість реалізованих методів (1-20):");

                    if (int.TryParse(service.ReadFromConsole(), out methodsCount))
                    {
                        if (methodsCount >= 1 && methodsCount <= 20)
                        {
                            isCorrect = true;
                        }
                        else
                        {
                            service.PrintToConsole("Кількість методів має бути в межах від 1 до 20.");
                        }
                    }
                    else
                    {
                        service.PrintToConsole("Некоректне введення. Введіть ціле число.");
                    }
                }

                for (i = 0; i < methodsCount; i++)
                {
                    isCorrect = false;

                    while (!isCorrect)
                    {
                        service.PrintToConsole("Введіть складність методу номер " + (i + 1) + " (1-10):");

                        if (int.TryParse(service.ReadFromConsole(), out currentComplexity))
                        {
                            if (currentComplexity >= 1 && currentComplexity <= 10)
                            {
                                sum += currentComplexity;
                                isCorrect = true;
                            }
                            else
                            {
                                service.PrintToConsole("Складність одного методу має бути в межах від 1 до 10.");
                            }
                        }
                        else
                        {
                            service.PrintToConsole("Некоректне введення. Введіть ціле число.");
                        }
                    }
                }

                themeComplexity = sum;
                service.PrintToConsole("Загальна складність теми: " + themeComplexity);
            }

            /// <summary>
            /// Визначає оцінку за дипломний проєкт на основі сумарної складності теми.
            /// </summary>
            public void DetermineGrade()
            {
                if (themeComplexity > 50)
                {
                    grade = 100;
                }
                else
                {
                    grade = 75;
                }
            }
        }
    }
}
