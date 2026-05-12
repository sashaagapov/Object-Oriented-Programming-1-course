namespace lab3agapov_v1
{
    /// <summary>
    /// Статичний клас ScientificPaper містить допоміжну логіку для роботи з науковими статтями.
    /// У четвертій версії лабораторної роботи він демонструє використання статичного класу.
    /// </summary>
    public static class ScientificPaper
    {
        /// <summary>
        /// Виконує класичний ітеративний бінарний пошук ідентифікатора статті у відсортованому масиві.
        /// Метод не використовує готові засоби пошуку, а проходить масив через межі low, high і mid.
        /// </summary>
        /// <param name="idArray">Відсортований масив ідентифікаторів наукових статей.</param>
        /// <param name="targetId">Ідентифікатор статті, який потрібно знайти.</param>
        /// <returns>Індекс знайденого елемента або -1, якщо такого ідентифікатора немає в масиві.</returns>
        public static int BinarySearchPaper(int[] idArray, int targetId)
        {
            int low = 0;
            int high = idArray.Length - 1;
            int mid;

            while (low <= high)
            {
                // Обчислюємо центральний індекс поточного інтервалу пошуку.
                mid = (low + high) / 2;

                if (idArray[mid] == targetId)
                {
                    return mid;
                }

                if (idArray[mid] < targetId)
                {
                    // Шукана ціль праворуч від середини, тому зсуваємо нижню межу.
                    low = mid + 1;
                }
                else
                {
                    // Шукана ціль ліворуч від середини, тому зсуваємо верхню межу.
                    high = mid - 1;
                }
            }

            return -1;
        }
    }
}
