// O(n) time complexity
// O(1) space complexity
public ListNode ReverseKGroup(ListNode head, int k) {
	int count = 0;

	ListNode p1 = head;
	ListNode p2 = head;
	ListNode retVal = new ListNode(0);
	var result = retVal;
	while (p1 != null && p2 != null && k > 1)
	{
		count = 1;
		while (p2 != null && count < k)
		{
			p2 = p2.next;
			count++;
		}

		if (p2 == null)
		{
			break;
		}

		var reversedNode = ReverseNode(p1, p2);
		retVal.next = reversedNode;
		retVal = p1;
		p2 = p1.next;
		p1 = p2;
	}

	return result.next == null ? head : result.next;
}

private ListNode ReverseNode(ListNode p1, ListNode p2){
	ListNode prev = p2?.next;
	var originalHead = prev;
	var nextNode = p1.next;
	while (p1 != originalHead)
	{
		nextNode = p1.next;
		p1.next = prev;
		prev = p1;
		p1 = nextNode;
	}

	return p2;
}