#if DEBUG
namespace Contests_435_Q2;
#endif

public class Solution
{
    public int MaxDistance(string s, int k)
    {
        string[] dirs = ["NE", "NW", "SE", "SW"];
        int ans = 0, n = s.Length;
        foreach (string dir in dirs)
        {
            int curr = 0, remain = k;
            for (int i = 0; i < n; i++)
            {
                if (s[i] == dir[0] || s[i] == dir[1]) curr++;
                else if (remain > 0) { remain--; curr++; }
                else curr--;
                ans = Math.Max(ans, curr);
            }
        }
        return ans;
    }
}