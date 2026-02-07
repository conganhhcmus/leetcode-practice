public class Solution
{
    public int TupleSameProduct(int[] nums)
    {
        Array.Sort(nums);
        int n = nums.Length;
        int ans = 0;
        Dictionary<double, int> map = [];
        // a * b = c * d => a / c = d / b
        // a < c < d < b
        // a = nums[p], c = nums[q] , d = nums[r], b = nums[s], p < q < r < s
        map[(double)nums[0] / nums[1]] = 1;
        for (int r = 2; r < n - 1; r++)
        {
            for (int s = r + 1; s < n; s++)
            {
                double key = (double)nums[r] / nums[s];
                ans += map.GetValueOrDefault(key, 0);
            }

            for (int p = r - 1, q = r; p >= 0; p--)
            {
                double key = (double)nums[p] / nums[q];
                map[key] = map.GetValueOrDefault(key, 0) + 1;
            }
        }

        return 8 * ans; // 1 tuple have 8 ways to swap
    }
}