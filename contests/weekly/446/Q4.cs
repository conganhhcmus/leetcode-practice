#if DEBUG
namespace Weekly_446_Q4;
#endif

public class Solution
{
    public int[] ResultArray(int[] nums, int k, int[][] queries)
    {
        int n = nums.Length, m = queries.Length;
        SegmentTree seg = new(nums, k);
        int[] ret = new int[m];
        for (int i = 0; i < m; i++)
        {
            int idx = queries[i][0];
            int val = queries[i][1];
            int start = queries[i][2];
            int x = queries[i][3];
            seg.Update(1, 0, n - 1, idx, idx, val);
            Node now = seg.Query(1, 0, n - 1, start, n - 1);
            ret[i] = now.Freq[x];
        }
        return ret;
    }
}

public class Node
{
    public int Prod;
    public int[] Freq;
    public Node()
    {
        Prod = 1; // default 1 instead of zero. Because if node l product is zero, the ret is incorrect
        Freq = new int[5];
    }
}

public class SegmentTree
{
    Node[] tree;
    int mod;

    public SegmentTree(int[] nums, int mod)
    {
        int n = nums.Length;
        this.mod = mod;
        tree = new Node[4 * n + 1];
        for (int i = 0; i <= 4 * n; i++)
        {
            tree[i] = new Node();
        }
        Build(nums, 1, 0, n - 1);
    }

    void Init(int node, int val)
    {
        val %= mod;
        tree[node].Prod = val;
        Array.Fill(tree[node].Freq, 0);
        tree[node].Freq[val] = 1;
    }

    void Build(int[] nums, int node, int start, int end)
    {
        if (start == end)
        {
            Init(node, nums[start]);
            return;
        }
        int mid = start + (end - start) / 2;
        Build(nums, 2 * node, start, mid);
        Build(nums, 2 * node + 1, mid + 1, end);
        tree[node] = Merge(tree[2 * node], tree[2 * node + 1]);
    }

    Node Merge(Node l, Node r)
    {
        Node res = new Node();
        res.Prod = (l.Prod * r.Prod) % mod;
        for (int i = 0; i < 5; i++)
        {
            res.Freq[i] += l.Freq[i];
            res.Freq[(l.Prod * i) % mod] += r.Freq[i];
        }
        return res;
    }

    public Node Query(int node, int start, int end, int left, int right)
    {
        if (left > end || right < start) return new();
        if (left <= start && right >= end) return tree[node];
        int mid = start + (end - start) / 2;
        Node l = Query(2 * node, start, mid, left, right);
        Node r = Query(2 * node + 1, mid + 1, end, left, right);
        return Merge(l, r);
    }

    public void Update(int node, int start, int end, int left, int right, int val)
    {
        if (left > end || right < start) return;
        if (left <= start && right >= end)
        {
            Init(node, val);
            return;
        }
        int mid = start + (end - start) / 2;
        Update(2 * node, start, mid, left, right, val);
        Update(2 * node + 1, mid + 1, end, left, right, val);
        tree[node] = Merge(tree[2 * node], tree[2 * node + 1]);
    }
}