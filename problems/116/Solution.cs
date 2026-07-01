/*
// Definition for a Node.
public class Node {
    public int val;
    public Node left;
    public Node right;
    public Node next;

    public Node() {}

    public Node(int _val) {
        val = _val;
    }

    public Node(int _val, Node _left, Node _right, Node _next) {
        val = _val;
        left = _left;
        right = _right;
        next = _next;
    }
}
*/

public class Solution
{
    public Node Connect(Node root)
    {
        Queue<Node> q = [];
        if (root is not null) q.Enqueue(root);
        while (q.Count > 0)
        {
            int s = q.Count;
            Node prev = null;
            while (s-- > 0)
            {
                Node cur = q.Dequeue();
                if (prev != null) prev.next = cur;
                prev = cur;
                if (cur.left is not null) q.Enqueue(cur.left);
                if (cur.right is not null) q.Enqueue(cur.right);
            }
        }
        return root;
    }
}
