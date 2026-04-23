namespace lab3agapov;
/// <summary>
/// Статичний клас ScientificPaper, який містить метод SearchReference
///  для пошуку наукових статей за їх унікальними ідентифікаторами.
/// </summary>
public static class ScientificPaper
{
    /// <summary>
    /// Метод SearchReference, який реалізує алгоритм бінарного пошуку для знаходження
    /// наукової статті за її унікальним ідентифікатором
    /// у відсортованому масиві ідентифікаторів. 
    /// </summary>
    /// <param name="identifiers">Відсортований масив унікальних ідентифікаторів наукових статей</param>
    /// <param name="target">Цільовий ідентифікатор для пошуку</param>
    /// <returns>Повертає індекс знайденого ідентифікатора або -1, якщо ідентифікатор не знайдено</returns>
    public static int SearchReference(int[] identifiers, int target)
    {
        int left = 0;
        int right = identifiers.Length - 1;
        while (left <= right)
        {
            int mid = left + (right - left) / 2; // Обчислюємо середину поточного діапазону пошуку.
            if (identifiers[mid] == target)
            {
                return mid;
            }
            else if (identifiers[mid] < target)
            {
                left = mid + 1; // Ціль більша за середній елемент: шукаємо праворуч.
            }
            else
            {
                right = mid - 1; // Ціль менша за середній елемент: шукаємо ліворуч.
            }
        }
        return -1; // Повертаємо -1, якщо жоден індекс не відповідає шуканому ID.
    }
}
