// O(N) where N is the number of elements in the nums array
// O(1)
// O(n * n) in worst case scenario
public int FindKthLargest(int[] nums, int k) {
    k = nums.Length - k;
    return QuickSelect(0, nums.Length - 1, nums, k);
}

private int QuickSelect(int left, int right, int[] nums, int k){
    int pivot = nums[right];
    int p = left;

    for(int i = p; i < right; i++){
        if(nums[i] < pivot){
            int temp = nums[i];
            nums[i] = nums[p];
            nums[p] = temp;
            p = p + 1;
        }
    }
    int temp2 = nums[p];
    nums[p] = nums[right];
    nums[right] = temp2;

    if(p > k){
        return QuickSelect(left, p - 1, nums, k);
    }else if(p < k){
        return QuickSelect(p + 1, right, nums, k);
    }else{
        return nums[p];
    }
}


// PriorityQueue
public int FindKthLargest(int[] nums, int k) {
    PriorityQueue<int, int> queue = new PriorityQueue<int, int>(new PriorityComparator());
    foreach(var n in nums){
        queue.Enqueue(n, n);
    }

    while(queue.Count > k){
        queue.Dequeue();
    }

    return queue.Peek();
}

public class PriorityComparator : IComparer<int>{
    public int Compare(int x, int y){
        return x - y;
    }
}