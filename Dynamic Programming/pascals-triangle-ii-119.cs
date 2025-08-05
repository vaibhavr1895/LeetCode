using System.Collections.Generic;

public IList<int> GetRow(int rowIndex)
{
    List<int> result = new List<int>() { 1 };

    for (int i = 0; i < rowIndex; i++)
    {
        List<int> temp = [0, .. result, 0];
        result.Clear();
        for (int j = 0; j + 1 < temp.Count(); j++)
        {
            result.Add(temp[j] + temp[j + 1]);
        }
    }
    return result;
}