public class Solution
{
    public int MinimumDeletions(string s)
    {
        int ans = 0;
        int count = 0;
        foreach (char c in s)
        {
            if (c == 'b')
            {
                count++;
            }
            else
            {
                ans = Math.Min(ans + 1, count);
            }
        }
        return ans;
    }
}