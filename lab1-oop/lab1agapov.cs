using System;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Xml;

namespace lab1agapov
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.OutputEncoding = Encoding.UTF8;
            WelcomeInfo();
            bool menuStopping = true;
            while (menuStopping)
            {
               
                Console.WriteLine("    === ГОЛОВНЕ МЕНЮ  ===");
                Console.WriteLine("1.  Обчислення поліному (Math)");
                Console.WriteLine("2. Використання математичних функцій");
                Console.WriteLine("3. f(x)");
                Console.WriteLine("4. Назва місяця (switch)");
                Console.WriteLine("5. Порахувати добуток за формулою");
                Console.WriteLine("0. Вихід");
                Console.Write("\nОберіть номер завдання: ");

                
                string choice;
                do {
                     choice = Console.ReadLine() ?? "";
                    } while (string.IsNullOrWhiteSpace(choice)); 

                switch (choice)
                {
                    case "1":
                        CalculatePolynomial();
                        break;
                    case "2":
                         CalculateMathFunction();
                        break;
                    case "3":
                       CalculatePiecewiseFunction();
                        break;
                    case "4":
                     GetMonthName();
                        break;
                    case "5":
                        CalculateSeries();
                        break;
                    case "0":
                        return; 
                    default:
                        Console.WriteLine("Невірний вибір. Спробуйте ще раз.");
                        break;
                }

          
                Console.WriteLine("\nНатисніть будь-яку клавішу, щоб повернутись в меню...");
                Console.ReadKey();
            }
        }

        static void WelcomeInfo()
        {
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine("Агапов Олександр, ІПЗ-11(1), лабораторна робота №1");
            Console.WriteLine("---------------------------------------------------");
        }

        static void CalculatePolynomial()
        {
            Console.WriteLine("\n--- Завдання 2: Поліном ---");
            double coefficientA = 5;
            double coefficientB = 1.3;
            double coefficientC = -4.0;
            double freeTermD = 10.5;
            
            Console.WriteLine("Рівняння: p = a*x^5 - 1 / (b*x^4) + c*x + d");
            Console.Write("Введіть значення x: ");

           
            if (double.TryParse(Console.ReadLine(), out double argumentX))
            {
                
                double resultP = coefficientA * Math.Pow(argumentX, 5) - (1.0 / (coefficientB * Math.Pow(argumentX, 4))) + coefficientC * argumentX + freeTermD;
                Console.WriteLine($"Результат (p) = {resultP:F4}");
            }
            else
            {
                Console.WriteLine("Помилка: введено не число.");
            }
        }

        static void CalculateMathFunction()
        {
            Console.WriteLine("\n--- Завдання 3: Рівняння 2 ---");
            Console.WriteLine("Умова: x = sqrt((a-b)/a + |sin(a)/cos(b)|)");
            
            double valA;
            double valB;
            
            Console.Write("Введіть значення для a: ");
            if (!double.TryParse(Console.ReadLine(), out valA))
            {
                Console.WriteLine("Помилка: введено не число");
                return;
            }

            Console.Write("Введіть значення для b: ");
            if (!double.TryParse(Console.ReadLine(), out valB))
            {
                Console.WriteLine("Помилка: введено не число");
                return;
            }

            if (valA == 0)
            {
                Console.WriteLine("Помилка: 'a' не може бути 0 (ділення на нуль)");
                return;
            }
            
        
            double part1 = (valA - valB) / valA;
            double part2 = Math.Abs(Math.Sin(valA) / Math.Cos(valB));
            double sum = part1 + part2;

            if (sum < 0)
            {
                 Console.WriteLine("Помилка: під коренем від'ємне число.");
            }
            else
            {
                double resultX = Math.Sqrt(sum);
                Console.WriteLine($"Результат x = {resultX:F4}");
            }
        }
        static void CalculatePiecewiseFunction()
        {
            int valX = 0;
            int result = 0;
            Console.WriteLine("\n--- f(x) ---");
            Console.WriteLine("Умова: x>0 -> x^2+4;  x<0 -> x-5;  x=0 -> 0");
            Console.Write("Введіть значення x: ");
            
            if(!int.TryParse(Console.ReadLine(),out valX))
            {
              Console.WriteLine("Неправильно.Введіть число");
              return;  
            }
            if(valX > 0)
            {
                result  = valX * valX + 4;
            }
            else if(valX < 0)
            {
                result = valX - 5;
            }
            else
            {
                result = 0;
            }
            Console.WriteLine($"Результат: {result}");
        }

        static void GetMonthName()
        {
            Console.WriteLine("\n--- Завдання 4: Місяці (switch) ---");
            Console.Write("Введіть номер місяця (1-12): ");
            
            
            string input = Console.ReadLine() ?? "";
            
            switch (input)
            {
                case "1": Console.WriteLine("Січень"); break;
                case "2": Console.WriteLine("Лютий"); break;
                case "3": Console.WriteLine("Березень"); break;
                case "4": Console.WriteLine("Квітень"); break;
                case "5": Console.WriteLine("Травень"); break;
                case "6": Console.WriteLine("Червень"); break;
                case "7": Console.WriteLine("Липень"); break;
                case "8": Console.WriteLine("Серпень"); break;
                case "9": Console.WriteLine("Вересень"); break;
                case "10": Console.WriteLine("Жовтень"); break;
                case "11": Console.WriteLine("Листопад"); break;
                case "12": Console.WriteLine("Грудень"); break;
                default:
                    Console.WriteLine("Помилка: такого місяця не існує (введіть 1-12).");
                    break;
            }
        }
        static void CalculateSeries()
        {
            double result;
            int valN ;
            Console.WriteLine("Програма для обчислення добутку членів ряду");
            Console.WriteLine("Формула: P = (2/1) * (3/2) * (4/3) * ... * ((n+1)/n)");
            Console.WriteLine("Введіть натуральне число n, щоб отримати результат:");
            Console.WriteLine("Введіть натуральне число n: ");
            if (!int.TryParse(Console.ReadLine(),out valN))
            {
                Console.WriteLine("Введіть натуральне число");
                return;
            }
            result = Product(valN);
          Console.WriteLine($"Результат множення: {result}");
        }
        static double Product(int n)
        {
            double tempResult = 1;
            double multiplier;
            for (double k = 1;k <= n;k++)
            {
                multiplier = (k + 1)/k;
                tempResult *= multiplier; 
                Console.Write($"{k}.ітерація = {tempResult}; ");
            }
            return tempResult;
        }
        
        
    }
}