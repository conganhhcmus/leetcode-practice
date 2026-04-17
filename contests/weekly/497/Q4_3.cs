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

    bool Ok(int[] tree, int v, int p, int n, int pref, int suff)
    {
        if (GCD(pref, suff) == p)
            return true;
        if (v >= n)
            return false;

        if (Ok(tree, v << 1, p, n, pref, GCD(suff, tree[v << 1 | 1])))
            return true;
        return Ok(tree, v << 1 | 1, p, n, GCD(pref, tree[v << 1]), suff);
    }

    public int CountGoodSubseq(int[] nums, int p, int[][] queries)
    {
        int n = nums.Length;
        int[] tree = new int[2 * n];
        for (int i = 0; i < n; i++)
        {
            tree[n + i] = nums[i] % p == 0 ? nums[i] : 0;
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
            int i = idx + n;
            tree[i] = val % p == 0 ? val : 0;

            for (i >>= 1; i > 0; i >>= 1)
            {
                tree[i] = GCD(tree[i << 1], tree[i << 1 | 1]);
            }
            if (tree[1] != p)
                continue;
            if (Ok(tree, 1, p, n, 0, 0))
                ans++;
        }

        return ans;
    }
}
