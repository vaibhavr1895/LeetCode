// O(n) time complexity
// O(1) space complexity
public void ReorderList(ListNode head) {
	var slow = head;
	var fast = head.next;

	while (fast != null && fast.next != null)
	{
		slow = slow.next;
		fast = fast.next.next;
	}

	ListNode newNode = slow.next;
	ListNode prevNode = null;
	slow.next = null;
	while (newNode != null)
	{
		var next = newNode.next;
		newNode.next = prevNode;
		prevNode = newNode;
		newNode = next;
	}
	var originalHead = head;
	while (prevNode != null && originalHead != null)
	{
		var next1 = originalHead.next;
		var next2 = prevNode.next;
		originalHead.next = prevNode;
		prevNode.next = next1;
		originalHead = next1;
		prevNode = next2;
	}
}