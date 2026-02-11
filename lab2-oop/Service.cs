using System;

public class Service
{
    public Vector SetSize()
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

    public void PrintVector(Vector vector)
    {
        int[] tempArray = vector.GetArray();
        Console.Write("[");
        foreach(int i in tempArray)
        {
            Console.Write($" {i},"); 
        }
        Console.WriteLine("]"); 
    }
}