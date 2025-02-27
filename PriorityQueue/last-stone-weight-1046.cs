// Max Heap
// PriorityQueue
// O(NlogN) where N is the number of elements in the stones array
// O(logN) where N is the size of the heap

public int LastStoneWeight(int[] stones) {
    PriorityQueue<int, int> priorityQueue = new PriorityQueue<int, int>(new PriorityQueueComparer());
    foreach(var s in stones){
        priorityQueue.Enqueue(s, s);
    }

    while(priorityQueue.Count > 1){
        var y = priorityQueue.Dequeue();
        var x = priorityQueue.Dequeue();

        int diff = y - x;
        if(diff > 0){
            priorityQueue.Enqueue(diff, diff);
        }
    }

    return priorityQueue.Count == 1 ? priorityQueue.Peek() : 0;
}

public class PriorityQueueComparer : IComparer<int>
{
    public int Compare(int x, int y)
    {
        return y - x;
    }
}