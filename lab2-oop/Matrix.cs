using System;

namespace lab2agapov;


public class Matrix
{
    private int _rows;
     private int _cols;
     private int[,]  _matrix;
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
    
   public int CalculateSumOfRow(int targetRow)
{
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
    public int CalculateSumOfColumns(int targetCol)
    {
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

    public int[,] GetMatrix()
    {
        return _matrix;
    }

    public int GetRow()
    {
        return _rows;
    }
    public int GetCols()
    {
        return _cols;
    }
}