using System;
using System.Globalization;
namespace lab2agapov;

/// <summary>
/// Клас для роботи з одновимірним масивом. Забезпечує функціональність сортування, пошуку та фільтрації простих чисел.
/// </summary>
public class Vector
{
    private readonly int[] _array;
    private readonly int _n;

    /// <summary>
    /// Конструктор класу Vector. Ініціалізує масив розміром n з випадковими числами від 1 до 100.
    /// </summary>
    /// <param name="n">Розмір масиву.</param>
    public Vector(int n)
    {
        _n = n;
        _array = new int[n];
        Random rand = new Random();
        for (int i = 0; i < _n; i++)
        {
            _array[i] = rand.Next(1, 101);
        }
    }

    /// <summary>
    /// Повертає посилання на внутрішній масив.
    /// </summary>
    /// <returns>Масив цілих чисел.</returns>
    public int[] GetArray()
    {
        return _array;
    }

    /// <summary>
    /// Сортує масив за спаданням, використовуючи алгоритм QuickSort.
    /// </summary>
    public void SortArray()
    {
        QuickSort(0, _n - 1);
        
    }
    /// <summary>
    /// Рекурсивний метод швидкого сортування (QuickSort). Сортує підмасив від low до high за спаданням.
    /// </summary>
    /// <param name="low">Індекс початку підмасиву.</param>
    /// <param name="high">Індекс кінця підмасиву.</param>
    public void QuickSort(int low,int high)
    {
        if(low > high)
        {
            return; // Базовий випадок
        }
        int pivot = Partition(low,high);
        QuickSort(low,pivot - 1);
        QuickSort(pivot + 1,high);
    }

    /// <summary>
    /// Розділяє масив навколо опорного елемента (pivot) для алгоритму QuickSort.
    /// </summary>
    /// <param name="low">Індекс початку розділу.</param>
    /// <param name="high">Індекс кінця розділу (опорний елемент).</param>
    /// <returns>Індекс опорного елемента після розділу.</returns>
    public int Partition(int low,int high)
    {
        int pivot = _array[high];
        int i = low - 1;
        for (int j = low;j <= high - 1;j ++)
        {
            // Порівнюємо з pivot, сортуємо за спаданням
            if(_array[j] > pivot )
            {
            i++;
            int temp = _array[j];
            _array[j] = _array[i];
            _array[i] = temp;
            }

        }
        i++;
        int tempN = _array[high];
        _array[high]= _array[i];
        _array[i] = tempN;
        return i;
    }
   
    /// <summary>
    /// Знаходить та виводить всі прості числа з масиву, які знаходяться в діапазоні [start; end].
    /// Використовує алгоритм "Решето Ератосфена".
    /// </summary>
    /// <param name="start">Початок діапазону пошуку простих чисел.</param>
    /// <param name="end">Кінець діапазону пошуку простих чисел.</param>
    public void EratosthenesSieve(int start, int end)
{
    // Створюємо массив для позначення простих чисел
    bool[] isPrime = new bool[end + 1];
    
    for (int i = 0; i <= end; i++)
    {
        isPrime[i] = true;
    }

    // 0 і 1 не є простими числами
    isPrime[0] = false;
    isPrime[1] = false;

    int limit = (int)Math.Sqrt(end);

    // Основна логіка решета Ератосфена
    for (int p = 2; p <= limit; p++)
    {
        if (isPrime[p])
        {
            for (int j = p * p; j <= end; j += p)
            {
                isPrime[j] = false;
            }
        }
    }

    Console.WriteLine($"Прості числа в діапазоні [{start} - {end}]:");
    int counter = 0;

    // Виводимо прості числа з нашого масиву, які потрапляють в діапазон
    for (int i = 0; i < _n; i++)
    {
        int num = _array[i];
        if (num >= start && num <= end && isPrime[num])
        {
            Console.Write(num + " ");
            counter++;
        }
    }
    
    Console.WriteLine();

    if (counter == 0)
    {
        Console.WriteLine("В цьому діапазоні простих чисел не знайдено.");
    }
}
    
    /// <summary>
    /// Здійснює бінарний пошук заданого числа у відсортованому масиві.
    /// Вимагає, щоб масив був попередньо відсортований.
    /// </summary>
    /// <param name="target">Число, яке потрібно знайти.</param>
    /// <returns>Індекс елемента, якщо найдено; інакше -1.</returns>
    public int BinarySearch(int target)
    {
        int left = 0;
        int right = _n - 1;
        int mid = 0;
        while(left <= right)
        {
            mid = (right + left)/2;
            if (_array[mid] == target)
            {
                return mid;
            }
            // Масив відсортований у спаданні, тому логіка інвертована
            else if(target > _array[mid])
            {
                right = mid - 1;
            }
            else
            {
                left = mid + 1;
            }
        }
        return -1;
        
    }
    
 
}
