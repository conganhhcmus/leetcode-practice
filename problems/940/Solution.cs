public class Solution
{
    public int DistinctSubseqII(string s)
    {
        int mod = (int)1e9 + 7;
        long dp = 1;
        long[] last = new long[26];
        foreach (char c in s)
        {
            int idx = c - 'a';
            long ndp = (2L * dp - last[idx] + mod) % mod;
            last[idx] = dp;
            dp = ndp;
        }
        return (int)((dp - 1 + mod) % mod);
    }
}
