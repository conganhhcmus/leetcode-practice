#if DEBUG
namespace Problems_581;
#endif

public class Solution
{
    public int FindUnsortedSubarray(int[] nums)
    {
        int n = nums.Length;
        int[] clone = new int[n];
        Array.Copy(nums, clone, n);
        Array.Sort(nums);
        int max = 0, min = n;
        for (int i = 0; i < n; i++)
        {
            if (nums[i] != clone[i])
            {
                min = Math.Min(min, i);
                max = Math.Max(max, i);
            }
        }
        return Math.Max(0, (max - min + 1));
    }
}