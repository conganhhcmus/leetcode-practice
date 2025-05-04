#if DEBUG
namespace Problems_2311_3;
#endif

public class Solution
{
    public int LongestSubsequence(string s, int k)
    {
        int n = s.Length;
        int ret = 0;
        int power = 1;
        int value = 0;
        for (int i = n - 1; i >= 0; i--)
        {
            if (s[i] == '1')
            {
                if (value + power <= k)
                {
                    value += power;
                    ret++;
                }
            }
            else
            {
                ret++;
            }
            if (power <= k)
            {
                power *= 2;
            }
        }
        return ret;
    }
}