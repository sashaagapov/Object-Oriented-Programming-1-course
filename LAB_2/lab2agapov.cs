
/* * ДЕКЛАРАЦІЯ ПРО ВИКОРИСТАННЯ ШІ:

 * Штучний інтелект використовувався у цій лабораторній роботі виключно 

 * як навчальний асистент: для розбору логіки, дебагу та кращого розуміння матеріалу.

 */
/*
 * Ім'я файлу: Program.cs (або lab2agapov.cs)
 * Автор: Агапов Олександр, гр. ІПЗ-11(1)
 * Дата модифікації: 19.02.2026
 * Номер версії модуля: 2
 * У 2 версії програма позбулась static
 * Запланована ціль: Лабораторна робота №2. Робота з класами та об'єктами.
 * Реалізація алгоритмів QuickSort, бінарного пошуку та Решета Ератосфена.
 * Опрацювання одновимірних масивів (Vector) та двовимірних масивів (Matrix).
 */
using System;
namespace lab2agapov
{
    /// <summary>
    /// Головний клас програми. Містить точку входу та управління основним циклом меню.
    /// </summary>
    static class Program
    {
        /// <summary>
        /// Точка входу програми. Керує основним меню та обробляє вибір користувача.
        /// </summary>
        /// <param name="args">Аргументи командного рядка (не використовуються).</param>
        static public void Main(string[] args)
        {
            Service service = new Service();
            service.WelcomeInfo();
            Vector myVector = new Vector(0); // Масив зберігається тут, поки працює програма
            Matrix myMatrix = new Matrix(0, 0);
            bool isRunning = true;
            while (isRunning)
            {
                // Викликаємо меню з Service
                int choice = service.GetMenuChoice();

                switch (choice)
                {
                    case 1:
                        // Створення
                        myVector = service.SetSize();
                        Console.WriteLine("--> Згенерований масив:");
                        service.PrintVector(myVector);

                        // Сортування (обов'язкове для бінарного пошуку)
                        myVector.SortArray();
                        Console.WriteLine("--> Масив відсортовано за спаданням:");
                        service.PrintVector(myVector);
                        break;

                    case 2:
                        // Ератосфен
                        if (myVector.GetArray().Length == 0)
                        {
                            Console.WriteLine(" Помилка: Спочатку створіть масив (пункт 1).");
                        }
                        else
                        {
                            service.PrintEratosthenes(myVector);
                        }
                        break;

                    case 3:
                        // Бінарний пошук
                        if (myVector.GetArray().Length == 0)
                        {
                            Console.WriteLine(" Помилка: Спочатку створіть масив (пункт 1).");
                        }
                        else
                        {
                            service.BinarySearchArray(myVector);
                        }
                        break;
                    case 4:
                        //Створення матриці
                        myMatrix = service.FillMatrix();
                        service.PrintMatrix(myMatrix);
                        break;

                    case 5:
                        if (myMatrix == null || myMatrix.GetRow() == 0)
                        {
                            Console.WriteLine(" Помилка: Спочатку створіть матрицю (пункт 4).");
                        }
                        else
                        {
                            service.ActionWithMatrix(myMatrix);
                        }
                        break;

                    case 0:
                        Console.WriteLine("Роботу завершено.");
                        isRunning = false;
                        break;

                    default:
                        Console.WriteLine("Невірний вибір. Спробуйте ще раз.");
                        break;
                }
            }
        }
    }
}
