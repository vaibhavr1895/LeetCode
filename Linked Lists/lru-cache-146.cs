// O(1) time complexity
// O(n) space complexity
public class LRUCache {
	private Dictionary<int, Node> cache = new Dictionary<int, Node>();
	private int capacity = 0;
	private Node left = new Node(0,0);
	private Node right = new Node(0,0);

	public LRUCache(int capacity) {
		this.capacity = capacity;
		this.left.next = this.right;
		this.right.prev = this.left;
	}
	
	public int Get(int key) {
		if(cache.ContainsKey(key)){
			Remove(cache[key]);
			Insert(cache[key]);
			return cache[key].value;
		}

		return -1;
	}
	
	public void Put(int key, int value) {
		if(cache.ContainsKey(key)){
			Remove(cache[key]);
		}

		var node = new Node(key, value);
		cache[key] = node;

		Insert(node);
		if(cache.Count > this.capacity){
			var lru = this.left.next;
			Remove(lru);
			cache.Remove(lru.key);
		}
	}

	private void Insert(Node node){
		var prev = this.right.prev;
		var next = this.right;
		prev.next = node;
		node.prev = prev;
		node.next = next;
		next.prev = node;
	}

	private void Remove(Node node){
		var next = node.next;
		var prev = node.prev;
		next.prev = prev;
		prev.next = next;
	}
}

public class Node{
	public int key {get;}
	public int value {get;}
	public Node next {get; set;}
	public Node prev {get; set;}

	public Node(int key, int val){
		this.key = key;
		this.value = val;
	}
}
