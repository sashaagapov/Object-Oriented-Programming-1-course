/*
 * Ім'я файлу: Program.cs
 * Автор: Агапов Олександр, гр. ІПЗ-11(1)
 * Дата модифікації: 11.02.2026
 * Номер версії модуля: 2.0
 * Запланована ціль: Лабораторна робота №1. Реалізація консольного меню,
 * обчислення математичних функцій та робота з циклами.
 */

using System;
using System.Text;

namespace lab1agapov
{
    /// <summary>
    /// Головний клас програми, що містить точку входу та методи для виконання завдань лабораторної роботи.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Точка входу програми. Відображає головне меню та обробляє вибір користувача.
        /// </summary>
        /// <param name="args">Аргументи командного рядка (не використовуються).</param>
        static void Main(string[] args)
        {
            
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            bool menuStopping = true;
            while (menuStopping)
            {
                Console.WriteLine("    === ГОЛОВНЕ МЕНЮ ===");
                Console.WriteLine("1. Анкета та поліном");
                Console.WriteLine("2. Математичний вираз (sqrt)");
                Console.WriteLine("3. Кускова функція f(x)");
                Console.WriteLine("4. Назва місяця (switch)");
                Console.WriteLine("5. Добуток ряду");
                Console.WriteLine("0. Вихід");
                Console.Write("\nОберіть номер завдання: ");

                string choice = Console.ReadLine() ?? "";

                switch (choice)
                {
                    case "1":
                        WelcomeInfo();// Виводить анкетні дані та виконує обчислення полінома
                        CalculatePolynomial();// Виконує обчислення полінома для введеного x
                        break;
                    case "2":
                        CalculateMathFunction();// Виконує обчислення математичного виразу для введених a та b
                        break;
                    case "3":
                        CalculatePiecewiseFunction();// Виконує обчислення кускової функції f(x) для введеного x
                        break;
                    case "4":
                        GetMonthName();// Виводить назву місяця за введеним номером місяця (1-12)
                        break;
                    case "5":
                        CalculateSeries();// Виконує обчислення добутку ряду для введеного натурального числа n
                        break;
                    case "0":
                        menuStopping = false;
                        break;
                    default:
                        Console.WriteLine("Невірний вибір. Спробуйте ще раз.");
                        break;
                }

                if (menuStopping)
                {
                    Console.WriteLine("\nНатисніть будь-яку клавішу, щоб повернутись в меню...");
                    Console.ReadKey();
                }
            }
        }

        /// <summary>
        /// Виводить анкетні дані студента та інформацію про лабораторну роботу.
        /// </summary>
        static void WelcomeInfo()
        {
            Console.WriteLine("-------------------------------------------------------------------");
            Console.WriteLine("Агапов Олександр , 18 років, ІПЗ-11(1), 1 курс, sasha_agapov@knu.ua");
            Console.WriteLine("                  Лабораторна робота №1                            ");
            Console.WriteLine("-------------------------------------------------------------------");
        }

        /// <summary>
        /// Обчислює значення полінома p = a*x^5 - 1/(b*x^4) + c*x + d для введеного користувачем значення x.
        /// </summary>
        static void CalculatePolynomial()
        {
            Console.WriteLine("\n--- Завдання: Поліном ---");
            double a = 5;
            double b = 1.3;
            double c = -4.0;
            double d = 10.5;

            Console.WriteLine($"Рівняння: p = {a}*x^5 - 1 / ({b}*x^4) + ({c})*x + {d}");
            Console.Write("Введіть значення x: ");

            if (double.TryParse(Console.ReadLine(), out double x))
            {
                double p = a * Math.Pow(x, 5) - (1.0 / (b * Math.Pow(x, 4))) + c * x + d;
                Console.WriteLine($"Результат (p) = {p:F4}");
            }
            else
            {
                Console.WriteLine("Помилка: введено не число.");
            }
        }

