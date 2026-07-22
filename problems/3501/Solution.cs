public class Solution
{
    public IList<int> MaxActiveSectionsAfterTrade(string s, int[][] queries)
    {
        int n = s.Length, m = queries.Length;
        int ones = 0;
        List<int> zeroLens = [];
        List<int> zeroStart = [];
        int[] zeroId = new int[n];
        int id = -1;
        for (int i = 0; i < n; i++)
        {
            if (s[i] == '0')
            {
                if (i == 0 || s[i - 1] != '0')
                {
                    id++;
                    zeroStart.Add(i);
                    zeroLens.Add(0);
                }
                zeroLens[id]++;
            }
            else ones++;
            zeroId[i] = id;
        }
        int[] values = new int[Math.Max(0, zeroLens.Count - 1)];
        for (int i = 0; i + 1 < zeroLens.Count; i++)
        {
            values[i] = zeroLens[i] + zeroLens[i + 1];
        }
        SegmentTree tree = new(values);
        int[] ans = new int[m];
        for (int i = 0; i < m; i++)
        {
            int l = queries[i][0], r = queries[i][1];
            int gl = zeroId[l];
            int gr = zeroId[r];
            int left = s[l] == '0' ? zeroLens[gl] - (l - zeroStart[gl]) : -1;
            int right = s[r] == '0' ? (r - zeroStart[gr] + 1) : -1;

            int endGroupTemp = s[r] == '1' ? gr : gr - 1;
            int startAdj = gl + 1;
            int endAdj = endGroupTemp - 1;

            int best = ones;
            if (s[l] == '0' && s[r] == '0' && gl + 1 == gr)
            {
                best = Math.Max(best, ones + left + right);
            }
            else if (startAdj <= endAdj)
            {
                best = Math.Max(best, ones + tree.Query(startAdj, endAdj));
            }
            if (s[l] == '0' && gl + 1 <= endGroupTemp)
            {
                best = Math.Max(best, ones + left + zeroLens[gl + 1]);
            }

            if (s[r] == '0' && gl < gr - 1)
            {
                best = Math.Max(best, ones + right + zeroLens[gr - 1]);
            }
            ans[i] = best;
        }
        return ans;
    }

    class SegmentTree
    {
        int n;
        int[] tree;
        public SegmentTree(int[] nums)
        {
            n = nums.Length;
            if (n == 0)
            {
                tree = Array.Empty<int>();
                return;
            }
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

        public int Query(int qleft, int qright)
        {
            if (qleft > qright || n == 0) return 0;
            qleft = Math.Max(0, qleft);
            qright = Math.Min(n - 1, qright);
            return Query(1, 0, n - 1, qleft, qright);
        }

        int Query(int node, int left, int right, int qleft, int qright)
        {
            if (qleft > right || qright < left) return 0;
            if (qleft <= left && qright >= right) return tree[node];
            int mid = left + (right - left) / 2;
            int ans = 0;
            if (qleft <= mid) ans = Math.Max(ans, Query(2 * node, left, mid, qleft, qright));
            if (qright > mid) ans = Math.Max(ans, Query(2 * node + 1, mid + 1, right, qleft, qright));
            return ans;
        }
    }
}
