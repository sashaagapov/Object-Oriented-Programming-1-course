using System;

public class Vector
{
    private int[] _array;
    private int _n;

    public Vector(int n)
    {
        _n = n;
        _array = new int[n];
        Random rand = new Random();
        for (int i = 0; i < _n; i++)
        {
            _array[i] = rand.Next(1, 101);
        }
    }

    public int[] GetArray()
    {
        return _array;
    }
    
 
}