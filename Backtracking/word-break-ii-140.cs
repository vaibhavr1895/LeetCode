using System.Collections.Generic;
using System;

public IList<string> WordBreak(string s, IList<string> wordDict)
{
    List<string> currentList = new List<string>();
    List<string> result = new List<string>();
    void BackTrack(int i)
    {
        if (i == s.Length)
        {
            var sentence = String.Join(' ', currentList);
            result.Add(sentence);
            return;
        }

        for (int j = i; j < s.Length; j++)
        {
            var subString = s.Substring(i, j - i + 1);
            if (wordDict.Contains(subString))
            {
                currentList.Add(subString);
                BackTrack(j + 1);
                currentList.RemoveAt(currentList.Count - 1);
            }
        }
    }

    BackTrack(0);
    return result;
}