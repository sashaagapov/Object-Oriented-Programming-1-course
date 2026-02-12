using System;

namespace lab2agapov
{
    static class Program
    {
        static public void Main(string[] args)
        {
            Vector myVector = Service.SetSize();
            
            Console.WriteLine("Згенерований масив:");
            Service.PrintVector(myVector);
            myVector.SortArray();
            Console.WriteLine("Відсортований масив");
             Service.PrintVector(myVector);
             Service.PrintEratosthenes(myVector);
        }
    }
}