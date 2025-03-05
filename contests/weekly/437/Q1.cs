#if DEBUG
namespace Contests_437_Q1;
#endif

public class Solution
{
    public bool HasSpecialSubstring(string s, int k)
    {
        int n = s.Length;
        int count = 1;
        for (int i = 1; i < n; i++)
        {
            if (s[i] == s[i - 1]) count++;
            else
            {
                if (count == k) return true;
                count = 1;
            }
        }

        return count == k;
    }
}