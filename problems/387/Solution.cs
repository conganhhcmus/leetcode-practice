public class Solution
{
    public int FirstUniqChar(string s)
    {
        int[] freq = new int[26];
        foreach (char ch in s)
        {
            freq[ch - 'a']++;
        }

        for (int i = 0; i < s.Length; i++)
        {
            if (freq[s[i] - 'a'] == 1) return i;
        }
        return -1;
    }
}