#if DEBUG
namespace Problems_712;
#endif

public class Solution
{
    public int MinimumDeleteSum(string s1, string s2)
    {
        return DP(0, 0, s1, s2);
    }

    Dictionary<(int, int), int> memo = [];

    int DP(int p1, int p2, string s1, string s2)
    {
        if (p1 >= s1.Length || p2 >= s2.Length)
        {
            int ans = 0;
            for (int i = p1; i < s1.Length; i++)
            {
                ans += s1[i];
            }
            for (int i = p2; i < s2.Length; i++)
            {
                ans += s2[i];
            }
            return ans;
        }

        var key = (p1, p2);
        if (memo.TryGetValue(key, out int cache)) return cache;

        if (s1[p1] == s2[p2])
        {
            return memo[key] = DP(p1 + 1, p2 + 1, s1, s2);
        }

        return memo[key] = Math.Min(s1[p1] + DP(p1 + 1, p2, s1, s2), s2[p2] + DP(p1, p2 + 1, s1, s2));
    }
}