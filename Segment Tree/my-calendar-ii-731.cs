using System.Collections.Generic;
using System;

public class MyCalendarTwo
{
    private List<(int, int)> nonOverlappingIntervals;
    private List<(int, int)> overlappingIntervals;
    public MyCalendarTwo()
    {
        nonOverlappingIntervals = new List<(int, int)>();
        overlappingIntervals = new List<(int, int)>();
    }

    public bool Book(int startTime, int endTime)
    {
        foreach (var (s, e) in overlappingIntervals)
        {
            if (endTime > s && startTime < e)
            {
                return false;
            }
        }

        foreach (var (s, e) in nonOverlappingIntervals)
        {
            if (endTime > s && startTime < e)
            {
                overlappingIntervals.Add((Math.Max(startTime, s), Math.Min(endTime, e)));
            }
        }
        nonOverlappingIntervals.Add((startTime, endTime));
        return true;
    }
}