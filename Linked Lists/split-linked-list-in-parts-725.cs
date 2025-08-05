public ListNode[] SplitListToParts(ListNode head, int k)
{
    int nodeCount = 0;
    ListNode[] result = new ListNode[k];
    var copyHead = head;
    while (copyHead != null)
    {
        copyHead = copyHead.next;
        nodeCount++;
    }

    int baseLength = nodeCount >= k ? nodeCount / k : 0;
    int rem = nodeCount % k;

    var curHead = head;
    for (int i = 0; i < k; i++)
    {
        int m = 1;
        result[i] = curHead;
        int totalLength = baseLength + (rem > 0 ? 1 : 0);
        while (m < totalLength && curHead != null)
        {
            curHead = curHead.next;
            m++;
        }
        rem--;
        if (curHead == null)
        {
            break;
        }
        var temp = curHead.next;
        curHead.next = null;
        curHead = temp;
    }

    return result;
}