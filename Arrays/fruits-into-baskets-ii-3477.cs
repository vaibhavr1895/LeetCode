public int NumOfUnplacedFruits(int[] fruits, int[] baskets)
{
    int count = fruits.Length;
    for (int i = 0; i < fruits.Length; i++)
    {
        for (int j = 0; j < baskets.Length; j++)
        {
            if (baskets[j] == -1)
            {
                continue;
            }
            if (baskets[j] >= fruits[i])
            {
                baskets[j] = -1;
                count--;
                break;
            }
        }
    }
    return count;
}