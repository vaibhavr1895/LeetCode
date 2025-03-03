public int[][] KClosest(int[][] points, int k) {
    points = QuickSelect(points, k - 1, 0, points.Length - 1);

    int[][] retVal = new int[k][];
    for(int i =0; i < k; i++){
        retVal[i] = points[i];
    }
    return retVal;
}

private int[][] QuickSelect(int[][] points, int k, int left, int right){
    int pivot = (points[right][0] * points[right][0]) + (points[right][1] * points[right][1]);
    int p = left;

    for(int i = left; i < right; i++){
        int curSqrt = (points[i][0] * points[i][0]) + (points[i][1] * points[i][1]);
        if(curSqrt < pivot){
            int[] temp = points[p];
            points[p] = points[i];
            points[i] = temp;
            p++;
        }
    }

    int[] temp2 = points[p];
    points[p] = points[right];
    points[right] = temp2;

    if(p > k){
        return QuickSelect(points, k, left, p - 1);
    }else if(p < k){
        return QuickSelect(points, k, p + 1, right);
    }
    return points;
}

// Priority Queue
public int[][] KClosest(int[][] points, int k) {
    PriorityQueue<int[], int> myPriorityQueue = new PriorityQueue<int[], int>(new PriorityComparator());

    for(int i =0; i < points.Length; i++){
        var sqr = (points[i][0] * points[i][0]) + (points[i][1] * points[i][1]);
        myPriorityQueue.Enqueue(points[i], sqr);
    }
    int[][] retVal = new int[k][];
    int j =0;
    while(myPriorityQueue.Count > points.Length - k){
        var d = myPriorityQueue.Dequeue();
        retVal[j] = d;
        j++;
    }
    return retVal;
}

public class PriorityComparator: IComparer<int>{
    public int Compare(int x, int y){
        return x - y;
    }
}