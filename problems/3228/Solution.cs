#if DEBUG
namespace Problems_3228;
#endif

public class Solution
{
    public int MaxOperations(string s)
    {
        int n = s.Length;
        int count = s[0] - '0';
        int ans = 0;
        for (int i = 1; i < n; i++)
        {
            count += s[i] - '0';
            if (s[i] == s[i - 1]) continue;
            if (s[i] == '0')
            {
                ans += count;
            }
        }

        return ans;
    }
}