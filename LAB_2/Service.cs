using System;
using System.Numerics;

namespace lab2agapov;

/// <summary>
/// Статичний клас для надання допоміжних функцій програми: виведення меню, вводу даних, виведення результатів та виконання операцій.
/// </summary>
public static class Service
{
      public static void WelcomeInfo()
        {
            Console.WriteLine("-------------------------------------------------------------------");
            Console.WriteLine("Агапов Олександр , 18 років, ІПЗ-11(1), 1 курс, sasha_agapov@knu.ua");
            Console.WriteLine("                  Лабораторна робота №2(Варіант 1)                 ");
            Console.WriteLine("-------------------------------------------------------------------");
        }
    private const string ErrorMessageInputNumber = "Введіть число";
    /// <summary>
    /// Виводить головне меню програми та повертає вибір користувача.
    /// </summary>
    /// <returns>Вибір користувача (номер пункту меню), або -1 якщо введено некоректне значення.</returns>
    public static int GetMenuChoice()
    {
        Console.WriteLine("\n=========== МЕНЮ ===========");
        Console.WriteLine("1 - Створити новий масив та відсортувати його");
        Console.WriteLine("2 - Знайти прості числа (Ератосфен)");
        Console.WriteLine("3 - Знайти індекс числа (Бінарний пошук)");
        Console.WriteLine("4 - Створення матриці");
        Console.WriteLine("5 - Дії над матрицею");
        Console.WriteLine("0 - Вихід");
        Console.Write("Ваш вибір: ");

        int choice;
        if (int.TryParse(Console.ReadLine(), out choice))
        {
            return choice;
        }
        return -1; // Якщо ввели дурницю
    }
    /// <summary>
    /// Запитує користувача введення розміру масиву та створює новий об'єкт Vector.
    /// </summary>
    /// <returns>Новостворений об'єкт Vector з випадковими числами.</returns>
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
                Console.WriteLine("Неправильно, " + ErrorMessageInputNumber.ToLower() + ":");
            }
        }
    }

    /// <summary>
    /// Виводить елементи масиву у форматі [елемент1, елемент2, ...]
    /// </summary>
    /// <param name="vector">Об'єкт Vector для виведення.</param>
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
    /// <summary>
    /// Запитує користувача вказати діапазон і знаходить прості числа в масиві за допомогою алгоритму Решето Ератосфена.
    /// </summary>
    /// <param name="vector">Об'єкт Vector для пошуку простих чисел.</param>
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
            Console.WriteLine(ErrorMessageInputNumber);
            return;
        }
        Console.Write("Введіть кінець діапазону: ");
        Console.WriteLine();
          if (!int.TryParse(Console.ReadLine(),out end))
        {
            Console.WriteLine(ErrorMessageInputNumber);
            return;
        }
        vector.EratosthenesSieve(start,end);
        Console.WriteLine("Бажаєте спробувати інший діапазон? (натисніть Enter, щоб продовжити, або введіть 'n' чи 'no' для виходу)");
        answer = Console.ReadLine() ?? "";
        }while(answer != "n" && answer != "no");
    }
    /// <summary>
    /// Здійснює бінарний пошук числа в масиві та виводить результат.
    /// </summary>
    /// <param name="vector">Об'єкт Vector для пошуку (має бути попередньо відсортований).</param>
    public static void BinarySearchArray(Vector vector)
    {

        int target = 0;
        int targetIdx = 0;
        string answer;
        do{
        Console.Write("Ввдіть число індекс якого бажаєте знайти: ");
        if (!int.TryParse(Console.ReadLine(),out target))
        {
            Console.WriteLine(ErrorMessageInputNumber);
            return;
        }
        targetIdx = vector.BinarySearch(target);
        if (targetIdx != -1)
            {
                Console.WriteLine($"Індекс шуканого елемента: {targetIdx}");
            }
        else
            {
                Console.WriteLine("В масиві не знайдено числа за запитом.Введіть новий елемент ");
            }
        
        Console.WriteLine("Повторити пошук елемента?(натисніть Enter, щоб продовжити, або введіть 'n' чи 'no' для виходу)");
        answer = Console.ReadLine() ?? "";
        }while(answer != "n" && answer != "no");
        
    }
    /// <summary>
    /// Запитує користувача введення розмірів матриці та створює новий об'єкт Matrix.
    /// </summary>
    /// <returns>Новостворений об'єкт Matrix з випадковими числами.</returns>
    public static Matrix FillMatrix()
    {
        int rows = 0;
        int cols = 0;
        Console.WriteLine("Введіть розмірність матриці");

        // Нескінченний цикл, поки користувач не введе коректні розміри
        while (true)
        {
            Console.Write("Введіть кількість рядків: ");
            // Перевіряємо, чи ввели число і чи воно більше 0
            if (int.TryParse(Console.ReadLine(), out rows) && rows > 0)
            {
                Console.Write("Введіть кількість стовпців: ");
                if (int.TryParse(Console.ReadLine(), out cols) && cols > 0)
                {
                    // Якщо дійшли сюди — все добре, створюємо і повертаємо матрицю
                    return new Matrix(rows, cols);
                }
                else
                {
                    Console.WriteLine("Помилка! Введіть коректне число стовпців (більше 0).");
                }
            }
            else
            {
                Console.WriteLine("Помилка! Введіть коректне число рядків (більше 0).");
            }
        }
    }
    /// <summary>
    /// Виводить матрицю у форматі таблиці з рядками та стовпцями.
    /// </summary>
    /// <param name="matrix">Об'єкт Matrix для виведення.</param>
    public static void PrintMatrix(Matrix matrix)
    {
      int row = matrix.GetRow();
      int col = matrix.GetCols();
      int[,] tempMatrix = matrix.GetMatrix();
      // Виводимо матрицю у форматі таблиці
      for(int i = 0;i < row; i++)
        {
            Console.Write("[");
            for(int j = 0; j < col;j++)
            {
                 Console.Write(tempMatrix[i, j] + "\t");
            }
            Console.Write("]");
            Console.WriteLine();
        }
    }
    /// <summary>
    /// Запитує користувача вибрати рядок або стовпець і обчислює суму його елементів.
    /// </summary>
    /// <param name="matrix">Об'єкт Matrix для виконання операцій.</param>
    public static void ActionWithMatrix(Matrix matrix)
    {
        Console.Write("Порахувати суму рядка чи стовпця?(рядок = row, стовпець = col):");
        string choice = (Console.ReadLine() ?? "").ToLower().Trim(); 
        int targetForRow = 0;
        int sumForRow = 0;
        int targetForCol = 0;
        int sumForCol = 0;

    if (choice == "row")
    {
        Console.Write("Введіть номер рядка суму якого бажаєте знайти: ");
       if(!int.TryParse(Console.ReadLine(), out targetForRow))
            {
                Console.WriteLine(ErrorMessageInputNumber);
                return;
            }  
        // Індекс у масиві починається з 0, тому віднімаємо 1
        sumForRow = matrix.CalculateSumOfRow(targetForRow - 1);
        if(sumForRow == -1)
            {
                Console.Write($"Нема рядка № {targetForRow}");
                return;
            }
             else
            {
                Console.WriteLine($"Сума {targetForRow} рядка: {sumForRow}");
            }   
    }
    else if (choice == "col")
    {
        Console.Write("Введіть номер стовпця суму якого бажаєте знайти: ");
       if(!int.TryParse(Console.ReadLine(), out targetForCol))
            {
                Console.WriteLine(ErrorMessageInputNumber);
                return;
            }  
        // Індекс у масиві починається з 0, тому віднімаємо 1
        sumForCol = matrix.CalculateSumOfColumns(targetForCol - 1 );
        if(sumForCol == -1)
            {
                Console.Write($"Нема стовпця № {targetForCol}");
                return;
            }
            else
            {
                Console.WriteLine($"Сума стовпця {targetForCol}: {sumForCol}");
            }   
    }
    else
    {
        Console.WriteLine("Помилка! Будь ласка, введіть 'row' або 'col'.");
    }
    }
    
}
