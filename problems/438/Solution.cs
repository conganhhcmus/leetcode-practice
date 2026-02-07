public class Solution
{
    public IList<int> FindAnagrams(string s, string p)
    {
        int n = s.Length;
        int k = p.Length;
        int[] freq = new int[26];
        for (int i = 0; i < k; i++)
        {
            freq[p[i] - 'a']--;
        }

        IList<int> ret = [];
        for (int i = 0; i < n; i++)
        {
            freq[s[i] - 'a']++;
            if (i >= k)
            {
                freq[s[i - k] - 'a']--;
            }
            if (i >= k - 1 && Ok(freq))
            {
                ret.Add(i - k + 1);
            }
        }
        return ret;
    }

    bool Ok(int[] freq)
    {
        for (int i = 0; i < 26; i++)
        {
            if (freq[i] != 0)
            {
                return false;
            }
        }
        return true;
    }
}