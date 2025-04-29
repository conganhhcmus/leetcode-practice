#if DEBUG
namespace Problems_2962_2;
#endif

public class Solution
{
    public long CountSubarrays(int[] nums, int k)
    {
        int n = nums.Length;
        int max = 0;
        foreach (int num in nums)
        {
            if (max < num) max = num;
        }
        long ret = 0;
        int count = 0;
        int l = 0;
        for (int r = 0; r < n; r++)
        {
            if (nums[r] == max) count++;
            while (count >= k)
            {
                if (nums[l] == max) count--;
                l++;
            }
            ret += l;
        }
        return ret;
    }
}