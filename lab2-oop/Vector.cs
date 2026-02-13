using System;
using System.Globalization;
namespace lab2agapov;

public class Vector
{
    private readonly int[] _array;
    private readonly int _n;

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

    public int[] GetArray()
    {
        return _array;
    }

    public void SortArray()
    {
        QuickSort(0, _n - 1);
        
    }
    public void QuickSort(int low,int high)
    {
        if(low > high)
        {
            return;//base case
        }
        int pivot = Partition(low,high);
        QuickSort(low,pivot - 1);
        QuickSort(pivot + 1,high);
    }
    public int Partition(int low,int high)
    {
        int pivot = _array[high];
        int i = low - 1;
        for (int j = low;j <= high - 1;j ++)
        {
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
   
   public void EratosthenesSieve(int start, int end)
{
    bool[] isPrime = new bool[end + 1];
    
    for (int i = 0; i <= end; i++)
    {
        isPrime[i] = true;
    }

    isPrime[0] = false;
    isPrime[1] = false;

    int limit = (int)Math.Sqrt(end);

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
