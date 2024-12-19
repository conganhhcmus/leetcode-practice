#if DEBUG
namespace Problems_15;
#endif

public class Solution
{
    public IList<IList<int>> ThreeSum(int[] nums)
    {
        int n = nums.Length;
        Array.Sort(nums);
        IList<IList<int>> result = [];
        for (int i = 0; i < n; i++)
        {
            if (i > 0 && nums[i] == nums[i - 1]) continue;
            int left = i + 1;
            int right = n - 1;
            while (left < right)
            {
                int total = nums[left] + nums[right] + nums[i];
                if (total > 0)
                {
                    right--;
                }
                else if (total < 0)
                {
                    left++;
                }
                else
                {
                    result.Add([nums[i], nums[left], nums[right]]);
                    left++;
                    right--;
                    while (left < right && nums[left] == nums[left - 1]) left++;
                }
            }
        }

        return result;
    }
}