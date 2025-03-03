// O(n) time complexity
// O(1) space complexity
public ListNode RemoveNthFromEnd(ListNode head, int n) {
	ListNode dummyNode = new ListNode(0, head);
	ListNode left = dummyNode;
	ListNode right = head;
	for(int i = n; i >0 ; i--){
		right = right.next;
	}

	while(right != null){
		right = right.next;
		left = left.next;
	}

	left.next = left.next.next;

	return dummyNode.next;
}