public int MaxArea(int[] height) {
    int start = 0;
    int end = height.Length - 1;
    int maxArea = 0;
    while(start < end){
        int width = end - start;
        int lowestHeight = Math.Min(height[start], height[end]);
        int curArea = width * lowestHeight;
        maxArea = Math.Max(curArea, maxArea);
        if(height[start] < height[end]){
            start++;
        }else{
            end--;
        }
    }

    return maxArea;
}