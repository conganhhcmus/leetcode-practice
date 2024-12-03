namespace Problem_2914;

public class Solution
{
    public int MinChanges(string s)
    {
        int count = 0;
        for (int i = 1; i < s.Length; i += 2)
        {
            if (s[i] != s[i - 1]) count++;
        }
        return count;
    }
}