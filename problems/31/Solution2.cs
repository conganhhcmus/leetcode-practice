#if DEBUG
namespace Problems_31_2;
#endif

public class Solution
{
    public void NextPermutation(int[] nums)
    {
        int n = nums.Length;
        int i = n - 1;
        while (i > 0 && nums[i - 1] >= nums[i])
        {
            i--;
        }

        if (i == 0)
        {
            Array.Reverse(nums);
            return;
        }

        int j = n - 1;
        while (j >= i && nums[j] <= nums[i - 1])
        {
            j--;
        }

        (nums[i - 1], nums[j]) = (nums[j], nums[i - 1]);
        Array.Reverse(nums, i, n - i);
    }
}