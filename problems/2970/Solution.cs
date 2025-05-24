#if DEBUG
namespace Problems_2970;
#endif

public class Solution
{
    public int IncremovableSubarrayCount(int[] nums)
    {
        int n = nums.Length;
        int ret = 0;
        for (int i = 0; i < n; i++)
        {
            for (int j = i; j < n; j++)
            {
                if (IsIncreasing(nums, i, j))
                {
                    ret++;
                }
            }
        }
        return ret;
    }

    bool IsIncreasing(int[] nums, int left, int right)
    {
        int n = nums.Length;
        for (int i = 0; i + 1 < left; i++)
        {
            if (nums[i] >= nums[i + 1]) return false;
        }
        for (int i = right + 1; i + 1 < n; i++)
        {
            if (nums[i] >= nums[i + 1]) return false;
        }
        if (left - 1 >= 0 && right + 1 < n)
        {
            return nums[left - 1] < nums[right + 1];
        }
        return true;
    }
}