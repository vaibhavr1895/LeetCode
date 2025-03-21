public bool ContainsDuplicate(int[] nums) 
{
	HashSet<int> visited = new HashSet<int>();

	foreach (int x in nums) { 
		if(visited.Contains(x)) return true;
		visited.Add(x);
	}
	return false;
}