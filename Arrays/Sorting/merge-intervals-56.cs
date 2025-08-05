using System.Collections.Generic;
using System;

public int[][] Merge(int[][] intervals)
{
    Array.Sort<int[]>(intervals, (x, y) => Comparer<int>.Default.Compare(x[0], y[0]));

    List<int[]> result = new List<int[]>();
    int i = 0;
    while (i < intervals.Length)
    {
        int j = i + 1;
        int[] currentInterval = intervals[i];
        while (j < intervals.Length)
        {
            if (currentInterval[1] >= intervals[j][0])
            {

                currentInterval[1] = currentInterval[1] > intervals[j][1] ? currentInterval[1] : intervals[j][1];
                j++;
                continue;
            }
            break;
        }
        result.Add(currentInterval);
        i = j;
    }
    return result.ToArray();
}