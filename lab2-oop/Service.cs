using System;
using System.Numerics;

namespace lab2agapov;
public static class Service
{
    public static Vector SetSize()
    {
        int n;
        Console.Write("Введіть розмір для масиву: ");
        while(true)
        {
            if(int.TryParse(Console.ReadLine(), out n))
            {
                return new Vector(n);
            }
            else
            {
                Console.WriteLine("Неправильно, введіть число:");
            }
        }
    }

    public static void PrintVector(Vector vector)
    {
        int[] tempArray = vector.GetArray();
        Console.Write("[");
        foreach(int i in tempArray)
        {
            Console.Write($" {i},"); 
        }
        Console.WriteLine("]"); 
    }
    public static void PrintEratosthenes(Vector vector)
    {
        
        Console.WriteLine("Введіть діапазон знаходження простих чисел.");
        int start = 0;
        int end = 0;
        string answer;
        do
        {
        Console.Write("Введіть старт діапазону: ");
        Console.WriteLine();
        if (!int.TryParse(Console.ReadLine(),out start))
        {
            Console.WriteLine("Введіть число");
            return;
        }
        Console.Write("Введіть кінець діапазону: ");
        Console.WriteLine();
          if (!int.TryParse(Console.ReadLine(),out end))
        {
            Console.WriteLine("Введіть число");
            return;
        }
        vector.EratosthenesSieve(start,end);
        Console.WriteLine("Бажаєте спробувати інший діапазон? (натисніть Enter, щоб продовжити, або введіть 'n' чи 'no' для виходу)");
        answer = Console.ReadLine();
        }while(answer != "n" && answer != "no");
    }
}
