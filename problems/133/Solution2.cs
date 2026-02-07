
// Definition for a Node.
public class Node
{
    public int val;
    public IList<Node> neighbors;

    public Node()
    {
        val = 0;
        neighbors = new List<Node>();
    }

    public Node(int _val)
    {
        val = _val;
        neighbors = new List<Node>();
    }

    public Node(int _val, List<Node> _neighbors)
    {
        val = _val;
        neighbors = _neighbors;
    }
}

public class Solution
{
    public Node CloneGraph(Node node)
    {
        Node[] map = new Node[101];
        return DFS(node, map);
    }

    private Node DFS(Node node, Node[] map)
    {
        if (node is null) return null;
        if (map[node.val] != null) return map[node.val];
        map[node.val] = new(node.val);
        foreach (Node neighbor in node.neighbors)
        {
            map[node.val].neighbors.Add(DFS(neighbor, map));
        }
        return map[node.val];
    }
}