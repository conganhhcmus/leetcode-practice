public class Solution
{
    public int LargestInteger(int n, int s)
    {
        if (9 * n < s) return -1;
        int ans = 0;
        for (int i = 0; i < n; i++)
        {
            int d = Math.Min(s, 9);
            ans = ans * 10 + d;
            s -= d;
        }
        return ans;
    }
}
