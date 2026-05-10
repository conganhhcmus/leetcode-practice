public class Solution
{
    public char FindTheDifference(string s, string t)
    {
        int[] count = new int[26];
        foreach (char c in s)
        {
            count[c - 'a']++;
        }
        foreach (char c in t)
        {
            count[c - 'a']--;
            if (count[c - 'a'] < 0) return c;
        }
        return '#';
    }
}
