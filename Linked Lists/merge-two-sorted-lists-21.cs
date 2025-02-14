// O(n) time complexity
// O(1) space complexity

/**
* Definition for singly-linked list.
* public class ListNode {
*     public int val;
*     public ListNode next;
*     public ListNode(int val=0, ListNode next=null) {
*         this.val = val;
*         this.next = next;
*     }
* }
*/

public ListNode MergeTwoLists(ListNode list1, ListNode list2) {
	ListNode retVal = new ListNode();
	ListNode head = retVal;
	
	while(list1 != null || list2 != null){
		if(list1 != null && list2 != null){
			if(list1.val < list2.val){
				var temp = list1;
				list1 = list1.next;
				head.next = temp;
			}else{
				var temp = list2;
				list2 = list2.next;
				head.next = temp;
			}
		}else if(list1 != null){
			var temp = list1;
			list1 = list1.next;
			head.next = temp;
		}else if(list2 != null){
			var temp = list2;
			list2 = list2.next;
			head.next = temp;
		}

		head = head.next;
	}

	return retVal.next;

}
