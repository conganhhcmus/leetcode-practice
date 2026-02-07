public class Solution
{
    public int MaximumWealth(int[][] accounts)
    {
        int ret = 0;
        int n = accounts.Length, m = accounts[0].Length;
        for (int i = 0; i < n; i++)
        {
            int sum = 0;
            for (int j = 0; j < m; j++)
            {
                sum += accounts[i][j];
            }
            ret = Math.Max(ret, sum);
        }

        return ret;
    }
}