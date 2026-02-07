public class Solution
{
    int mod = (int)1e9 + 7;
    public int[] ProductQueries(int n, int[][] queries)
    {
        List<int> powers = [];
        int bits = 1;
        while (n >= bits)
        {
            if ((n & bits) != 0)
            {
                powers.Add(bits);
            }
            bits <<= 1;
        }
        int m = powers.Count;
        int[,] prefixCalc = new int[m, m];
        for (int i = 0; i < m; i++)
        {
            long cur = 1;
            for (int j = i; j < m; j++)
            {
                cur = cur * powers[j] % mod;
                prefixCalc[i, j] = (int)cur;
            }
        }
        int[] ans = new int[queries.Length];
        for (int i = 0; i < queries.Length; i++)
        {
            ans[i] = prefixCalc[queries[i][0], queries[i][1]];
        }
        return ans;
    }
}