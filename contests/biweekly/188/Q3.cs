public class Solution
{
    public long MinInitialStrength(int[] monsters, int[][] boosts)
    {
        int n = monsters.Length;
        long[] lines = new long[n + 1];
        foreach (int[] e in boosts)
        {
            int l = e[0], r = e[1], v = e[2];
            lines[l] += v;
            lines[r + 1] -= v;
        }
        long[] bonus = new long[n];
        long cur = 0;
        for (int i = 0; i < n; i++)
        {
            cur += lines[i];
            bonus[i] = cur;
        }
        long st = 0;
        int idx = n - 1;
        while (idx >= 0 && bonus[idx] >= monsters[idx]) idx--;
        if (idx >= 0)
        {
            st += monsters[idx] - bonus[idx];
            idx--;
        }
        for (int i = 0; i <= idx; i++)
        {
            st += monsters[i];
        }
        return st;
    }
}
