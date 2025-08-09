using System.Collections.Generic;
using System;

// Approach
// First construct the segment tree with the max Indices
// then do the binary search on the segment tree with given range
// implement the Range maximum Index Query to get the nearest max height index


public int[] LeftmostBuildingQueries(int[] heights, int[][] queries)
{
    var segmentTree = ConstructSegmentTree(heights);

    List<int> result = new List<int>();

    foreach (var q in queries)
    {
        int minIdx = Math.Min(q[0], q[1]);
        int maxIdx = Math.Max(q[0], q[1]);

        if (minIdx == maxIdx)
        {
            result.Add(maxIdx);
            continue;
        }

        if (heights[maxIdx] > heights[minIdx])
        {
            result.Add(maxIdx);
            continue;
        }

        int left = maxIdx + 1;
        int right = heights.Length - 1;
        int resultIdx = int.MaxValue;
        while (left <= right)
        {
            int mid = left + (right - left) / 2;
            int idx = RMIQ(segmentTree, heights, left, mid);

            if (heights[idx] > Math.Max(heights[minIdx], heights[maxIdx]))
            {
                resultIdx = Math.Min(resultIdx, idx);
                right = mid - 1;
            }
            else
            {
                left = mid + 1;
            }
        }
        if (resultIdx == int.MaxValue)
        {
            result.Add(-1);
        }
        else
        {
            result.Add(resultIdx);
        }
    }
    return result.ToArray();
}

private int RMIQ(int[] segmentTree, int[] heights, int start, int end)
{
    return QuerySegmentTree(start, end, 0, 0, heights.Length - 1, segmentTree, heights);
}

private int QuerySegmentTree(int start, int end, int i, int left, int right, int[] segmentTree, int[] heights)
{
    if (left > end || right < start)
    {
        return -1;
    }

    if (left >= start && right <= end)
    {
        return segmentTree[i];
    }

    int mid = left + (right - left) / 2;

    int leftIdx = QuerySegmentTree(start, end, 2 * i + 1, left, mid, segmentTree, heights);
    int rightIdx = QuerySegmentTree(start, end, 2 * i + 2, mid + 1, right, segmentTree, heights);

    if (leftIdx == -1)
    {
        return rightIdx;
    }
    if (rightIdx == -1)
    {
        return leftIdx;
    }
    return heights[leftIdx] >= heights[rightIdx] ? leftIdx : rightIdx;
}

private int[] ConstructSegmentTree(int[] heights)
{
    int[] segmentTree = new int[4 * heights.Length];
    BuildSegmentTree(0, 0, heights.Length - 1, segmentTree, heights);
    return segmentTree;
}

private void BuildSegmentTree(int i, int left, int right, int[] segmentTree, int[] heights)
{
    if (left == right)
    {
        segmentTree[i] = left;
        return;
    }

    int mid = left + (right - left) / 2;
    BuildSegmentTree(2 * i + 1, left, mid, segmentTree, heights);
    BuildSegmentTree(2 * i + 2, mid + 1, right, segmentTree, heights);

    segmentTree[i] = heights[segmentTree[2 * i + 1]] >= heights[segmentTree[2 * i + 2]] ? segmentTree[2 * i + 1] : segmentTree[2 * i + 2];
}