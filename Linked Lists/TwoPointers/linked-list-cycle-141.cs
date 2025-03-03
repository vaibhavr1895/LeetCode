// O(n) time complexity
// O(1) space complexity
public bool HasCycle(ListNode head) {
	var p1 = head;
	var p2 = head;

	while(p1 != null && p2 != null){
		p1 = p1.next;
		if(p2.next != null){
			p2 = p2.next.next;
		}else{
			break;
		}

		if(p1 == p2){
			return true;
		}
	}

	return false;
}