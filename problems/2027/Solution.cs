public class Solution
{
    public int MinimumMoves(string s)
    {
        int n = s.Length;
        int ret = 0;
        for (int i = 0; i < n; i++)
        {
            if (s[i] == 'O') continue;
            ret++;
            i += 2;
        }

        return ret;
    }
}