public class Solution
{
    public bool CanConstruct(string ransomNote, string magazine)
    {
        int[] freq = new int[26];
        foreach (char c in magazine)
        {
            freq[c - 'a']++;

        }
        foreach (char c in ransomNote)
        {
            freq[c - 'a']--;
            if (freq[c - 'a'] < 0)
            {
                return false;
            }
        }

        return true;
    }
}