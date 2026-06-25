public class Solution
{
    public long CountMajoritySubarrays(int[] nums, int target)
    {
        int n = nums.Length;
        // cnt[t] = x => max len = 2*x-1
        // 2* cnt[i+1] - 2 * cnt[j] > i+1 - j
        // 2 * cnt[i+1] - (i + 1) > 2 * cnt[j] - j
        // each i count all j satify that
        int[] pref = new int[n + 1];
        for (int i = 0; i < n; i++)
        {
            pref[i + 1] = pref[i] + (nums[i] == target ? 1 : 0);
        }
        long ans = 0L;
        int MAX = 100_000;
        Fenwick tree = new(2 * MAX + 1);
        // init default
        tree.Update(MAX, 1);
        for (int i = 0; i < n; i++)
        {
            int t = 2 * pref[i + 1] - (i + 1) + MAX;
            ans += tree.Query(t - 1);

            tree.Update(t, 1);
        }

        return ans;
    }

    public class Fenwick
    {
        private int[] tree;
        private int sz;

        public Fenwick(int n)
        {
            sz = n;
            tree = new int[sz + 1];
        }

        public int Query(int i)
        {
            i++;
            int sum = 0;
            while (i > 0)
            {
                sum += tree[i];
                i -= i & -i;
            }

            return sum;
        }

        public void Update(int i, int v)
        {
            i++;
            while (i <= sz)
            {
                tree[i] += v;
                i += i & -i;
            }
        }
    }
}
