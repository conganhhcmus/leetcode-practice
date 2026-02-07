public class Solution
{
    public int ClimbStairs(int n)
    {
        // f[i]: number of way can to climb to i
        // f[0] = 1
        // f[1] = 1
        // f[i] = f[i-1] + f[i-2]
        int[] f = new int[n + 1];
        f[0] = f[1] = 1;
        for (int i = 2; i <= n; i++)
        {
            f[i] = f[i - 1] + f[i - 2];
        }
        return f[n];
    }
}