public class Solution
{
    public long MinPartitionScore(int[] nums, int k)
    {
        int n = nums.Length, h, t;
        long[] s = new long[n + 1], d = new long[n + 1], e = new long[n + 1];
        for (int i = 0; i < n; i++) s[i + 1] = s[i] + nums[i];
        for (int i = 1; i <= n; i++) d[i] = 1L << 60;
        int[] q = new int[n + 1];

        for (int j = 1; j <= k; j++)
        {
            h = 0; t = -1;
            for (int i = 0; i <= n; i++) e[i] = 1L << 60;
            for (int i = 1; i <= n; i++)
            {
                int p = i - 1;
                if (d[p] < 1L << 59)
                {
                    long y = 2 * d[p] + s[p] * s[p] - s[p];
                    while (t > h)
                    {
                        long y2 = 2 * d[q[t]] + s[q[t]] * s[q[t]] - s[q[t]];
                        long y1 = 2 * d[q[t - 1]] + s[q[t - 1]] * s[q[t - 1]] - s[q[t - 1]];
                        if ((decimal)(y2 - y1) * (s[p] - s[q[t]]) >= (decimal)(y - y2) * (s[q[t]] - s[q[t - 1]])) t--;
                        else break;
                    }
                    q[++t] = p;
                }
                while (h < t)
                {
                    long y1 = 2 * d[q[h]] + s[q[h]] * s[q[h]] - s[q[h]];
                    long y2 = 2 * d[q[h + 1]] + s[q[h + 1]] * s[q[h + 1]] - s[q[h + 1]];
                    if (y1 - 2 * s[q[h]] * s[i] >= y2 - 2 * s[q[h + 1]] * s[i]) h++;
                    else break;
                }
                if (h <= t)
                {
                    int x = q[h];
                    long v = s[i] - s[x];
                    e[i] = d[x] + v * (v + 1) / 2;
                }
            }
            Array.Copy(e, d, n + 1);
        }
        return d[n];
    }
}
