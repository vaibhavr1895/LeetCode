// O(n log k) time complexity
// O(1) space complexity
public ListNode MergeKLists(ListNode[] lists) {
	if(lists.Length == 0){
		return null;
	}

	while(lists.Length > 1){
		ListNode[] mergedList = lists.Length % 2 == 0 ? new ListNode[lists.Length/2] : new ListNode[(lists.Length / 2) + 1];
		int mergeCount = 0;
		for(int i = 0; i < lists.Length; i = i + 2){
			ListNode l1 = lists[i];
			ListNode l2 = (i + 1) < lists.Length ? lists[i + 1] : null;
			
			var mergeListNode = MergeLists(l1, l2);
			mergedList[mergeCount] = mergeListNode;
			mergeCount++;
		}
		lists = mergedList;
	}
	return lists[0];
}

private ListNode MergeLists(ListNode l1, ListNode l2){
	var head = new ListNode();
	var retVal = head;
	while(l1 != null || l2 != null){
		if(l1 != null && l2 != null){
			if(l1.val < l2.val){
				head.next = l1;
				l1 = l1.next;
			}else{
				head.next = l2;
				l2 = l2.next;
			}
		}else if(l1 != null){
			head.next = l1;
			l1 = l1.next;
		}else if(l2 != null){
			head.next = l2;
			l2 = l2.next;
		}
		head = head.next;
	}
	return retVal.next;
}