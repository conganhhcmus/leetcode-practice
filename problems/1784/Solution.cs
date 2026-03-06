public class Solution
{
    public bool CheckOnesSegment(string s)
    {
        bool existed = false;
        int n = s.Length;
        for (int i = 1; i < n; i++)
        {
            if (s[i] == s[i - 1]) continue;
            if (existed) return false;
            existed = true;
        }
        return true;
    }
}