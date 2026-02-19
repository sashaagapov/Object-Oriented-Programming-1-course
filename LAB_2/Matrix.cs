using System;

namespace lab2agapov;

/// <summary>
/// Клас для роботи з двовимірним масивом (матрицею). Забезпечує функціональність для обчислення сум рядків та стовпців.
/// </summary>
public class Matrix
{
    private readonly int _rows;
    private readonly int _cols;
    private readonly int[,] _matrix;

    /// <summary>
    /// Конструктор класу Matrix. Ініціалізує матрицю розміром rows x cols з випадковими числами від 1 до 100.
    /// </summary>
    /// <param name="rows">Кількість рядків матриці.</param>
    /// <param name="cols">Кількість стовпців матриці.</param>
    public Matrix(int rows, int cols)
    {
        _rows = rows;
        _cols = cols;
        Random random = new Random();
        _matrix = new int[_rows,_cols];
        for(int i = 0;i < _rows; i++)
        {
            for(int j = 0; j < _cols;j++)
            {
                _matrix[i,j] = random.Next(1,101);
            }
        }
       

    }
    
    /// <summary>
    /// Обчислює суму всіх елементів заданого рядка матриці.
    /// </summary>
    /// <param name="targetRow">Індекс рядка.</param>
    /// <returns>Сума елементів рядка, або -1 якщо індекс виходить за межі.</returns>
    public int CalculateSumOfRow(int targetRow)
{
    // Перевіряємо, чи індекс у валідному діапазоні
    if (targetRow < 0 || targetRow >= _rows)
    {
        return -1;
    }

    int sumOfRow = 0;

    for (int j = 0; j < _cols; j++)
    {
        sumOfRow += _matrix[targetRow, j];
    }

    return sumOfRow;
}
    /// <summary>
    /// Обчислює суму всіх елементів заданого стовпця матриці.
    /// </summary>
    /// <param name="targetCol">Індекс стовпця.</param>
    /// <returns>Сума елементів стовпця, або -1 якщо індекс виходить за межі.</returns>
    public int CalculateSumOfColumns(int targetCol)
    {
        // Перевіряємо, чи індекс у валідному діапазоні
        if (targetCol < 0 || targetCol >= _cols)
    {
        return -1;
    }
     int sumOfCol = 0;
      for (int i = 0; i < _rows; i++)
    {
        sumOfCol += _matrix[i,targetCol];
    }

    return sumOfCol;
    }

    /// <summary>
    /// Повертає посилання на внутрішню матрицю.
    /// </summary>
    /// <returns>Двовимірний масив матриці.</returns>
    public int[,] GetMatrix()
    {
        return _matrix;
    }

    /// <summary>
    /// Повертає кількість рядків матриці.
    /// </summary>
    /// <returns>Кількість рядків.</returns>
    public int GetRow()
    {
        return _rows;
    }

    /// <summary>
    /// Повертає кількість стовпців матриці.
    /// </summary>
    /// <returns>Кількість стовпців.</returns>
    public int GetCols()
    {
        return _cols;
    }
}