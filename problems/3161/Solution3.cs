public class Solution
{
    public IList<bool> GetResults(int[][] queries)
    {
        int MAX = 50000;
        int[] bit = new int[MAX + 1];
        void Update(int idx, int val)
        {
            while (idx < bit.Length)
            {
                bit[idx] = Math.Max(bit[idx], val);
                idx += idx & -idx;
            }
        }
        int Query(int idx)
        {
            int ans = 0;
            while (idx > 0)
            {
                ans = Math.Max(ans, bit[idx]);
                idx -= idx & -idx;
            }
            return ans;
        }
        SortedSet<int> st = [0, MAX];
        foreach (int[] q in queries)
        {
            if (q[0] == 1)
            {
                st.Add(q[1]);
            }
        }
        List<int> all = [.. st];
        int pre = 0;
        for (int i = 0; i < all.Count; i++)
        {
            int x = all[i];
            if (x == 0) continue;
            Update(x, x - pre);
            pre = x;
        }

        List<bool> ans = [];
        for (int i = queries.Length - 1; i >= 0; i--)
        {
            int[] q = queries[i];
            if (q[0] == 1)
            {
                int x = q[1];
                int idx = all.BinarySearch(x);
                int prev = idx > 0 ? all[idx - 1] : 0;
                int next = idx + 1 < all.Count ? all[idx + 1] : MAX;
                Update(next, next - prev);
                all.RemoveAt(idx);
            }
            else
            {
                int x = q[1];
                int sz = q[2];
                int idx = all.BinarySearch(x);
                if (idx < 0)
                {
                    idx = ~idx - 1;
                }
                int gap = Math.Max(x - all[idx], Query(all[idx]));
                ans.Add(gap >= sz);
            }
        }
        ans.Reverse();
        return ans;
    }
}
