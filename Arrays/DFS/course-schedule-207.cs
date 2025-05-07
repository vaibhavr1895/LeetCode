public bool CanFinish(int numCourses, int[][] prerequisites) {
    Dictionary<int, List<int>> preMap = new Dictionary<int, List<int>>();

    for(int i =0; i< numCourses; i++)
    {
        preMap.Add(i, new List<int>());
    }
    foreach (var p in prerequisites)
    {
        preMap[p[0]].Add(p[1]);
    }

    HashSet<int> visited = new HashSet<int>();
    for (int i = 0; i < numCourses; i++)
    {
        if (!DFS(preMap, visited, i))
        {
            return false;
        }
    }
    return true;
}

private bool DFS(Dictionary<int, List<int>> preMap, HashSet<int> visited, int current){
    if(visited.Contains(current)){
        return false;
    }
    if(!preMap[current].Any()){
        return true;
    }

    visited.Add(current);
    foreach(var c in preMap[current]){
        if(!DFS(preMap, visited, c)){
            return false;
        }
    }
    visited.Remove(current);
    preMap[current] = new List<int>();
    return true;
}