#if DEBUG
namespace Problems_3191;
#endif

public class Solution
{
    public int MinOperations(int[] nums)
    {
        int n = nums.Length;
        int count = 0;
        for (int i = 0; i + 3 <= n; i++)
        {
            if (nums[i] == 0)
            {
                count++;
                for (int j = 0; j < 3; j++)
                {
                    nums[i + j] = 1 - nums[i + j];
                }
            }
        }
        for (int i = 0; i < 3; i++)
        {
            if (nums[n - 1 - i] == 0) return -1;
        }

        return count;
    }
}