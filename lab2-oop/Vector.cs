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
        if(low >= high)
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
    public void EratosthenesSieve(int start,int end)
    {
        bool[] isPrime = new bool[end+1];
        int counter = 0;
        for (int i =0 ;i <= end; i++)
        {
            isPrime[i] = true;
            
        }
       isPrime[0] = false;
       isPrime[1] = false;
        for(int p = 2;p * p <= end; p++)
        {
            if(isPrime[p])
            {
                for(int j = 2 * p; j <= end; j += p)
                {
                    isPrime[j] = false;
                }
            }
        }
        Console.WriteLine($"Прості числа в діапазоні [{start} - {end}]:");
        for(int i = 0;i < _n;i++)
        {
            
            int num = _array[i];
            if(num >= start && num <= end && isPrime[num] )
            {
                counter++;
                Console.Write(num + " ");
            }
        }
        if(counter == 0)
        {
            Console.WriteLine($"Нема натуральних чисель в діапазоні [{start} - {end}]:");
        }
        Console.WriteLine();
    }
    
 
}
