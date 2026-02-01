using System;
using System.Collections.Generic;
using System.Linq;

namespace RandomCodeNamespace
{
    public class RandomGenerator
    {
        private Random _random = new Random();

        public void GenerateRandomNumbers()
        {
            Console.WriteLine("=== Random Numbers ===");
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"Number {i + 1}: {_random.Next(1, 100)}");
            }
        }

        public string GenerateRandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            return new string(Enumerable.Range(0, length)
                .Select(_ => chars[_random.Next(chars.Length)])
                .ToArray());
        }

        public List<int> GenerateRandomList(int size, int maxValue)
        {
            return Enumerable.Range(0, size)
                .Select(_ => _random.Next(0, maxValue))
                .ToList();
        }

        public double CalculateRandomStatistics()
        {
            var numbers = GenerateRandomList(50, 1000);
            double average = numbers.Average();
            double sum = numbers.Sum();
            double max = numbers.Max();
            double min = numbers.Min();

            Console.WriteLine($"Average: {average:F2}");
            Console.WriteLine($"Sum: {sum}");
            Console.WriteLine($"Max: {max}");
            Console.WriteLine($"Min: {min}");

            return average;
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            var generator = new RandomGenerator();

            generator.GenerateRandomNumbers();
            Console.WriteLine("\n=== Random String ===");
            Console.WriteLine($"Random String (15 chars): {generator.GenerateRandomString(15)}");

            Console.WriteLine("\n=== Statistics ===");
            generator.CalculateRandomStatistics();

            Console.WriteLine("\n=== Random List ===");
            var list = generator.GenerateRandomList(10, 500);
            Console.WriteLine($"Random List: [{string.Join(", ", list)}]");
        }
    }
}
