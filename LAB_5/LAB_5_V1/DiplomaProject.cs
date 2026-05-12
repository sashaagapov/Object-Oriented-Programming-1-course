namespace lab5agapov_v1
{
    /// <summary>
    /// Описує дипломний проєкт, з яким пов'язані викладач і студент.
    /// </summary>
    public class DiplomaProject
    {
        /// <summary>
        /// Назва теми дипломного проєкту.
        /// </summary>
        public string ThemeName { get; set; }

        /// <summary>
        /// Кількість алгоритмів, які реалізовано в роботі.
        /// </summary>
        public int AlgorithmsCount { get; set; }

        /// <summary>
        /// Текстовий рівень складності проєкту.
        /// </summary>
        public string Difficulty { get; set; }

        /// <summary>
        /// Поточна оцінка за дипломний проєкт.
        /// </summary>
        public int Mark { get; set; }

        /// <summary>
        /// ПІБ керівника дипломного проєкту.
        /// </summary>
        public string SupervisorName { get; set; }

        /// <summary>
        /// Створює порожній дипломний проєкт із початковими значеннями.
        /// </summary>
        public DiplomaProject()
        {
            ThemeName = "";
            AlgorithmsCount = 0;
            Difficulty = "";
            Mark = 0;
            SupervisorName = "";
        }

        /// <summary>
        /// Створює дипломний проєкт із заданими параметрами.
        /// </summary>
        /// <param name="themeName">Назва теми.</param>
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
        /// Повертає повну інформацію про дипломний проєкт одним рядком.
        /// </summary>
        /// <returns>Текстове представлення полів об'єкта.</returns>
        public string GetInfo()
        {
            return "Theme: " + ThemeName + ", Algorithms: " + AlgorithmsCount + ", Difficulty: " + Difficulty + ", Mark: " + Mark + ", Supervisor: " + SupervisorName;
        }
    }
}
