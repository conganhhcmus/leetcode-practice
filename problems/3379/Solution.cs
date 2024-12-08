#if DEBUG
namespace Problems_3379;
#endif

public class Solution
{
    public int[] ConstructTransformedArray(int[] nums)
    {
        int n = nums.Length;
        int[] result = new int[n];

        for (int i = 0; i < n; i++)
        {
            int idx = ((i + nums[i]) % n + n) % n;
            result[i] = nums[idx];
        }

        return result;
    }
}