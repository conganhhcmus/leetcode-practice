#if DEBUG
namespace Problems_3634;
#endif

public class Solution
{
    public int MinRemoval(int[] nums, int k)
    {
        int n = nums.Length;
        Array.Sort(nums);
        int ans = n;
        for (int i = 0, j = 0; i < n && j < n; i++)
        {
            while (j < n && nums[j] <= 1L * nums[i] * k) j++;
            ans = Math.Min(ans, i + n - j);
        }
        return ans;
    }
}