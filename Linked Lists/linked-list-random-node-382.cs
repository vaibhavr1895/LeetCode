using System;

private ListNode _head;
private Random _random;
public Solution(ListNode head)
{
    _head = head;
    _random = new Random();
}

public int GetRandom()
{
    ListNode current = _head;
    ListNode randomNode = current;
    int count = 1;
    while (current.next != null)
    {
        current = current.next;
        if (_random.Next(++count) == 0)
            randomNode = current;
    }
    return randomNode.val;
}