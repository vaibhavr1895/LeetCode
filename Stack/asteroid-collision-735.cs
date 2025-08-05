using System.Collections.Generic;
using System;

public int[] AsteroidCollision(int[] asteroids)
{
    Stack<int> survivingAsteroids = new Stack<int>();

    for (int i = 0; i < asteroids.Length; i++)
    {
        if (asteroids[i] > 0)
        {
            survivingAsteroids.Push(asteroids[i]);
        }
        else
        {
            while (survivingAsteroids.Count > 0 && survivingAsteroids.Peek() < Math.Abs(asteroids[i]))
            {
                survivingAsteroids.Pop();
            }
            if (survivingAsteroids.Count > 0 && survivingAsteroids.Peek() == Math.Abs(asteroids[i]))
            {
                survivingAsteroids.Pop();
            }
            else if (asteroids[i] < 0)
            {
                survivingAsteroids.Push(asteroids[i]);
            }
        }
    }

    int[] result = new int[survivingAsteroids.Count];
    for (int i = result.Length - 1; i >= 0; i--)
    {
        result[i] = survivingAsteroids.Pop();
    }
    return result;
}