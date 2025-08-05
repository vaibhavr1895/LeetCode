public int[] TopKFrequent(int[] nums, int k) {
    Dictionary<int, int> keyValuePairs = new Dictionary<int, int>();

    foreach (int i in nums) {
        if (keyValuePairs.ContainsKey(i)) {
            keyValuePairs[i] = keyValuePairs[i] + 1;
        }
        else
        {
            keyValuePairs.Add(i, 1);
        }
    }

    PriorityQueue<int, int> priorityQueue = new PriorityQueue<int, int>(new PriorityQueueComparer());
    priorityQueue.EnsureCapacity(k);
    foreach (var i in keyValuePairs) {
        priorityQueue.Enqueue(i.Key, i.Value);
    }

    int[] retVal = new int[k];

    for (int i = 0; i < k; i++) {
        var elem = priorityQueue.Dequeue();
        retVal[i] = elem;
    }
    return retVal;
}

public class PriorityQueueComparer : IComparer<int>
{
    public int Compare(int x, int y)
    {
        return y - x;
    }
}