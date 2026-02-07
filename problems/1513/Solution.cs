public class Solution
{
    public int NumSub(string s)
    {
        int mod = (int)1e9 + 7;
        long ans = 0;
        int count = 0;
        foreach (char c in s)
        {
            if (c == '1')
            {
                count++;
                ans = (ans + count) % mod;
            }
            else
            {
                count = 0;
            }
        }

        return (int)ans;
    }
}