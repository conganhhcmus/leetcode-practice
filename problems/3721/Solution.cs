public class Solution
{
    public int LongestBalanced(int[] nums)
    {
        int len = 0;
        int n = nums.Length;
        Dictionary<int, Queue<int>> occurrences = [];
        int[] prefixSum = new int[n];
        prefixSum[0] = Sgn(nums[0]);
        if (!occurrences.ContainsKey(nums[0]))
        {
            occurrences[nums[0]] = new Queue<int>();
        }
        occurrences[nums[0]].Enqueue(1);
        for (int i = 1; i < n; i++)
        {
            int val = nums[i];
            prefixSum[i] = prefixSum[i - 1];
            if (!occurrences.ContainsKey(val))
            {
                occurrences[val] = [];
                prefixSum[i] += Sgn(val);
            }

            occurrences[val].Enqueue(i + 1);
        }

        var seg = new SegmentTree(prefixSum);
        for (int i = 0; i < n; i++)
        {
            len = Math.Max(len, seg.FindLast(i + len, 0) - i);
            int nextPos = n + 1;
            occurrences[nums[i]].Dequeue();
            if (occurrences[nums[i]].Count > 0)
            {
                nextPos = occurrences[nums[i]].Peek();
            }
            seg.Add(i + 1, nextPos - 1, -Sgn(nums[i]));
        }
        return len;
    }

    int Sgn(int x) => (x % 2) == 0 ? 1 : -1;
}

public class LazyTag
{
    public int toAdd;

    public LazyTag()
    {
        toAdd = 0;
    }

    public LazyTag Add(LazyTag other)
    {
        toAdd += other.toAdd;
        return this;
    }

    public bool HasTag() => toAdd != 0;

    public void Clear() => toAdd = 0;
}

public class SegmentTreeNode
{
    public int minValue;
    public int maxValue;

    public LazyTag lazyTag;

    public SegmentTreeNode()
    {
        minValue = 0;
        maxValue = 0;
        lazyTag = new();
    }
}

public class SegmentTree
{
    int n;
    SegmentTreeNode[] tree;

    public SegmentTree(int[] data)
    {
        n = data.Length;
        tree = new SegmentTreeNode[4 * n + 1];
        for (int i = 0; i < tree.Length; i++)
        {
            tree[i] = new();
        }
        Build(data, 1, n, 1);
    }

    public void Add(int l, int r, int val)
    {
        LazyTag tag = new()
        {
            toAdd = val
        };
        Update(l, r, tag, 1, n, 1);
    }

    public int FindLast(int start, int val)
    {
        if (start > n) return -1;
        return Find(start, n, val, 1, n, 1);
    }

    void ApplyTag(int i, LazyTag tag)
    {
        tree[i].minValue += tag.toAdd;
        tree[i].maxValue += tag.toAdd;
        tree[i].lazyTag.Add(tag);
    }

    void Pushup(int i)
    {
        tree[i].minValue = Math.Min(tree[2 * i].minValue, tree[2 * i + 1].minValue);
        tree[i].maxValue = Math.Max(tree[2 * i].maxValue, tree[2 * i + 1].maxValue);
    }

    void Pushdown(int i)
    {
        if (tree[i].lazyTag.HasTag())
        {
            LazyTag tag = new()
            {
                toAdd = tree[i].lazyTag.toAdd
            };
            ApplyTag(2 * i, tag);
            ApplyTag(2 * i + 1, tag);
            tree[i].lazyTag.Clear();
        }
    }

    void Build(int[] data, int l, int r, int i)
    {
        if (l == r)
        {
            tree[i].minValue = tree[i].maxValue = data[l - 1];
            return;
        }
        int mid = l + (r - l) / 2;
        Build(data, l, mid, 2 * i);
        Build(data, mid + 1, r, 2 * i + 1);
        Pushup(i);
    }

    void Update(int targetL, int targetR, LazyTag tag, int l, int r, int i)
    {
        if (targetL <= l && r <= targetR)
        {
            ApplyTag(i, tag);
            return;
        }

        Pushdown(i);
        int mid = l + (r - l) / 2;
        if (targetL <= mid)
        {
            Update(targetL, targetR, tag, l, mid, 2 * i);
        }
        if (targetR > mid)
        {
            Update(targetL, targetR, tag, mid + 1, r, 2 * i + 1);
        }
        Pushup(i);
    }

    int Find(int targetL, int targetR, int val, int l, int r, int i)
    {
        if (tree[i].minValue > val || tree[i].maxValue < val) return -1;

        if (l == r) return l;

        Pushdown(i);

        int mid = l + (r - l) / 2;
        if (targetR > mid)
        {
            int res = Find(targetL, targetR, val, mid + 1, r, 2 * i + 1);
            if (res != -1) return res;
        }

        if (l <= targetR && mid >= targetL)
        {
            return Find(targetL, targetR, val, l, mid, 2 * i);
        }
        return -1;
    }

}