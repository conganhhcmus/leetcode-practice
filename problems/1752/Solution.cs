#if DEBUG
namespace Problems_1752;
#endif

public class Solution
{
    public bool Check(int[] nums)
    {
        int pos = -1, n = nums.Length;
        if (n == 1) return true;
        for (int i = 1; i < n; i++)
        {
            if (nums[i] < nums[i - 1])
            {
                pos = i;
                break;
            }
        }
        if (pos == -1) return true;
        if (nums[pos] > nums[0]) return false;
        for (int i = pos + 1; i < n; i++)
        {
            if (nums[i] < nums[i - 1] || nums[i] > nums[0]) return false;
        }
        return true;
    }
}