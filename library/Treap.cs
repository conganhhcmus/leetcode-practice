namespace Library;

public class Treap
{
    private class Node
    {
        public int Val;
        public int Priority;
        public int Count;
        public Node Left;
        public Node Right;

        public Node(int val, int priority)
        {
            Val = val;
            Priority = priority;
            Count = 1;
        }
    }

    private Node root;
    private readonly Random rand = new Random(1);

    public void Insert(int val)
    {
        root = Insert(root, val);
    }

    public int? LowerBound(int target)
    {
        Node cur = root;
        int? ans = null;
        while (cur != null)
        {
            if (cur.Val >= target)
            {
                ans = cur.Val;
                cur = cur.Left;
            }
            else
            {
                cur = cur.Right;
            }
        }
        return ans;
    }

    public int? UpperBound(int target)
    {
        Node cur = root;
        int? ans = null;

        while (cur != null)
        {
            if (cur.Val > target)
            {
                ans = cur.Val;
                cur = cur.Left;
            }
            else
            {
                cur = cur.Right;
            }
        }

        return ans;
    }

    private Node Insert(Node node, int val)
    {
        if (node == null)
            return new Node(val, rand.Next());

        if (val == node.Val)
        {
            node.Count++;
            return node;
        }

        if (val < node.Val)
        {
            node.Left = Insert(node.Left, val);
            if (node.Left.Priority > node.Priority)
                node = RotateRight(node);
        }
        else
        {
            node.Right = Insert(node.Right, val);
            if (node.Right.Priority > node.Priority)
                node = RotateLeft(node);
        }

        return node;
    }

    private Node RotateRight(Node p)
    {
        Node q = p.Left;
        p.Left = q.Right;
        q.Right = p;
        return q;
    }

    private Node RotateLeft(Node p)
    {
        Node q = p.Right;
        p.Right = q.Left;
        q.Left = p;
        return q;
    }
}