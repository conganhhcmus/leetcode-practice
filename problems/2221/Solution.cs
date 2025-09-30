#if DEBUG
namespace Problems_2221;
#endif

public class Solution
{
    public int TriangularSum(int[] nums)
    {
        int n = nums.Length;
        while (n > 1)
        {
            for (int i = 0; i < n - 1; i++)
            {
                nums[i] = (nums[i] + nums[i + 1]) % 10;
            }
            n--;
        }

        return nums[0];
    }
}