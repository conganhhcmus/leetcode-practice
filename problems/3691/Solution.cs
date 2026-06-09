public class Solution
{
    public long MaxTotalValue(int[] nums, int k)
    {
        int n = nums.Length;
        SparseTable st = new(nums);
        PriorityQueue<Node, long> pq = new();
        for (int l = 0; l < n; l++)
        {
            int r = n - 1;
            long v = st.Value(l, r);
            pq.Enqueue(new(v, l, r), -v);
        }
        long ans = 0L;
        while (k-- > 0)
        {
            Node cur = pq.Dequeue();
            ans += cur.Value;
            if (cur.R > cur.L)
            {
                int nr = cur.R - 1;
                long nv = st.Value(cur.L, nr);
                pq.Enqueue(new(nv, cur.L, nr), -nv);
            }
        }
        return ans;
    }

    class Node
    {
        public long Value;
        public int L;
        public int R;
        public Node(long value, int l, int r)
        {
            Value = value;
            L = l;
            R = r;
        }
    }

    class SparseTable
    {
        int[][] maxSt;
        int[][] minSt;
        int[] log2;

        public SparseTable(int[] nums)
        {
            int n = nums.Length;
            log2 = new int[n + 1];
            for (int i = 2; i <= n; i++)
            {
                log2[i] = log2[i / 2] + 1;
            }
            int K = log2[n] + 1;
            maxSt = new int[K][];
            minSt = new int[K][];
            for (int k = 0; k < K; k++)
            {
                maxSt[k] = new int[n];
                minSt[k] = new int[n];
            }
            for (int i = 0; i < n; i++)
            {
                maxSt[0][i] = nums[i];
                minSt[0][i] = nums[i];
            }

            for (int k = 1; k < K; k++)
            {
                int len = 1 << k;
                int half = len >> 1;
                for (int i = 0; i + len <= n; i++)
                {
                    maxSt[k][i] = Math.Max(maxSt[k - 1][i], maxSt[k - 1][i + half]);
                    minSt[k][i] = Math.Min(minSt[k - 1][i], minSt[k - 1][i + half]);
                }
            }
        }

        int QueryMax(int l, int r)
        {
            int len = r - l + 1;
            int k = log2[len];
            return Math.Max(maxSt[k][l], maxSt[k][r - (1 << k) + 1]);
        }

        int QueryMin(int l, int r)
        {
            int len = r - l + 1;
            int k = log2[len];
            return Math.Min(minSt[k][l], minSt[k][r - (1 << k) + 1]);
        }

        public long Value(int l, int r) => (long)QueryMax(l, r) - QueryMin(l, r);
    }
}
