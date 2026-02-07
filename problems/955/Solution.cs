public class Solution
{
    public int MinDeletionSize(string[] strs)
    {
        int n = strs.Length, m = strs[0].Length;
        int ans = 0;
        bool[] cuts = new bool[n];
        for (int col = 0; col < m; col++)
        {
            bool isCorrect = true;
            for (int row = 1; row < n; row++)
            {
                if (cuts[row]) continue;
                if (strs[row][col] < strs[row - 1][col])
                {
                    isCorrect = false;
                    break;
                }
            }
            if (!isCorrect)
            {
                ans++;
                continue;
            }
            for (int row = 1; row < n; row++)
            {
                if (strs[row][col] > strs[row - 1][col])
                {
                    cuts[row] = true;
                }
            }
        }
        return ans;
    }
}