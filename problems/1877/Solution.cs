#if DEBUG
namespace Problems_1877;
#endif

public class Solution
{
    public int MinPairSum(int[] nums)
    {
        Array.Sort(nums);
        int ans = 0;
        int n = nums.Length;
        for (int i = 0; i < n / 2; i++)
        {
            ans = Math.Max(ans, nums[i] + nums[n - i - 1]);
        }
        return ans;
    }
}