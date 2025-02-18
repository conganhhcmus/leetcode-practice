#if DEBUG
namespace Problems_2375;
#endif

public class Solution
{
    public string SmallestNumber(string pattern)
    {
        bool[] chosen = new bool[10];
        return BackTracking(pattern, "", chosen);
    }

    private string BackTracking(string pattern, string ans, bool[] chosen)
    {
        if (ans.Length >= pattern.Length + 1)
        {
            if (Check(pattern, ans)) return ans;
            return null;
        }

        for (int i = 1; i < 10; i++)
        {
            if (chosen[i]) continue;
            chosen[i] = true;
            string res = BackTracking(pattern, ans + (char)(i + '0'), chosen);
            if (res != null) return res;
            chosen[i] = false;
        }

        return null;
    }

    private bool Check(string pattern, string ans)
    {
        int n = pattern.Length;
        if (ans.Length != n + 1) return false;
        for (int i = 0; i < n; i++)
        {
            if (pattern[i] == 'I' && ans[i] >= ans[i + 1]) return false;
            if (pattern[i] == 'D' && ans[i] <= ans[i + 1]) return false;
        }
        return true;
    }
}