        /// <summary>
        /// Обчислює математичний вираз x = sqrt((a-b)/a + |sin(a)/cos(b)|) для введених значень a та b.
        /// </summary>
        static void CalculateMathFunction()
        {
            Console.WriteLine("\n--- Завдання 2: Рівняння ---");
            Console.WriteLine("Умова: x = sqrt((a-b)/a + |sin(a)/cos(b)|)");

            
            double a, b;

            Console.Write("Введіть a: ");
            if (!double.TryParse(Console.ReadLine(), out a)) 
            {
                 Console.WriteLine("Введено не число"); return; 
            }

            Console.Write("Введіть b: ");
            if (!double.TryParse(Console.ReadLine(), out b)) 
            {
                 Console.WriteLine("Введено не число"); return; 
            }

            if (a == 0)
            {
                Console.WriteLine("Помилка: ділення на нуль (a=0)");
                return;
            }

            double innerValue = (a - b) / a + Math.Abs(Math.Sin(a) / Math.Cos(b));

            if (innerValue < 0)
            {
                Console.WriteLine("Помилка: підкореневий вираз менше нуля.");
            }
            else
            {
                double x = Math.Sqrt(innerValue);
                Console.WriteLine($"Результат x = {x:F4}");
            }
        }

        /// <summary>
        /// Обчислює значення кускової функції f(x), де f(x) = x^2 + 4 при x > 0, f(x) = x - 5 при x < 0, f(x) = 0 при x = 0.
        /// </summary>
        static void CalculatePiecewiseFunction()
        {
            Console.WriteLine("Завдання 3: Обчислити значення кусково-заданої функції f(x):");
            Console.WriteLine();
            Console.WriteLine("       / x² + 4, якщо x > 0");
            Console.WriteLine("f(x) = | x - 5,  якщо x < 0");
            Console.WriteLine("       \\ 0,      якщо x = 0");
            Console.Write("Введіть значення x: ");

            double x;
            
            if (!double.TryParse(Console.ReadLine(), out x))
            {
                Console.WriteLine("Ввести число");
                return;
            }

            double result;
            if (x > 0)
            {
                result = x * x + 4;
            }
            else if (x < 0)
            {
                result = x - 5;
            }
            else // x == 0
            {
                result = 0;
            }
            Console.WriteLine($"Результат f({x}) = {result}");
        }

        /// <summary>
        /// Виводить назву місяця на основі введеного номера місяця (1-12).
        /// </summary>
        static void GetMonthName()
        {
            Console.WriteLine("\n--- Завдання 4: Місяці ---");
            Console.Write("Введіть номер місяця (1-12): ");
            int month;
           
            if (int.TryParse(Console.ReadLine(), out month))
            {
                switch (month)
                {
                    case 1:
                     Console.WriteLine("Січень"); 
                     break;
                    case 2: 
                    Console.WriteLine("Лютий");
                     break;
                    case 3: 
                    Console.WriteLine("Березень");
                     break;
                    case 4: 
                    Console.WriteLine("Квітень");
                     break;
                    case 5:
                     Console.WriteLine("Травень"); 
                     break;
                    case 6:
                     Console.WriteLine("Червень");
                      break;
                    case 7: 
                    Console.WriteLine("Липень"); 
                    break;
                    case 8:
                     Console.WriteLine("Серпень"); 
                     break;
                    case 9:
                     Console.WriteLine("Вересень"); 
                     break;
                    case 10: 
                    Console.WriteLine("Жовтень"); 
                    break;
                    case 11:
                     Console.WriteLine("Листопад");
                      break;
                    case 12: 
                    Console.WriteLine("Грудень");
                     break;
                    default:
                        Console.WriteLine("Помилка: такого місяця не існує (введіть 1-12).");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Помилка: потрібно ввести число.");
            }
        }

        /// <summary>
        /// Обчислює добуток ряду для введеного натурального числа n.
        /// </summary>
        static void CalculateSeries()
        {
            int n;
            double result;
            Console.WriteLine("\n--- Завдання 5: Добуток ряду ---");
            Console.Write("Введіть натуральне число n: ");

            if (int.TryParse(Console.ReadLine(), out n) && n > 0)
            {
                result = Product(n);
                Console.WriteLine($"Результат добутку для n={n}: {result:F4}");
            }
            else
            {
                Console.WriteLine("Будь ласка, введіть коректне натуральне число (більше 0).");
            }
        }

        /// <summary>
        /// Обчислює добуток ряду: П((k+1)/k) для k від 1 до n.
        /// </summary>
        /// <param name="n">Натуральне число, до якого виконується добуток ряду.</param>
        /// <returns>Значення добутку ряду.</returns>
        static double Product(int n)
        {
            double tempResult = 1;
            int k;
            for (k = 1; k <= n; k++)
            {
                // (k + 1.0) робить ділення дробовим, а не цілочисельним
                double multiplier = (k + 1.0) / k;
                Console.WriteLine($"ітерація {k} множник = {multiplier:F2}");
                tempResult *= multiplier;
            }
            return tempResult;
        }
    }
}