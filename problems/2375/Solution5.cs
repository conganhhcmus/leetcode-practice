#if DEBUG
namespace Problems_2375_5;
#endif

public class Solution
{
    public string SmallestNumber(string pattern)
    {
        int n = pattern.Length;
        char[] ans = new char[n + 1];
        int prev = 0;
        for (int i = 0; i <= n; i++)
        {
            ans[i] = (char)(i + '1');
            if (i == n || pattern[i] == 'I')
            {
                Array.Reverse(ans, prev, i - prev + 1);
                prev = i + 1;
            }
        }
        return new string(ans);
    }
}