using System;

public bool IsPowerOfFour(int n)
{
    return n > 0 && Math.Log(n, 4) % 1 == 0;
}