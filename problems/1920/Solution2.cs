#if DEBUG
namespace Problems_1920_2;
#endif

public class Solution
{
    public int[] BuildArray(int[] nums)
    {
        int n = nums.Length;
        for (int i = 0; i < n; i++)
        {
            // old = nums[i]
            // new = nums[nums[i]]
            // val = old + new * n
            // old = val % n, new = val / n
            nums[i] = nums[i] + (nums[nums[i]] % n) * n;
        }

        for (int i = 0; i < n; i++)
        {
            nums[i] /= n;
        }
        return nums;
    }
}