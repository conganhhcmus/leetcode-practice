public class Solution
{
    public int PrefixConnected(string[] words, int k)
    {
        Array.Sort(words);
        int n = words.Length;
        int count = 1;
        int ans = 0;
        for (int i = 1; i < n; i++)
        {
            if (IsConnected(words[i], words[i - 1], k))
            {
                count++;
            }
            else
            {
                if (count > 1) ans++;
                count = 1;
            }
        }
        if (count > 1) ans++;
        return ans;
    }

    bool IsConnected(string a, string b, int k)
    {
        if (a.Length < k || b.Length < k) return false;
        for (int i = 0; i < k; i++)
        {
            if (a[i] != b[i]) return false;
        }
        return true;
    }
}