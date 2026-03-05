public class Solution
{
    public int MinOperations(string s)
    {
        int n = s.Length;
        int cnt = 0;
        // cnt: even is 0, odd is 1. Other is n - cnt.
        for (int i = 0; i < n; i++)
        {
            cnt += (s[i] == '0' + (i % 2)) ? 0 : 1;
        }

        return Math.Min(cnt, n - cnt);
    }
}