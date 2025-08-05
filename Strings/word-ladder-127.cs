using System.Collections.Generic;

public int LadderLength(string beginWord, string endWord, IList<string> wordList)
{
    Dictionary<string, List<string>> patternDictionary = new Dictionary<string, List<string>>();
    wordList.Add(beginWord);

    if (!wordList.Contains(endWord))
    {
        return 0;
    }

    foreach (var word in wordList)
    {
        for (int i = 0; i < word.Length; i++)
        {
            var wordCopy = word.ToArray();
            wordCopy[i] = '*';
            var pattern = new string(wordCopy);
            if (patternDictionary.ContainsKey(pattern))
            {
                patternDictionary[pattern].Add(word);
            }
            else
            {
                patternDictionary.Add(pattern, new List<string>() { word });
            }
        }
    }

    var visited = new HashSet<string>();
    var queue = new Queue<string>();
    visited.Add(beginWord);
    queue.Enqueue(beginWord);
    int result = 1;
    while (queue.Count() > 0)
    {
        int queueLength = queue.Count();
        while (queueLength > 0)
        {
            var word = queue.Dequeue();
            queueLength--;
            if (word == endWord)
            {
                return result;
            }

            for (int i = 0; i < word.Length; i++)
            {
                var wordCopy = word.ToArray();
                wordCopy[i] = '*';
                var pattern = new string(wordCopy);
                foreach (var neighbor in patternDictionary[pattern])
                {
                    if (!visited.Contains(neighbor))
                    {
                        visited.Add(neighbor);
                        queue.Enqueue(neighbor);
                    }
                }
            }
        }
        result++;
    }
    return 0;
}