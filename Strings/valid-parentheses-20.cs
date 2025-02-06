// O(n) time
// O(n) space
public bool IsValid(string s) {
	Stack<char> stack = new Stack<char>();

	foreach(var c in s){
		if(c == '('){
			stack.Push(')');
		}else if (c == '{'){
			stack.Push('}');
		}else if (c == '['){
			stack.Push(']');
		}else if (stack.Count() == 0 || c != stack.Pop()){
			return false;
		}
	}
	return true;
}