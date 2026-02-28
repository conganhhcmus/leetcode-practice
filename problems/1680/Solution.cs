public class Solution
{
    public int ConcatenatedBinary(int n)
    {
        long ans = 0;
        int mod = (int)1e9 + 7;
        int bitLen = 0;
        for (int i = 1; i <= n; i++)
        {
            // check i is the power of 2
            if ((i & (i - 1)) == 0) bitLen++;
            ans = (ans << bitLen | i) % mod;
        }
        return (int)ans;
    }
}