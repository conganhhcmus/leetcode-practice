#if DEBUG
namespace Problems_44;
#endif

public class Solution
{
    public bool IsMatch(string s, string p)
    {
        return DP(s, p, 0, 0);
    }
    Dictionary<(int, int), bool> memo = [];
    bool DP(string s, string p, int i, int j)
    {
        if (j >= p.Length) return i == s.Length;
        if (i >= s.Length) return IsAllStar(p, j);
        if (memo.TryGetValue((i, j), out bool cached)) return cached;
        bool ret;
        if (s[i] == p[j] || p[j] == '?')
        {
            ret = DP(s, p, i + 1, j + 1);
        }
        else if (p[j] == '*')
        {
            ret = DP(s, p, i, j + 1) || DP(s, p, i + 1, j) || DP(s, p, i + 1, j + 1);
        }
        else ret = false;
        memo[(i, j)] = ret;
        return ret;
    }

    bool IsAllStar(string s, int i)
    {
        while (i < s.Length)
        {
            if (s[i] != '*') return false;
            i++;
        }
        return true;
    }
}