public int[][] SpiralMatrix(int m, int n, ListNode head)
{
    int top = 0;
    int bottom = m - 1;
    int left = 0;
    int right = n - 1;

    int[][] result = new int[m][];
    for (int i = 0; i < m; i++)
    {
        result[i] = new int[n];
    }
    while (top <= bottom && left <= right)
    {
        for (int i = left; i <= right; i++)
        {
            result[top][i] = head == null ? -1 : head.val;
            head = head == null ? null : head.next;
        }
        top++;
        for (int i = top; i <= bottom; i++)
        {
            result[i][right] = head == null ? -1 : head.val;
            head = head == null ? null : head.next;
        }
        right--;

        if (top > bottom || left > right)
        {
            break;
        }

        for (int i = right; i >= left; i--)
        {
            result[bottom][i] = head == null ? -1 : head.val;
            head = head == null ? null : head.next;
        }
        bottom--;
        for (int i = bottom; i >= top; i--)
        {
            result[i][left] = head == null ? -1 : head.val;
            head = head == null ? null : head.next;
        }
        left++;
    }

    return result;
}