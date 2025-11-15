#if DEBUG
namespace Problems_3234;
#endif

public class Solution
{
    public int NumberOfSubstrings(string s)
    {
        int n = s.Length;
        int[] pre = new int[n + 1];
        pre[0] = -1;
        for (int i = 0; i < n; i++)
        {
            if (i == 0 || s[i - 1] == '0')
            {
                pre[i + 1] = i;
            }
            else
            {
                pre[i + 1] = pre[i];
            }
        }
        int ans = 0;
        for (int i = 1; i <= n; i++)
        {
            int zeros = '1' - s[i - 1];
            int j = i;
            while (j > 0 && zeros * zeros <= n)
            {
                int ones = i - pre[j] - zeros;
                if (zeros * zeros <= ones)
                {
                    ans += Math.Min(j - pre[j], ones - zeros * zeros + 1);
                }
                j = pre[j];
                zeros++;
            }
        }
        return ans;
    }
}