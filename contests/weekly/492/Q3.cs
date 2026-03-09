public class Solution
{
    public int MinOperations(string s)
    {
        int n = s.Length;
        if (n == 2 && s[0] > s[1]) return -1;
        string t = Sort(s);
        if (IsSame(s, t)) return 0;
        // a.... or ...z
        if (s[0] == t[0] || s[^1] == t[^1]) return 1;
        // z....a
        if (s[0] == t[^1] && t[0] == s[^1])
        {
            // has smallest character or largest character
            for (int i = 1; i < n - 1; i++)
            {
                if (s[i] == t[0] || s[i] == t[^1]) return 2;
            }
            return 3;
        }
        return 2;
    }

    string Sort(string s)
    {
        char[] arr = s.ToCharArray();
        Array.Sort(arr);
        return new(arr);
    }

    bool IsSame(string s, string t)
    {
        int n = s.Length;
        for (int i = 0; i < n; i++)
        {
            if (s[i] != t[i]) return false;
        }
        return true;
    }
}