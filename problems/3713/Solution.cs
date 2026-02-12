public class Solution
{
    public int LongestBalanced(string s)
    {
        int n = s.Length;
        int ans = 0;
        for (int i = 0; i < n; i++)
        {
            int[] freq = new int[26];
            for (int j = i; j < n; j++)
            {
                freq[s[j] - 'a']++;

                if (IsValid(freq))
                {
                    ans = Math.Max(ans, j - i + 1);
                }
            }
        }
        return ans;
    }

    bool IsValid(int[] freq)
    {
        int count = 0;
        for (int i = 0; i < 26; i++)
        {
            if (freq[i] == 0) continue;
            if (count == 0)
            {
                count = freq[i];
            }
            else
            {
                if (count != freq[i]) return false;
            }
        }
        return true;
    }
}