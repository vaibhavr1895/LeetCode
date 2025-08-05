using System;

public int EraseOverlapIntervals(int[][] intervals)
{
    Array.Sort<int[]>(intervals, (x, y) => Comparer<int>.Default.Compare(x[1], y[1]));
    int lowest = intervals[0][0];
    int highest = intervals[0][1];

    int result = 0;

    for (int i = 1; i < intervals.Length; i++)
    {
        if ((intervals[i][0] >= lowest && intervals[i][1] <= highest) ||
            (intervals[i][0] < lowest && intervals[i][1] <= highest && intervals[i][1] > lowest) ||
            (intervals[i][0] <= lowest && intervals[i][1] > highest) ||
            (intervals[i][0] >= lowest && intervals[i][0] < highest && intervals[i][1] > highest))
        {
            result++;
            continue;
        }

        lowest = Math.Min(lowest, intervals[i][0]);
        highest = Math.Max(highest, intervals[i][1]);
    }

    return result;
}