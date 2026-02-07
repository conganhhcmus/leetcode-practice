public class Solution
{
    public int MinDeletionSize(string[] strs)
    {
        int n = strs.Length, m = strs[0].Length;
        int ans = 0;
        for (int i = 0; i < m; i++)
        {
            for (int j = 1; j < n; j++)
            {
                if (strs[j][i] < strs[j - 1][i])
                {
                    ans++;
                    break;
                }
            }
        }
        return ans;
    }
}