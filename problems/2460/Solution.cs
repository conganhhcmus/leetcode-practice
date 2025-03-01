#if DEBUG
namespace Problems_2460;
#endif

public class Solution
{
    public int[] ApplyOperations(int[] nums)
    {
        int n = nums.Length;
        int[] ans = new int[n];
        int p = 0;

        for (int i = 0; i < n - 1; i++)
        {
            if (nums[i] == 0) continue;
            if (nums[i] == nums[i + 1])
            {
                nums[i + 1] = 0;
                ans[p++] = nums[i] * 2;
            }
            else ans[p++] = nums[i];
        }
        ans[p++] = nums[^1];

        return ans;
    }
}