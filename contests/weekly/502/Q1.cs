public class Solution
{
    public bool IsAdjacentDiffAtMostTwo(string s)
    {
        int n = s.Length;
        for (int i = 1; i < n; i++)
        {
            if (Math.Abs(s[i] - s[i - 1]) > 2) return false;
        }
        return true;
    }
}
