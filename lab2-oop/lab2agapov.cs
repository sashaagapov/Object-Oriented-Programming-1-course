using System;

namespace lab2agapov
{
    class Program
    {
        static public void Main(string[] args)
        {
            Service service = new Service(); 
            Vector myVector = service.SetSize();
            
            Console.WriteLine("Згенерований масив:");
            service.PrintVector(myVector);

          
        }
    }
}