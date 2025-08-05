using System.Collections.Generic;

public IList<bool> KidsWithCandies(int[] candies, int extraCandies)
{
    int largestNum = 0;

    for (int i = 0; i < candies.Length; i++)
    {
        if (largestNum < candies[i])
        {
            largestNum = candies[i];
        }
    }

    List<bool> myRetval = new List<bool>();

    for (int i = 0; i < candies.Length; i++)
    {
        myRetval.Add((candies[i] + extraCandies) >= largestNum);
    }

    return myRetval;
}