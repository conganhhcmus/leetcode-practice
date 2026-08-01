public class Solution
{
    public bool PredictTheWinner(int[] nums)
    {
        return Dfs(0, nums.Length - 1, 0, 0, 1);
        bool Dfs(int l, int r, long p1, long p2, int t)
        {
            if (l > r) return p1 >= p2;
            if (t > 0)
            {
                return Dfs(l + 1, r, p1 + nums[l], p2, -t) || Dfs(l, r - 1, p1 + nums[r], p2, -t);
            }
            else
            {
                return Dfs(l + 1, r, p1, p2 + nums[l], -t) && Dfs(l, r - 1, p1, p2 + nums[r], -t);
            }
        }
    }
}
