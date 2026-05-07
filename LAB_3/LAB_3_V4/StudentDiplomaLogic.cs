namespace lab3agapov_v1
{
    /// <summary>
    /// Ця частина класу Student містить поведінку, пов'язану з дипломним проєктом.
    /// Такий поділ потрібний для третьої версії лабораторної роботи з partial-класами.
    /// </summary>
    public partial class Student
    {
        /// <summary>
        /// Ця частина вкладеного класу DiplomaProject містить алгоритми вибору теми,
        /// визначення складності та виставлення оцінки.
        /// </summary>
        public partial class DiplomaProject
        {
            /// <summary>
            /// Обирає тему дипломного проєкту з текстового файлу за ключовим словом, яке вводить користувач.
            /// Пошук виконується простим циклом по рядках файлу.
            /// </summary>
            /// <param name="service">Сервіс для читання файлу, введення з консолі та виведення повідомлень.</param>
            /// <param name="themesFilePath">Шлях до файлу зі списком тем дипломних проєктів.</param>
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
            /// Кількість методів і складність кожного методу перевіряються простими умовами.
            /// </summary>
            /// <param name="service">Сервіс, через який відбувається введення чисел і показ підказок користувачу.</param>
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
                                sum = sum + currentComplexity;
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
            /// Визначає оцінку за дипломний проєкт на основі вже обчисленої сумарної складності теми.
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
