public class Solution
{
    public IList<IList<int>> PalindromePairs(string[] words)
    {
        int n = words.Length;
        IList<IList<int>> ans = [];
        Dictionary<string, int> d = [];
        for (int i = 0; i < n; i++) d[words[i]] = i;
        for (int i = 0; i < n; i++)
        {
            int m = words[i].Length;
            string rev = Reverse(words[i]);
            if (d.TryGetValue(rev, out int j1) && i != j1) ans.Add([i, j1]);
            for (int j = 0; j < m; j++)
            {
                if (IsPalindrome(rev, 0, m - 1 - j) && d.TryGetValue(rev[(m - j)..], out int j2)) ans.Add([i, j2]);
                if (IsPalindrome(rev, j, m - 1) && d.TryGetValue(rev[..j], out int j3)) ans.Add([j3, i]);
            }
        }
        return ans;
    }

    bool IsPalindrome(string s, int lo, int hi)
    {
        while (lo < hi)
        {
            if (s[lo++] != s[hi--]) return false;
        }
        return true;
    }

    string Reverse(string s)
    {
        char[] arr = s.ToCharArray();
        Array.Reverse(arr);
        return new(arr);
    }
}
