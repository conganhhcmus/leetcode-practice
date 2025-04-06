#if DEBUG
using System.Runtime.Intrinsics.Arm;

namespace Weekly_444_Q3;
#endif

public class Solution
{
    public int MaxProduct(int[] nums, int k, int limit)
    {
        int sum = 0;
        foreach (int num in nums) sum += num;
        if (Math.Abs(k) > sum) return -1;
        return DP(nums, limit, k, 0, 0, 0, 0);
    }

    Dictionary<(int, int, int, int), int> memo = [];

    int DP(int[] nums, int limit, int k, int pos, int sum, int product, int sign)
    {
        if (pos >= nums.Length)
        {
            if (sum == k && product <= limit && sign != 0) return product;
            return -1;
        }

        var key = (pos, sum, product, sign);
        if (memo.TryGetValue(key, out int value)) return value;
        int ans = DP(nums, limit, k, pos + 1, sum, product, sign);
        if (sign == 0)
        {
            ans = Math.Max(ans, DP(nums, limit, k, pos + 1, nums[pos], nums[pos], 1));
        }
        else if (sign == 1)
        {
            ans = Math.Max(ans, DP(nums, limit, k, pos + 1, sum - nums[pos], Math.Min(product * nums[pos], limit + 1), 2));
        }
        else if (sign == 2)
        {
            ans = Math.Max(ans, DP(nums, limit, k, pos + 1, sum + nums[pos], Math.Min(product * nums[pos], limit + 1), 1));
        }
        memo[key] = ans;
        return ans;
    }
}