using System;

public int NumOfUnplacedFruits(int[] fruits, int[] baskets)
{
    int[] segmentTree = new int[4 * baskets.Length];

    ConstructSegmentTree(0, 0, baskets.Length - 1, segmentTree, baskets);
    int count = fruits.Length;
    foreach (var f in fruits)
    {
        if (Query(f, segmentTree, 0, 0, baskets.Length - 1))
        {
            count--;
        }
    }
    return count;
}

private bool Query(int fruit, int[] segmentTree, int i, int left, int right)
{
    if (left == right)
    {
        if (segmentTree[i] >= fruit)
        {
            segmentTree[i] = -1;
            return true;
        }
        else
        {
            return false;
        }
    }

    if (segmentTree[i] < fruit)
    {
        return false;
    }

    int mid = left + (right - left) / 2;
    var leftQuery = Query(fruit, segmentTree, 2 * i + 1, left, mid);
    if (leftQuery)
    {
        segmentTree[i] = Math.Max(segmentTree[2 * i + 1], segmentTree[2 * i + 2]);
        return true;
    }
    var rightQuery = Query(fruit, segmentTree, 2 * i + 2, mid + 1, right);
    if (rightQuery)
    {
        segmentTree[i] = Math.Max(segmentTree[2 * i + 1], segmentTree[2 * i + 2]);
        return true;
    }

    return false;
}

private void ConstructSegmentTree(int i, int left, int right, int[] segmentTree, int[] baskets)
{
    if (left == right)
    {
        segmentTree[i] = baskets[left];
        return;
    }

    int mid = left + (right - left) / 2;
    ConstructSegmentTree(2 * i + 1, left, mid, segmentTree, baskets);
    ConstructSegmentTree(2 * i + 2, mid + 1, right, segmentTree, baskets);

    segmentTree[i] = Math.Max(segmentTree[2 * i + 1], segmentTree[2 * i + 2]);
}