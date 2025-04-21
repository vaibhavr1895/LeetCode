public Node CloneGraph(Node node) {
    return node != null ? DFS(node, new Dictionary<Node, Node>()) : node;
}

private Node DFS(Node originalNode, Dictionary<Node, Node> orgToCopy){
    if(orgToCopy.ContainsKey(originalNode)){
        return orgToCopy[originalNode];
    }
    var newNode = new Node(originalNode.val);
    orgToCopy.Add(originalNode, newNode);
    foreach(var neighbor in originalNode.neighbors){
        newNode.neighbors.Add(DFS(neighbor, orgToCopy));
    }
    return newNode;
}