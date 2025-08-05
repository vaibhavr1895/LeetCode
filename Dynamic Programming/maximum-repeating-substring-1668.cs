public int MaxRepeating(string sequence, string word)
{
    int result = 0;

    int i = 0;

    while (i < sequence.Length)
    {
        int j = 0;
        int k = i;
        while (j < word.Length && k < sequence.Length)
        {
            if (word[j] != sequence[k])
            {
                break;
            }
            j++;
            k++;
        }
        if (j == word.Length)
        {
            result++;
        }
        i++;
    }

    return result;
}