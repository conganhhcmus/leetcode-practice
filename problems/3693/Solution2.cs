public class Solution
{
    public int ClimbStairs(int n, int[] costs)
    {
        int a = 0, b = 0, c = 0;
        int ans = 0;
        for (int i = 0; i < n; i++)
        {
            ans = costs[i] + Math.Min(a + 9, Math.Min(b + 4, c + 1));
            a = b;
            b = c;
            c = ans;
        }
        return ans;
    }
}