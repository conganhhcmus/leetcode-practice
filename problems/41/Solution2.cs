#if DEBUG
namespace Problems_41_2;
#endif

public class Solution
{
    public int FirstMissingPositive(int[] nums)
    {
        // Cyclic Sort
        int n = nums.Length;
        int i = 0;
        while (i < n)
        {
            int idx = nums[i] - 1;
            if (idx >= 0 && idx < n && nums[i] != nums[idx])
            {
                (nums[i], nums[idx]) = (nums[idx], nums[i]);
            }
            else i++;
        }

        for (int j = 0; j < n; j++)
        {
            if (nums[j] != j + 1) return j + 1;
        }

        return n + 1;
    }
}