public class Solution
{
    public int ReverseDegree(string s)
    {
        int ans = 0;
        for (int i = 0; i < s.Length; i++)
        {
            ans += (i + 1) * ('z' - s[i] + 1);
        }
        return ans;
    }
}