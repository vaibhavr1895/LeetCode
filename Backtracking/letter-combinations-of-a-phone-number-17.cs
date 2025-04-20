public IList<string> LetterCombinations(string digits)
{
    List<string> retVal = new List<string>();

    Backtrack(0, digits, "", retVal);
    return retVal;
}

public void Backtrack(int i, string digits, string curStr, List<string> retVal)
{
    if (digits.Length == 0)
    {
        return;
    }

    if (digits.Length == curStr.Length)
    {
        retVal.Add(curStr);
        return;
    }

    foreach (var num in numbers[digits[i]])
    {
        Backtrack(i + 1, digits, curStr + num, retVal);
    }
}

public Dictionary<char, List<char>> numbers = new Dictionary<char, List<char>>()
{
    {'2', ['a', 'b', 'c'] },
    {'3', ['d', 'e', 'f'] },
    {'4', ['g', 'h', 'i'] },
    {'5', ['j', 'k', 'l'] },
    {'6', ['m', 'n', 'o'] },
    {'7', ['p', 'q', 'r', 's'] },
    {'8', ['t', 'u', 'v'] },
    {'9', ['w', 'x', 'y', 'z'] },
};