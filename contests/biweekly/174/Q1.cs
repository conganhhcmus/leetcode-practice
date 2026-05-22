public class Solution
{
    public int[] BestTower(int[][] towers, int[] center, int radius)
    {
        int max = -1;
        int[] ans = [-1, -1];
        foreach (int[] t in towers)
        {
            int d = Math.Abs(t[0] - center[0]) + Math.Abs(t[1] - center[1]);
            if (d <= radius)
            {
                if (t[2] > max)
                {
                    max = t[2];
                    ans = [t[0], t[1]];
                }
                else if (t[2] == max)
                {
                    if (t[0] < ans[0] || (t[0] == ans[0] && t[1] < ans[1]))
                    {
                        ans = [t[0], t[1]];
                    }
                }
            }
        }
        return ans;
    }
}
