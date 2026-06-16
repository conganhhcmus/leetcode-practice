public class Solution
{
    public long MaxSum(int[] nums, int k)
    {
        int n = nums.Length;
        long[] vals = [.. nums.ToHashSet()];
        Array.Sort(vals);
        int m = vals.Length;
        int[] counts = new int[m];
        int[] mapped = new int[n];
        for (int i = 0; i < n; i++)
        {
            int idx = Array.BinarySearch(vals, nums[i]);
            mapped[i] = idx;
            counts[idx]++;
        }
        tree = new Node[4 * m + 10];
        initTree = new Node[4 * m + 10];
        for (int i = 0; i < tree.Length; i++)
        {
            tree[i] = new Node();
            initTree[i] = new Node();
        }
        Build(1, 0, m - 1, counts, vals);
        Array.Copy(tree, initTree, tree.Length);

        long ans = long.MinValue;
        for (int left = 0; left < n; left++)
        {
            Array.Copy(initTree, tree, tree.Length);
            for (int right = left; right < n; right++)
            {
                int idx = mapped[right];
                MoveOutToIn(1, 0, m - 1, idx, vals[idx]);
                long need = right - left + 1;
                long swapLeft = k;
                long curr = Query(1, 0, m - 1, ref need, ref swapLeft, vals);
                if (curr > ans) ans = curr;
            }
        }
        return ans;
    }

    struct Node
    {
        public int InCnt;
        public int OutCnt;
        public long InSum;
        public long OutSum;
    }

    Node[] tree;
    Node[] initTree;

    void Build(int node, int l, int r, int[] counts, long[] vals)
    {
        if (l == r)
        {
            tree[node].InCnt = 0;
            tree[node].InSum = 0;
            tree[node].OutCnt = counts[l];
            tree[node].OutSum = 1L * counts[l] * vals[l];
            return;
        }
        int mid = (l + r) >> 1;
        Build(node << 1, l, mid, counts, vals);
        Build(node << 1 | 1, mid + 1, r, counts, vals);
        PushUp(node);
    }

    void MoveOutToIn(int node, int l, int r, int idx, long val)
    {
        if (l == r)
        {
            tree[node].OutCnt--;
            tree[node].OutSum -= val;
            tree[node].InCnt++;
            tree[node].InSum += val;
            return;
        }
        int mid = (l + r) >> 1;
        if (idx <= mid) MoveOutToIn(node << 1, l, mid, idx, val);
        else MoveOutToIn(node << 1 | 1, mid + 1, r, idx, val);
        PushUp(node);
    }

    void PushUp(int node)
    {
        tree[node].OutCnt = tree[node << 1].OutCnt + tree[node << 1 | 1].OutCnt;
        tree[node].OutSum = tree[node << 1].OutSum + tree[node << 1 | 1].OutSum;
        tree[node].InCnt = tree[node << 1].InCnt + tree[node << 1 | 1].InCnt;
        tree[node].InSum = tree[node << 1].InSum + tree[node << 1 | 1].InSum;
    }

    long Query(int node, int l, int r, ref long need, ref long swapLeft, long[] vals)
    {
        if (need == 0) return 0;
        if (l == r)
        {
            long outTake = Math.Min(swapLeft, tree[node].OutCnt);
            long pool = tree[node].InCnt + outTake;
            long take = Math.Min(need, pool);
            long inTake = Math.Min(take, tree[node].InCnt);
            long actualOutTake = take - inTake;
            need -= take;
            swapLeft -= actualOutTake;
            return take * vals[l];
        }
        long usableOutside = Math.Min(swapLeft, tree[node].OutCnt);
        long poolCnt = tree[node].InCnt + usableOutside;
        if (poolCnt <= need && (swapLeft >= tree[node].OutCnt || swapLeft == 0))
        {
            need -= poolCnt;
            swapLeft -= usableOutside;
            long result = tree[node].InSum;
            if (usableOutside > 0) result += tree[node].OutSum;
            return result;
        }
        int mid = (l + r) >> 1;
        long ans = 0;
        ans += Query(node << 1 | 1, mid + 1, r, ref need, ref swapLeft, vals);

        if (need > 0) ans += Query(node << 1, l, mid, ref need, ref swapLeft, vals);
        return ans;
    }
}
