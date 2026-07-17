public class Solution
{
    public long CountMajoritySubarrays(int[] nums, int target)
    {
        int n = nums.Length;
        // 2 * freq[t] > length of [l..r] 
        // bal = 0, +1 if equal t ortherwise -1
        Fenwick bit = new(2 * n + 1);
        int bal = 0;
        long ans = 0;
        bit.Add(n + 1, 1);
        for (int i = 0; i < n; i++)
        {
            if (nums[i] == target) bal++;
            else bal--;
            // cnt all x wher bal - x > 0 => bal > x
            // call all <= bal - 1
            bit.Add(bal + n + 1, 1);
            ans += bit.Query(bal + n);
        }
        return ans;
    }

    class Fenwick
    {
        long[] tree;
        int n;
        public Fenwick(int n)
        {
            this.n = n;
            tree = new long[n + 1];
        }
        public void Add(int idx, long delta)
        {
            while (idx <= n)
            {
                tree[idx] += delta;
                idx += idx & -idx;
            }
        }

        public long Query(int idx)
        {
            long res = 0;
            while (idx > 0)
            {
                res += tree[idx];
                idx -= idx & -idx;
            }
            return res;
        }
    }
}
