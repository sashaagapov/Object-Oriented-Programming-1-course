using System;
using System.Collections.Generic;

namespace Lab3;

public static class CreativeWork
{
    public static void PrintHeader()
    {
        Console.WriteLine(new string('=', 40));
        Console.WriteLine(" ЛАБОРАТОРНА РОБОТА №3 | ГОЛОВНЕ МЕНЮ");
        Console.WriteLine(new string('=', 40));
    }

    public static void QuickSortDescending(int[] arr, int left, int right)
    {
        if (left < right)
        {
            int pivot = Partition(arr, left, right);
            QuickSortDescending(arr, left, pivot - 1);
            QuickSortDescending(arr, pivot + 1, right);
        }
    }

    private static int Partition(int[] arr, int left, int right)
    {
        int pivotValue = arr[right];
        int i = left - 1;
        for (int j = left; j < right; j++)
        {
            if (arr[j] >= pivotValue)
            {
                i++;
                int temp = arr[i];
                arr[i] = arr[j];
                arr[j] = temp;
            }
        }
        int temp1 = arr[i + 1];
        arr[i + 1] = arr[right];
        arr[right] = temp1;
        return i + 1;
    }

    public static int BinarySearchDescending(int[] arr, int target)
    {
        int left = 0;
        int right = arr.Length - 1;

        while (left <= right)
        {
            int mid = left + (right - left) / 2;

            if (arr[mid] == target)
                return mid;

            if (arr[mid] < target)
                right = mid - 1; 
            else
                left = mid + 1;  
        }
        return -1; 
    }

    public static List<int> SieveOfEratosthenes(int maxLimit)
    {
        bool[] isPrime = new bool[maxLimit + 1];
        for (int i = 2; i <= maxLimit; i++) isPrime[i] = true;

        for (int p = 2; p * p <= maxLimit; p++)
        {
            if (isPrime[p])
            {
                for (int i = p * p; i <= maxLimit; i += p)
                    isPrime[i] = false;
            }
        }

        List<int> primes = new List<int>();
        for (int i = 2; i <= maxLimit; i++)
        {
            if (isPrime[i]) primes.Add(i);
        }
        return primes;
    }
}