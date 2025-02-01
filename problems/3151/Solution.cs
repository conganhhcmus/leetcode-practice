#if DEBUG
namespace Problems_3151;
#endif

public class Solution
{
    public bool IsArraySpecial(int[] nums)
    {
        int n = nums.Length;
        if (n == 1) return true;
        for (int i = 1; i < n; i++)
        {
            if ((nums[i] + nums[i - 1]) % 2 == 0) return false;
        }
        return true;
    }
}