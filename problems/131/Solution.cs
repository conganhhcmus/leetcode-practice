#if DEBUG
namespace Problems_131;
#endif

public class Solution
{
    public IList<IList<string>> Partition(string s)
    {
        IList<IList<string>> ret = [];
        BackTracking(ret, 0, s.Length, s, []);
        return ret;
    }

    void BackTracking(IList<IList<string>> ret, int pos, int n, string s, IList<string> curr)
    {
        if (pos >= n)
        {
            ret.Add([.. curr]);
            return;
        }
        for (int i = pos; i < n; i++)
        {
            string candidate = s[pos..(i + 1)];
            if (IsPalindrome(candidate))
            {
                curr.Add(candidate);
                BackTracking(ret, i + 1, n, s, curr);
                curr.RemoveAt(curr.Count - 1);
            }
        }
    }

    bool IsPalindrome(string s)
    {
        int n = s.Length;
        for (int i = 0; i <= n / 2; i++)
        {
            if (s[i] != s[n - 1 - i]) return false;
        }
        return true;
    }
}