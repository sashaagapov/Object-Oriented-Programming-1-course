namespace lab3agapov;

public partial class Student
{
    public partial class DiplomaProject
    {
        /// <summary>
        /// Метод CalculateDifficulty, який обчислює складність теми дипломного проекту на основі кількості реалізованих алгоритмів та їх складності. Метод запитує у користувача кількість реалізованих алгоритмів, а потім для кожного алгоритму запитує його складність (від 1 до 10). Загальна складність теми обчислюється як сума складностей усіх алгоритмів. Цей метод використовується для визначення загальної складності теми дипломного проекту на основі реалізованих алгоритмів та їх складності.
        /// </summary>
        /// <returns>Повертає загальну складність теми</returns>
        public int CalculateDifficulty()
        {
            int numOfCompletedAlgorithms = 0;
            int totalDifficulty = 0;
            Console.WriteLine("Скільки алгоритмів реалізовано в дипломі: ");
            while (!int.TryParse(Console.ReadLine(), out numOfCompletedAlgorithms))// Якщо введене значення не є цілим числом, виводимо повідомлення про помилку та запитуємо знову
            {
                Console.WriteLine("Помилка.Введіть число.");
            }
            _numOfCompletedAlgorithms = numOfCompletedAlgorithms;
            for (int i = 0; i < numOfCompletedAlgorithms; i++)// Для кожного реалізованого алгоритму запитуємо його складність та додаємо її до загальної складності теми
            {
                Console.WriteLine($"Введіть складність алгоритму {i + 1}(від 1 до 10): ");
                int currentDificulty;
                while (!int.TryParse(Console.ReadLine(), out currentDificulty))
                {
                    Console.WriteLine("Помилка.Введіть число.");
                }
                totalDifficulty += currentDificulty;
            }
            _dificultyOfTheme = totalDifficulty;
            return _dificultyOfTheme;
        }
        /// <summary>
        /// Метод AssignMark, який призначає оцінку студенту на основі складності теми дипломного проекту. Оцінка розраховується як добуток складності теми та коефіцієнта 4. Якщо розрахована оцінка перевищує 100, то вона встановлюється на рівні 100. Цей метод використовується для визначення оцінки студента за його дипломний проект на основі складності вибраної теми.
        /// </summary>
        public void AssignMark()
        {
            int curMark = 0;
            curMark = _dificultyOfTheme * 4;
            if (curMark >= 100)
            {
                _mark = 100;
            }
            else
            {
                _mark = curMark;
            }
        }
    }
}