using System.Collections.Generic;

public IList<IList<int>> Generate(int numRows)
{
    IList<IList<int>> result = new List<IList<int>>();

    result.Add(new List<int>() { 1 });

    for (int i = 0; i < numRows - 1; i++)
    {
        var temp = new List<int>();
        temp.Add(0);
        temp.AddRange(result.Last());
        temp.Add(0);

        List<int> current = new List<int>();
        for (int j = 0; j < result.Last().Count + 1; j++)
        {
            int sum = temp[j] + temp[j + 1];
            current.Add(sum);
        }
        result.Add(current);
    }
    return result;
}