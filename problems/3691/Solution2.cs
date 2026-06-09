public class Solution
{
    public long MaxTotalValue(int[] nums, int k)
    {
        int n = nums.Length;
        SegmentTree st = new(nums);
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

    class SegmentTree
    {
        int n;
        int[] minT;
        int[] maxT;
        public SegmentTree(int[] nums)
        {
            n = nums.Length;
            minT = new int[4 * n + 1];
            maxT = new int[4 * n + 1];
            Build(1, 0, n - 1, nums);
        }

        void Build(int node, int left, int right, int[] nums)
        {
            if (left == right)
            {
                minT[node] = nums[left];
                maxT[node] = nums[left];
                return;
            }
            int mid = left + (right - left) / 2;
            Build(2 * node, left, mid, nums);
            Build(2 * node + 1, mid + 1, right, nums);
            minT[node] = Math.Min(minT[2 * node], minT[2 * node + 1]);
            maxT[node] = Math.Max(maxT[2 * node], maxT[2 * node + 1]);
        }

        int QueryMin(int node, int left, int right, int qLeft, int qRight)
        {
            if (qLeft > right || qRight < left) return int.MaxValue;
            if (qLeft <= left && qRight >= right) return minT[node];
            int mid = left + (right - left) / 2;
            return Math.Min(
                    QueryMin(2 * node, left, mid, qLeft, qRight),
                    QueryMin(2 * node + 1, mid + 1, right, qLeft, qRight)
            );
        }

        int QueryMax(int node, int left, int right, int qLeft, int qRight)
        {
            if (qLeft > right || qRight < left) return int.MinValue;
            if (qLeft <= left && qRight >= right) return maxT[node];
            int mid = left + (right - left) / 2;
            return Math.Max(
                    QueryMax(2 * node, left, mid, qLeft, qRight),
                    QueryMax(2 * node + 1, mid + 1, right, qLeft, qRight)
            );
        }

        public long Value(int qLeft, int qRight)
            => (long)QueryMax(1, 0, n - 1, qLeft, qRight) - QueryMin(1, 0, n - 1, qLeft, qRight);
    }
}
