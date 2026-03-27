public class Solution
{
    int t2 = 0, t3 = 0, t5 = 0;
    int[] c2, c3, c5;

    public int CountSequences(int[] nums, long k)
    {
        while (k > 0 && k % 5 == 0)
        {
            t5++;
            k /= 5;
        }

        while (k > 0 && k % 3 == 0)
        {
            t3++;
            k /= 3;
        }

        while (k > 0 && k % 2 == 0)
        {
            t2++;
            k /= 2;
        }

        if (k != 1 || t5 > 19 || t3 > 19 || t2 > 38) return 0;
        int n = nums.Length;
        c2 = new int[n];
        c3 = new int[n];
        c5 = new int[n];
        for (int i = 0; i < n; i++)
        {
            int v = nums[i];
            c2[i] = (v == 2 || v == 6) ? 1 : (v == 4) ? 2 : 0;
            c3[i] = (v == 3 || v == 6) ? 1 : 0;
            c5[i] = (v == 5) ? 1 : 0;
        }

        return DP(0, 0, 0, 0, n);
    }

    Dictionary<(int, int, int, int), int> memo = [];

    int DP(int pos, int x2, int x3, int x5, int n)
    {
        if (pos >= n)
        {
            return (x2 == t2 && x3 == t3 && x5 == t5) ? 1 : 0;
        }
        var key = (pos, x2, x3, x5);
        if (memo.TryGetValue(key, out int cache)) return cache;
        int ans = 0;
        // skip
        ans += DP(pos + 1, x2, x3, x5, n);
        // mul
        ans += DP(pos + 1, x2 + c2[pos], x3 + c3[pos], x5 + c5[pos], n);
        // div
        ans += DP(pos + 1, x2 - c2[pos], x3 - c3[pos], x5 - c5[pos], n);

        return memo[key] = ans;
    }
}