#if DEBUG
namespace Problems_3637;
#endif

public class Solution
{
    public bool IsTrionic(int[] nums)
    {
        int count = 0;
        int n = nums.Length;
        bool state = true;
        int i = 1, j = 0;
        while (i < n)
        {
            if ((state && nums[i] > nums[i - 1]) || (!state && nums[i] < nums[i - 1]))
            {
                i++;
                continue;
            }
            if (i - j <= 1) return false;
            state = !state;
            count++;
            j = i - 1;
        }

        return count == 2;
    }
}