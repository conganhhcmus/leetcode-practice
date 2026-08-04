namespace Library;

public class DynamicSegmentTree
{
    struct Node
    {
        public long Sum;
        public int Left;
        public int Right;
    }

    List<Node> nodes = [new(), new()];
    long min;
    long max;
    public DynamicSegmentTree(long min = 0, long max = (long)1e18)
    {
        this.min = min;
        this.max = max;
    }

    public void Update(long index, long delta)
    {
        Update(1, min, max, index, delta);
    }

    public long Query(long left, long right)
    {
        if (left > right) return 0;
        return Query(1, min, max, left, right);
    }

    int NewNode()
    {
        nodes.Add(new Node());
        return nodes.Count - 1;
    }

    void Update(int node, long l, long r, long idx, long delta)
    {
        if (l == r)
        {
            var cur = nodes[node];
            cur.Sum += delta;
            nodes[node] = cur;
            return;
        }
        long mid = l + (r - l) / 2;
        var curNode = nodes[node];
        if (idx <= mid)
        {
            if (curNode.Left == 0)
            {
                curNode.Left = NewNode();
                nodes[node] = curNode;
            }
            Update(curNode.Left, l, mid, idx, delta);
        }
        else
        {
            if (curNode.Right == 0)
            {
                curNode.Right = NewNode();
                nodes[node] = curNode;
            }
            Update(curNode.Right, mid + 1, r, idx, delta);
        }
        curNode = nodes[node];
        curNode.Sum = (curNode.Left == 0 ? 0 : nodes[curNode.Left].Sum) + (curNode.Right == 0 ? 0 : nodes[curNode.Right].Sum);
        nodes[node] = curNode;
    }

    long Query(int node, long l, long r, long ql, long qr)
    {
        if (node == 0 || qr < l || r < ql) return 0;
        if (ql <= l && r <= qr) return nodes[node].Sum;
        long mid = l + (r - l) / 2;
        return Query(nodes[node].Left, l, mid, ql, qr) + Query(nodes[node].Right, mid + 1, r, ql, qr);
    }
}
