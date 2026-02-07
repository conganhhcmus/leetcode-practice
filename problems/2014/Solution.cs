public class Solution
{
    string ret = string.Empty;
    public string LongestSubsequenceRepeatedK(string s, int k)
    {
        if (k == 1) return s;
        int[] count = new int[26];
        foreach (char c in s)
        {
            count[c - 'a']++;
        }
        List<char> candicate = [];
        for (int i = 25; i >= 0; i--)
        {
            if (count[i] >= k)
            {
                candicate.Add((char)(i + 'a'));
            }
        }
        Backtracking(candicate, string.Empty, s, k);

        return ret;
    }

    void Backtracking(List<char> candidate, string curr, string s, int k)
    {
        if (IsValid(s, curr, k))
        {
            if (curr.Length > ret.Length)
            {
                ret = curr;
            }
            foreach (char c in candidate)
            {
                Backtracking(candidate, curr + c, s, k);
            }
        }
    }

    bool IsValid(string s, string t, int k)
    {
        StringBuilder sb = new();
        while (k-- > 0)
        {
            sb.Append(t);
        }
        t = sb.ToString();
        int n = s.Length, m = t.Length;
        int i = 0, j = 0;
        while (i < n && j < m)
        {
            if (s[i] == t[j])
            {
                i++;
                j++;
            }
            else
            {
                i++;
            }
        }
        return j == m;
    }
}