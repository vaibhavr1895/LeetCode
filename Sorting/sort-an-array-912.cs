// Merge Sort
// time complexity O(nlog(n))
public int[] SortArray(int[] nums) {
    return MergeSort(nums, 0, nums.Length - 1);
}

private int[] MergeSort(int[] arr, int l, int r){
    if(l == r){
        return arr;
    }
    int mid = (l + r) / 2; 
    MergeSort(arr, l, mid);
    MergeSort(arr, mid + 1, r);
    Merge(arr, l, mid, r);
    return arr;
}

private int[] Merge(int[] arr, int l, int m, int r){
    int[] left = arr[l..(m+1)];
    int[] right = arr[(m + 1)..(r + 1)];
    int i = l;
    int j = 0;
    int k = 0;

    while(k < right.Length && j < left.Length){
        if(left[j] <= right[k]){
            arr[i] = left[j];
            j++;
        }else{
            arr[i] = right[k];
            k++;
        }
        i++;
    }

    while(k < right.Length){
        arr[i] = right[k];
        k++;
        i++;
    }
    while(j < left.Length){
        arr[i] = left[j];
        j++;
        i++;
    }

    return arr;
}