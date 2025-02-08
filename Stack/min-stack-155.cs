public class MinStack {
	List<int> stack;
	List<int> minStack;
	
	public MinStack() {
		this.stack = new List<int>();
		this.minStack = new List<int>();
	}
	
	public void Push(int val) {
		this.stack.Add(val);
		int minVal = Math.Min(val, this.minStack.Count() > 0 ? this.minStack.Last() : val);
		this.minStack.Add(minVal);
	}
	
	public void Pop() {
		if(this.stack.Count > 0){
			this.stack.RemoveAt(this.stack.Count() - 1);
			this.minStack.RemoveAt(this.minStack.Count() - 1);
		}
	}
	
	public int Top() {
		return this.stack.LastOrDefault();
	}
	
	public int GetMin() {
		return this.minStack.LastOrDefault();
	}
}

/**
 * Your MinStack object will be instantiated and called as such:
 * MinStack obj = new MinStack();
 * obj.Push(val);
 * obj.Pop();
 * int param_3 = obj.Top();
 * int param_4 = obj.GetMin();
 */