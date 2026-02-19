public class Solution
{
    public int CountBinarySubstrings(string s)
    {
        int ans = 0;
        int n = s.Length;
        int count = 1;
        int prev = 0;
        for (int i = 1; i < n; i++)
        {
            if (s[i] == s[i - 1])
            {
                count++;
            }
            else
            {
                ans += Math.Min(prev, count);
                prev = count;
                count = 1;
            }
        }
        ans += Math.Min(prev, count);

        return ans;
    }
}