namespace lab5agapov_v2
{
    /// <summary>
    /// Описує дипломний проєкт студента та операції порівняння/зміни для нього.
    /// </summary>
    public class DiplomaProject
    {
        /// <summary>
        /// Назва теми дипломної роботи.
        /// </summary>
        public string ThemeName { get; set; }

        /// <summary>
        /// Кількість реалізованих алгоритмів.
        /// </summary>
        public int AlgorithmsCount { get; set; }

        /// <summary>
        /// Рівень складності (Низька/Середня/Висока).
        /// </summary>
        public string Difficulty { get; set; }

        /// <summary>
        /// Підсумкова оцінка дипломного проєкту.
        /// </summary>
        public int Mark { get; set; }

        /// <summary>
        /// ПІБ наукового керівника.
        /// </summary>
        public string SupervisorName { get; set; }

        /// <summary>
        /// Створює порожній дипломний проєкт із типовими значеннями.
        /// </summary>
        public DiplomaProject()
        {
            ThemeName = "";
            AlgorithmsCount = 0;
            Difficulty = "Низька";
            Mark = 0;
            SupervisorName = "";
        }

        /// <summary>
        /// Створює дипломний проєкт із переданими даними.
        /// </summary>
        /// <param name="themeName">Тема роботи.</param>
        /// <param name="algorithmsCount">Кількість алгоритмів.</param>
        /// <param name="difficulty">Рівень складності.</param>
        /// <param name="mark">Оцінка.</param>
        /// <param name="supervisorName">ПІБ керівника.</param>
        public DiplomaProject(string themeName, int algorithmsCount, string difficulty, int mark, string supervisorName)
        {
            ThemeName = themeName;
            AlgorithmsCount = algorithmsCount;
            Difficulty = difficulty;
            Mark = mark;
            SupervisorName = supervisorName;
        }

        /// <summary>
        /// Повертає всі дані дипломного проєкту одним текстовим рядком.
        /// </summary>
        /// <returns>Рядок з основними атрибутами проєкту.</returns>
        public string GetInfo()
        {
            return "Тема: " + ThemeName +
                   ", Кількість алгоритмів: " + AlgorithmsCount +
                   ", Складність: " + Difficulty +
                   ", Оцінка: " + Mark +
                   ", Керівник: " + SupervisorName;
        }

        /// <summary>
        /// Збільшує кількість реалізованих алгоритмів на задане значення.
        /// </summary>
        /// <param name="project">Проєкт, який змінюється.</param>
        /// <param name="value">Скільки алгоритмів додати.</param>
        /// <returns>Той самий об'єкт після зміни.</returns>
        public static DiplomaProject operator +(DiplomaProject project, int value)
        {
            // Через оператор + моделюємо додавання реалізованих частин роботи.
            project.AlgorithmsCount += value;
            return project;
        }

        /// <summary>
        /// Зменшує кількість реалізованих алгоритмів на задане значення.
        /// </summary>
        /// <param name="project">Проєкт, який змінюється.</param>
        /// <param name="value">Скільки алгоритмів відняти.</param>
        /// <returns>Той самий об'єкт після зміни.</returns>
        public static DiplomaProject operator -(DiplomaProject project, int value)
        {
            // Не даємо значенню піти в мінус, щоб стан проєкту лишався коректним.
            project.AlgorithmsCount -= value;

            if (project.AlgorithmsCount < 0)
            {
                project.AlgorithmsCount = 0;
            }

            return project;
        }

        /// <summary>
        /// Підвищує рівень складності дипломного проєкту на один крок.
        /// </summary>
        /// <param name="project">Проєкт, який змінюється.</param>
        /// <returns>Той самий об'єкт після зміни.</returns>
        public static DiplomaProject operator ++(DiplomaProject project)
        {
            // Рухаємося по фіксованій шкалі складності зліва направо.
            if (project.Difficulty == "Низька")
            {
                project.Difficulty = "Середня";
            }
            else if (project.Difficulty == "Середня")
            {
                project.Difficulty = "Висока";
            }

            return project;
        }

        /// <summary>
        /// Знижує рівень складності дипломного проєкту на один крок.
        /// </summary>
        /// <param name="project">Проєкт, який змінюється.</param>
        /// <returns>Той самий об'єкт після зміни.</returns>
        public static DiplomaProject operator --(DiplomaProject project)
        {
            // Рухаємося по тій самій шкалі у зворотному напрямку.
            if (project.Difficulty == "Висока")
            {
                project.Difficulty = "Середня";
            }
            else if (project.Difficulty == "Середня")
            {
                project.Difficulty = "Низька";
            }

            return project;
        }

        /// <summary>
        /// Порівнює два дипломні проєкти за оцінкою.
        /// </summary>
        /// <param name="left">Лівий операнд.</param>
        /// <param name="right">Правий операнд.</param>
        /// <returns><c>true</c>, якщо оцінка лівого більша.</returns>
        public static bool operator >(DiplomaProject left, DiplomaProject right)
        {
            // Порівнюємо саме Mark, бо в методичці це основний критерій для >.
            return left.Mark > right.Mark;
        }

        /// <summary>
        /// Порівнює два дипломні проєкти за оцінкою.
        /// </summary>
        /// <param name="left">Лівий операнд.</param>
        /// <param name="right">Правий операнд.</param>
        /// <returns><c>true</c>, якщо оцінка лівого менша.</returns>
        public static bool operator <(DiplomaProject left, DiplomaProject right)
        {
            return left.Mark < right.Mark;
        }

        /// <summary>
        /// Перевіряє рівність двох дипломних проєктів за темою і керівником.
        /// </summary>
        /// <param name="left">Лівий операнд.</param>
        /// <param name="right">Правий операнд.</param>
        /// <returns><c>true</c>, якщо атрибути рівності збігаються.</returns>
        public static bool operator ==(DiplomaProject left, DiplomaProject right)
        {
            // Спочатку обробляємо випадок одного й того самого посилання.
            if (ReferenceEquals(left, right))
            {
                return true;
            }

            // Якщо один з операндів null, рівності бути не може.
            if (left is null || right is null)
            {
                return false;
            }

            return left.ThemeName == right.ThemeName &&
                   left.SupervisorName == right.SupervisorName;
        }

        /// <summary>
        /// Перевіряє нерівність двох дипломних проєктів.
        /// </summary>
        /// <param name="left">Лівий операнд.</param>
        /// <param name="right">Правий операнд.</param>
        /// <returns><c>true</c>, якщо об'єкти не рівні.</returns>
        public static bool operator !=(DiplomaProject left, DiplomaProject right)
        {
            return !(left == right);
        }

        /// <summary>
        /// Перевизначений порівнювач для роботи з API .NET, що використовує Equals.
        /// </summary>
        /// <param name="obj">Об'єкт для порівняння.</param>
        /// <returns><c>true</c>, якщо об'єкти вважаються рівними.</returns>
        public override bool Equals(object obj)
        {
            // Перевизначаємо Equals, оскільки перевантажили оператор ==.
            return obj is DiplomaProject other && this == other;
        }

        /// <summary>
        /// Повертає хеш-код для об'єкта на основі полів рівності.
        /// </summary>
        /// <returns>Ціле число-хеш.</returns>
        public override int GetHashCode()
        {
            // Хеш будуємо з тих самих полів, які перевіряються в ==.
            return (ThemeName + SupervisorName).GetHashCode();
        }
    }
}
