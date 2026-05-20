public class Solution
{
    public int MaxCapacity(int[] costs, int[] capacity, int budget)
    {
        int n = costs.Length;
        Array.Sort(costs, capacity);
        int ans = 0;
        // pick one
        for (int i = 0; i < n; i++)
        {
            if (costs[i] >= budget) break;
            ans = Math.Max(ans, capacity[i]);
        }

        SegmentTree tree = new(capacity);
        // pick two
        for (int i = 0; i < n; i++)
        {
            int rem = budget - costs[i];
            // from i + 1 to j, where j is max
            int low = i + 1, high = n - 1, best = -1;
            while (low <= high)
            {
                int mid = low + (high - low) / 2;
                if (costs[mid] < rem)
                {
                    best = mid;
                    low = mid + 1;
                }
                else
                {
                    high = mid - 1;
                }
            }
            if (best == -1) break;
            ans = Math.Max(ans, capacity[i] + tree.Query(i + 1, best));
        }
        return ans;
    }
}

public class SegmentTree
{
    int[] tree;
    int n;
    public SegmentTree(int[] nums)
    {
        n = nums.Length;
        tree = new int[4 * n];
        Build(1, 0, n - 1, nums);
    }

    void Build(int node, int left, int right, int[] nums)
    {
        if (left == right)
        {
            tree[node] = nums[left];
            return;
        }
        int mid = left + (right - left) / 2;
        Build(2 * node, left, mid, nums);
        Build(2 * node + 1, mid + 1, right, nums);
        tree[node] = Math.Max(tree[2 * node], tree[2 * node + 1]);
    }

    int Query(int node, int left, int right, int qLeft, int qRight)
    {
        if (qLeft > right || qRight < left) return -1;
        if (qRight >= right && qLeft <= left) return tree[node];
        int mid = left + (right - left) / 2;
        int l = Query(2 * node, left, mid, qLeft, qRight);
        int r = Query(2 * node + 1, mid + 1, right, qLeft, qRight);
        return Math.Max(l, r);
    }

    public int Query(int qLeft, int qRight) => Query(1, 0, n - 1, qLeft, qRight);
}
