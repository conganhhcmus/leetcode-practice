public class Solution
{
    public int MinOperations(int[] nums, int k)
    {
        int n = nums.Length;
        int ans = 1 << 30;
        for (int x = 0; x < k; x++)
        {
            for (int y = 0; y < k; y++)
            {
                if (x == y) continue;
                int need = 0;
                int t = x;
                for (int i = 0; i < n; i++)
                {
                    int d = Math.Abs(nums[i] % k - t);
                    need += Math.Min(d, k - d);
                    t = t ^ x ^ y;
                }
                ans = Math.Min(ans, need);
            }
        }
        return ans;
    }
}
