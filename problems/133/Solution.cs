#if DEBUG
namespace Problems_133;
#endif


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
        if (node is null) return null;
        bool[] visited = new bool[101];
        Node[] cloneNodes = new Node[101];
        Node[] originalNodes = new Node[101];
        visited[node.val] = true;
        cloneNodes[node.val] = new Node(node.val);
        originalNodes[node.val] = node;
        Queue<Node> queue = [];
        queue.Enqueue(node);
        while (queue.Count > 0)
        {
            Node curr = queue.Dequeue();
            foreach (Node neighbor in curr.neighbors)
            {
                if (!visited[neighbor.val])
                {
                    visited[neighbor.val] = true;
                    cloneNodes[neighbor.val] = new Node(neighbor.val);
                    originalNodes[neighbor.val] = neighbor;
                    queue.Enqueue(neighbor);
                }
            }
        }
        for (int i = 0; i < 101; i++)
        {
            Node originalNode = originalNodes[i];
            if (originalNode == null) continue;
            Node cloneNode = cloneNodes[i];
            foreach (Node neighbor in originalNode.neighbors)
            {
                cloneNode.neighbors.Add(cloneNodes[neighbor.val]);
            }
        }

        return cloneNodes[node.val];
    }
}