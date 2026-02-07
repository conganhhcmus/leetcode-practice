public class Solution
{
    public string LongestSubsequenceRepeatedK(string s, int k)
    {
        int[] count = new int[26];
        foreach (char c in s)
        {
            count[c - 'a']++;
        }
        List<char> candidate = [];
        for (int i = 25; i >= 0; i--)
        {
            if (count[i] >= k)
            {
                candidate.Add((char)(i + 'a'));
            }
        }
        Queue<string> queue = [];
        foreach (char c in candidate)
        {
            queue.Enqueue(c.ToString());
        }
        string ret = string.Empty;
        while (queue.Count > 0)
        {
            string curr = queue.Dequeue();
            if (curr.Length > ret.Length)
            {
                ret = curr;
            }
            foreach (char c in candidate)
            {
                string next = curr + c;
                if (IsValid(s, next, k))
                {
                    queue.Enqueue(next);
                }
            }
        }
        return ret;
    }

    bool IsValid(string s, string t, int k)
    {
        int pos = 0, matched = 0;
        int m = t.Length;
        foreach (char c in s)
        {
            if (c == t[pos])
            {
                pos++;
                if (pos == m)
                {
                    matched++;
                    pos = 0;
                }
            }
        }
        return matched >= k;
    }
}