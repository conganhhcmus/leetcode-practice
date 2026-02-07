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
        int[] ans = new int[queries.Length];
        for (int i = 0; i < queries.Length; i++)
        {
            long val = 1L;
            for (int j = queries[i][0]; j <= queries[i][1]; j++)
            {
                val = val * powers[j] % mod;
            }
            ans[i] = (int)val;
        }
        return ans;
    }
}