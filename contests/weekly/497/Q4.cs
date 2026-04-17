public class Solution
{
    int GCD(int a, int b)
    {
        while (b != 0)
        {
            (a, b) = (b, a % b);
        }
        return a;
    }

    bool Ok(int[] nums, int p)
    {
        int n = nums.Length;
        if (n <= 1)
            return false;
        int[] pref = new int[n];
        int[] suff = new int[n];
        pref[0] = nums[0];
        for (int i = 1; i < n; i++)
        {
            pref[i] = GCD(pref[i - 1], nums[i]);
        }

        suff[n - 1] = nums[n - 1];
        for (int i = n - 2; i >= 0; i--)
        {
            suff[i] = GCD(suff[i + 1], nums[i]);
        }

        for (int i = 0; i < n; i++)
        {
            int l = i > 0 ? pref[i - 1] : 0;
            int r = i + 1 < n ? suff[i + 1] : 0;
            if (GCD(l, r) == p)
                return true;
        }

        return false;
    }

    public int CountGoodSubseq(int[] nums, int p, int[][] queries)
    {
        int n = nums.Length;
        int[] tree = new int[2 * n];
        int count = 0;
        for (int i = 0; i < n; i++)
        {
            if (nums[i] % p == 0)
            {
                tree[n + i] = nums[i];
                count++;
            }
        }
        for (int i = n - 1; i > 0; i--)
        {
            tree[i] = GCD(tree[i << 1], tree[i << 1 | 1]);
        }
        int ans = 0;
        foreach (int[] q in queries)
        {
            int idx = q[0],
                val = q[1];
            nums[idx] = val;
            int i = idx + n;
            if (tree[i] > 0)
                count--;
            if (val % p == 0)
            {
                count++;
                tree[i] = val;
            }
            else
            {
                tree[i] = 0;
            }
            for (i >>= 1; i > 0; i >>= 1)
            {
                tree[i] = GCD(tree[i << 1], tree[i << 1 | 1]);
            }
            if (tree[1] != p)
                continue;
            if (count < n || n > 30 || Ok(nums, p))
                ans++;
        }

        return ans;
    }
}
