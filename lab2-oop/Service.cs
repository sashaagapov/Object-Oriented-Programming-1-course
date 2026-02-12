using System;
using System.Numerics;

namespace lab2agapov;
public static class Service
{
    public static int GetMenuChoice()
    {
        Console.WriteLine("\n=========== МЕНЮ ===========");
        Console.WriteLine("1 - Створити новий масив та відсортувати його");
        Console.WriteLine("2 - Знайти прості числа (Ератосфен)");
        Console.WriteLine("3 - Знайти індекс числа (Бінарний пошук)");
        Console.WriteLine("0 - Вихід");
        Console.Write("Ваш вибір: ");

        int choice;
        if (int.TryParse(Console.ReadLine(), out choice))
        {
            return choice;
        }
        return -1; // Якщо ввели дурницю
    }
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
    public static void BinarySearchArray(Vector vector)
    {

        int target = 0;
        int targetIdx = 0;
        string answer;
        do{
        Console.Write("Ввдіть число індекс якого бажаєте знайти: ");
        if (!int.TryParse(Console.ReadLine(),out target))
        {
            Console.WriteLine("Введіть число");
            return;
        }
        targetIdx = vector.BinarySearch(target);
        if (targetIdx != -1)
            {
                Console.Write($"Індекс шуканого елемента: {targetIdx}");
            }
        else
            {
                Console.WriteLine("В масиві не знайдено числа за запитом.Введіть новий елемент ");
            }
        
        Console.WriteLine("Повторити пошук елемента?(натисніть Enter, щоб продовжити, або введіть 'n' чи 'no' для виходу)");
        answer = Console.ReadLine();
        }while(answer != "n" && answer != "no");
        
    }
}
