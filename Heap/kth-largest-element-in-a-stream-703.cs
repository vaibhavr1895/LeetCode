public class KthLargest {

    private PriorityQueue<int, int> myPriorityQueue;
    private int K;

    // O(NlogK) where N is the number of elements in the nums array
    public KthLargest(int k, int[] nums) {
        myPriorityQueue = new PriorityQueue<int, int>(new PriorityQueueComparer());
        foreach (var i in nums)
        {
            myPriorityQueue.Enqueue(i, i);
        }
        K = k;
    }
    
    // O(logK) where K is the size of the heap
    public int Add(int val) {
        myPriorityQueue.Enqueue(val, val);

        while(myPriorityQueue.Count > K){
            myPriorityQueue.Dequeue();
        }

        return myPriorityQueue.Peek();
    }

    
}

public class PriorityQueueComparer : IComparer<int>
{
    public int Compare(int x, int y)
    {
        return x - y;
    }
}