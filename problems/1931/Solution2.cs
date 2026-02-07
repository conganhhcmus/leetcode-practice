public class Solution
{
    int mod = (int)1e9 + 7;
    public int ColorTheGrid(int m, int n)
    {
        int fullMask = FastPower(3, m) - 1;
        List<int> validMask = [];
        int[][] decodeMask = new int[fullMask + 1][];
        for (int mask = 0; mask <= fullMask; mask++)
        {
            decodeMask[mask] = [];
        }

        for (int mask = 0; mask <= fullMask; mask++)
        {
            int[] colors = new int[m];
            int tmp = mask;
            for (int i = 0; i < m; i++)
            {
                colors[i] = tmp % 3;
                tmp /= 3;
            }

            bool valid = true;
            for (int i = 1; i < m; i++)
            {
                if (colors[i] == colors[i - 1])
                {
                    valid = false;
                    break;
                }
            }
            if (valid)
            {
                validMask.Add(mask);
                decodeMask[mask] = colors;
            }
        }

        List<int>[] nextMask = new List<int>[fullMask + 1];
        for (int mask = 0; mask <= fullMask; mask++)
        {
            nextMask[mask] = [];
        }

        foreach (int curr in validMask)
        {
            foreach (int next in validMask)
            {
                int[] currColor = decodeMask[curr];
                int[] nextColor = decodeMask[next];
                bool valid = true;
                for (int i = 0; i < m; i++)
                {
                    if (currColor[i] == nextColor[i])
                    {
                        valid = false;
                        break;
                    }
                }
                if (valid)
                {
                    nextMask[curr].Add(next);
                }
            }
        }

        long[] dp = new long[fullMask + 1];
        foreach (int curr in validMask)
        {
            dp[curr] = 1;
        }

        for (int col = 1; col < n; col++)
        {
            long[] nDp = new long[fullMask + 1];
            foreach (int curr in validMask)
            {
                foreach (int next in nextMask[curr])
                {
                    nDp[curr] = (nDp[curr] + dp[next]) % mod;
                }
            }

            dp = nDp;
        }

        long ret = 0;
        for (int mask = 0; mask <= fullMask; mask++)
        {
            ret = (ret + dp[mask]) % mod;
        }
        return (int)ret;
    }

    int FastPower(int a, int b)
    {
        int ret = 1;
        while (b > 0)
        {
            if ((b & 1) == 1) ret *= a;
            a *= a;
            b >>= 1;
        }
        return ret;
    }
}