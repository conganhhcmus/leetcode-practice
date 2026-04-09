public class Solution
{
    public int MinAbsoluteDifference(IList<int> nums, int x)
    {
        int n = nums.Count;
        Treap treap = new();
        int min = int.MaxValue;
        for (int i = x; i < n; i++)
        {
            treap.Insert(nums[i - x]);
            int? ceil = treap.Ceil(nums[i]);
            int? floor = treap.Floor(nums[i]);
            if (ceil.HasValue)
            {
                min = Math.Min(min, Math.Abs(ceil.Value - nums[i]));
            }

            if (floor.HasValue)
            {
                min = Math.Min(min, Math.Abs(floor.Value - nums[i]));
            }
        }
        return min;
    }
}


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

    public int? Floor(int target)
    {
        Node cur = root;
        int? ans = null;
        while (cur != null)
        {
            if (cur.Val <= target)
            {
                ans = cur.Val;
                cur = cur.Right;
            }
            else
            {
                cur = cur.Left;
            }
        }
        return ans;
    }

    public int? Ceil(int target)
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