namespace lab3agapov_v2;

/// <summary>
/// Часткова частина класу Student. Виділяє окрему функціональність у самостійний файл без зміни загальної моделі класу.
/// </summary>
public partial class Student
{
    /// <summary>
    /// Часткова частина вкладеного класу DiplomaProject. Містить логіку, винесену в окремий файл для кращої структуризації лабораторної.
    /// </summary>
    public partial class DiplomaProject
    {
        /// <summary>
        /// Метод CalculateDifficulty, який обчислює складність теми дипломного 
        /// проекту на основі кількості реалізованих алгоритмів та їх складності.
        /// </summary>
        /// <returns>Повертає загальну складність теми</returns>
        public int CalculateDifficulty()
        {
            int inputAlgorithms = 0; // Змінили назву локальної змінної, щоб не було конфлікту з полем
            int totalDifficulty = 0;

            Console.WriteLine("Скільки алгоритмів реалізовано в дипломі: ");
            while (!int.TryParse(Console.ReadLine(), out inputAlgorithms))
            {
                Console.WriteLine("Помилка.Введіть число.");
            }

            numOfCompletedAlgorithms = inputAlgorithms;

            for (int i = 0; i < inputAlgorithms; i++)
            {
                Console.WriteLine($"Введіть складність алгоритму {i + 1}(від 1 до 10): ");
                int currentDificulty;
                while (!int.TryParse(Console.ReadLine(), out currentDificulty))
                {
                    Console.WriteLine("Помилка.Введіть число.");
                }
                totalDifficulty += currentDificulty;
            }

            dificultyOfTheme = totalDifficulty;
            return dificultyOfTheme;
        }

        /// <summary>
        /// Метод AssignMark, який призначає оцінку студенту на основі 
        /// складності теми дипломного проекту.
        /// </summary>
        public void AssignMark()
        {
            int curMark = 0;
            curMark = dificultyOfTheme * 4;
            if (curMark >= 100)
            {
                mark = 100;
            }
            else
            {
                mark = curMark;
            }
        }
    }
}
