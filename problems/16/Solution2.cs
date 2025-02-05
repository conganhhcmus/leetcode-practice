#if DEBUG
namespace Problems_16_2;
#endif

public class Solution
{
    public int ThreeSumClosest(int[] nums, int target)
    {
        int n = nums.Length;
        Array.Sort(nums);
        int ans = int.MinValue / 2;
        for (int i = 0; i < n; i++)
        {
            if (i > 0 && nums[i] == nums[i - 1]) continue;
            int left = i + 1;
            int right = n - 1;
            while (left < right)
            {
                int sum = nums[left] + nums[right] + nums[i];
                if (Math.Abs(sum - target) < Math.Abs(ans - target)) ans = sum;
                if (sum == target) return ans;
                if (sum > target)
                {
                    right--;
                }
                else if (sum < target)
                {
                    left++;
                }
            }
        }

        return ans;
    }
}