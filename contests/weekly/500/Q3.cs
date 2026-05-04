public class Solution
{
    public int[] MinCost(int[] nums, int[][] queries)
    {
        int n = nums.Length;
        int[] closest = new int[n];
        closest[0] = 1;
        closest[n - 1] = n - 2;
        for (int i = 1; i < n - 1; i++)
        {
            if (nums[i] - nums[i - 1] <= nums[i + 1] - nums[i])
            {
                closest[i] = i - 1;
            }
            else
            {
                closest[i] = i + 1;
            }
        }
        int[] prefix = new int[n];
        prefix[0] = 1;
        for (int i = 1; i < n; i++)
        {
            int cost = (closest[i - 1] == i) ? 1 : Math.Abs(nums[i] - nums[i - 1]);
            prefix[i] = prefix[i - 1] + cost;
        }
        int[] suffix = new int[n];
        suffix[n - 1] = 1;
        for (int i = n - 2; i >= 0; i--)
        {
            int cost = (closest[i + 1] == i) ? 1 : Math.Abs(nums[i] - nums[i + 1]);
            suffix[i] = suffix[i + 1] + cost;
        }
        int m = queries.Length;
        int[] ans = new int[m];
        for (int i = 0; i < m; i++)
        {
            int l = queries[i][0], r = queries[i][1];
            if (l < r)
            {
                ans[i] = prefix[r] - prefix[l];
            }
            else
            {
                ans[i] = suffix[r] - suffix[l];
            }
        }
        return ans;
    }
}
