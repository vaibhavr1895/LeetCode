public int[] FindOrder(int numCourses, int[][] prerequisites) {
    Dictionary<int, List<int>> preMap = new Dictionary<int, List<int>>();
    for(int i =0; i< numCourses; i++){
        preMap.Add(i, new List<int>());
    }

    foreach(var p in prerequisites){
        preMap[p[0]].Add(p[1]);
    }

    HashSet<int> visited = new HashSet<int>();
    List<int> order = new List<int>();
    for(int i =0; i < numCourses; i++){
        if(!DFS(preMap, visited, i, order))
        {
            return new int[0];
        }
    }
    return order.ToArray();

}

private bool DFS(Dictionary<int, List<int>> preMap, HashSet<int> visited, int current, List<int> order){
    if(visited.Contains(current)){
        return false;
    }
    if(!preMap[current].Any()){
        if (!order.Contains(current))
        {
            order.Add(current);
        }
        return true;
    }

    visited.Add(current);
    foreach(var p in preMap[current]){
        if(!DFS(preMap, visited, p, order)){
            return false;
        }
    }

    visited.Remove(current);
    order.Add(current);
    preMap[current] = new List<int>();
    return true;
}