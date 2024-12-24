#if DEBUG
namespace Problems_30;
#endif

public class Solution
{
    public IList<int> FindSubstring(string s, string[] words)
    {
        int n = s.Length, size = words[0].Length, len = words.Length;
        if (n < len * size) return [];

        Dictionary<string, int> freq = [];
        foreach (string word in words)
        {
            freq[word] = freq.GetValueOrDefault(word, 0) + 1;
        }

        IList<int> ans = [];
        for (int i = 0; i < size; i++)
        {
            int left = i, right = i;
            Dictionary<string, int> cloned = new(freq);
            while (right + size <= n)
            {
                while (left + size <= n && !cloned.ContainsKey(s.Substring(left, size))) left += size;
                while (right + size <= n && !cloned.ContainsKey(s.Substring(right, size))) right += size;

                while (right + size <= n && cloned.GetValueOrDefault(s.Substring(right, size), 0) > 0)
                {
                    cloned[s.Substring(right, size)]--;
                    right += size;
                }

                if (Ok(cloned))
                {
                    ans.Add(left);
                }

                if (right + size > n) break;

                while (left <= right && cloned.GetValueOrDefault(s.Substring(right, size), 0) == 0)
                {
                    if (cloned.ContainsKey(s.Substring(left, size)))
                    {
                        cloned[s.Substring(left, size)]++;
                    }
                    left += size;
                }
            }
        }

        return ans;
    }

    private bool Ok(Dictionary<string, int> freq)
    {
        foreach (string word in freq.Keys)
        {
            if (freq[word] != 0) return false;
        }
        return true;
    }
}