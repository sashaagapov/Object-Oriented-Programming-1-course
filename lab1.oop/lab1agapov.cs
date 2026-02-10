using System;
using System.Text;

namespace lab1agapov
{
    class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Завдання 1: Анкетні дані ===");
            StudentInfo();

            Console.WriteLine("\n=== Завдання 2: Обчислення поліному ===");
            CalculatePolynomial();

            // Щоб консоль не закрилася одразу після виконання
            Console.WriteLine("\nНатисніть будь-яку клавішу для виходу...");
            Console.ReadKey();
    }
    static void StudentInfo()
        {
            ConsoleWriteLine("---------------------------------------------------");
            Console.WriteLine("Агапов Олександр,ІПЗ-11(1),лабораторна робота №1");
            ConsoleWriteLine("---------------------------------------------------");
        }
        static void CalculatePolynomial()
        {
            double coefficientA = 2.5;
            double coefficientB = 1.2;
            double coefficientC = -4.0;
            double freeTermD = 10.5;
            double resultP = 0;
            Console.WriteLine("Введіть значення x: ");

            double argumentX = double.Parse(Console.WriteLine());
            Console.WriteLine("Рівняння:  p = a*x^5 − 1 / b*x^4+c*x + d.");

            resultP = coefficientA * Math.Pow(argumentX,5) - (1 /coefficientB * Math.Pow(argumentX, 4 )) + coefficientC * argumentX + freeTermD;

            Console.WriteLine($"Результат(p) = {resultP}");
        }
}
}
