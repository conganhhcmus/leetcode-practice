public class Solution
{
    public int MinFlips(string s)
    {
        int n = s.Length;
        int INF = 1 << 30;
        int mask = 16;
        int[] dp = new int[mask];
        Array.Fill(dp, INF);
        dp[0] = 0;
        foreach (char ch in s)
        {
            int[] ndp = new int[mask];
            Array.Fill(ndp, INF);
            for (int m = 0; m < mask; m++)
            {
                if (dp[m] == INF) continue;
                int z = m & 1;
                int o = (m >> 1) & 1;
                int oz = (m >> 2) & 1;
                int oo = (m >> 3) & 1;
                foreach (char c in new[] { '0', '1' })
                {
                    if (c == '1' && oz == 1) continue;
                    if (c == '0' && oo == 1) continue;
                    int nz = z, no = o, noz = oz, noo = oo;
                    if (c == '0')
                    {
                        nz = 1;
                    }
                    else
                    {
                        no = 1;
                        noz |= z;
                        noo |= o;
                    }
                    int nm = nz | (no << 1) | (noz << 2) | (noo << 3);
                    ndp[nm] = Math.Min(ndp[nm], dp[m] + (c != ch ? 1 : 0));
                }
            }
            dp = ndp;
        }

        int ans = n;
        for (int i = 0; i < mask; i++)
        {
            if (ans > dp[i]) ans = dp[i];
        }
        return ans;
    }
}
