#if DEBUG
namespace Weekly_441_Q1;
#endif

public class Solution
{
    public int MaxSum(int[] nums)
    {
        int n = nums.Length;
        HashSet<int> set = [];
        int sum = 0;
        int count = 0;
        int max = int.MinValue;
        for (int i = 0; i < n; i++)
        {
            if (set.Add(nums[i]))
            {
                if (nums[i] >= 0)
                {
                    sum += nums[i];
                    count++;
                }
            }
            max = Math.Max(max, nums[i]);
        }
        if (count == 0) return max;
        return sum;
    }
}