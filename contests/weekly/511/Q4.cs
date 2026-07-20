using System.Text;

public class Solution
{
    public int MinimumGroups(string[] words)
    {
        int n = words.Length;
        Dictionary<string, int> map = [];
        int g = 0;
        for (int i = 0; i < n; i++)
        {
            string key = BuildKey(words[i]);
            if (!map.ContainsKey(key))
            {
                map[key] = g++;
            }
        }

        return g;

        string BuildKey(string s)
        {
            StringBuilder even = new();
            StringBuilder odd = new();
            for (int i = 0; i < s.Length; i++)
            {
                if (i % 2 == 0) even.Append(s[i]);
                else odd.Append(s[i]);
            }

            return MinRotation(even.ToString()) + '#' + MinRotation(odd.ToString());
        }

        string MinRotation(string s)
        {
            int n = s.Length;
            if (n <= 1) return s;
            string ss = s + s;
            int i = 0, j = 1, k = 0;
            while (i < n && j < n && k < n)
            {
                char a = ss[i + k];
                char b = ss[j + k];
                if (a == b)
                {
                    k++;
                    continue;
                }
                if (a > b)
                {
                    i += k + 1;
                    if (i <= j) i = j + 1;
                }
                else
                {
                    j += k + 1;
                    if (j <= i) j = i + 1;
                }
                k = 0;
            }
            int start = Math.Min(i, j);
            return ss.Substring(start, n);
        }
    }
}
