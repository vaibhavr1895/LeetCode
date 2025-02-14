// O(n) time complexity
// O(n) space complexity
public ListNode AddTwoNumbers(ListNode l1, ListNode l2) {
	Queue<int> s1 = new Queue<int>();
	Queue<int> s2 = new Queue<int>();

	while(l1 != null || l2 != null){
		if(l1 != null){
			s1.Enqueue(l1.val);
			l1 = l1.next;
		}

		if(l2 != null){
			s2.Enqueue(l2.val);
			l2 = l2.next;
		}
	}
	int carry = 0;
	ListNode head = new ListNode();
	ListNode newHead = head;
	while(s1.Count > 0 || s2.Count > 0){
		int sum = carry;
		if(s1.Count > 0){
			sum += s1.Dequeue();
		}
		if(s2.Count > 0){
			sum += s2.Dequeue();
		}

		int totalSum = sum % 10;
		carry = sum / 10;

		head.next = new ListNode(totalSum);
		head = head.next;
	}

	if(carry != 0){
		head.next = new ListNode(carry);
	}
	return newHead.next;
}