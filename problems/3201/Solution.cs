#if DEBUG
namespace Problems_3201;
#endif

public class Solution
{
    public int MaximumLength(int[] nums)
    {
        int n = nums.Length;
        for (int i = 0; i < n; i++)
        {
            nums[i] %= 2;
        }

        int ret = 0;
        // count same
        int countOne = 0, countZero = 0;
        for (int i = 0; i < n; i++)
        {
            countOne += nums[i];
            countZero += 1 - nums[i];
        }
        ret = Math.Max(ret, Math.Max(countOne, countZero));

        // count diff
        int prev = 0, count = 0;
        for (int i = 0; i < n; i++)
        {
            if (nums[i] != prev)
            {
                count++;
                prev = nums[i];
            }
        }
        ret = Math.Max(ret, count);
        prev = 1;
        count = 0;
        for (int i = 0; i < n; i++)
        {
            if (nums[i] != prev)
            {
                count++;
                prev = nums[i];
            }
        }
        ret = Math.Max(ret, count);

        return ret;
    }
}