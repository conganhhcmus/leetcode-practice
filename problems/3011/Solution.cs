namespace Problem_3011;

public class Solution
{
    public static void Execute()
    {
        int[] nums = [3, 16, 8, 4, 2];
        var solution = new Solution();
        Console.WriteLine(solution.CanSortArray(nums));
    }
    public bool CanSortArray(int[] nums)
    {
        int cached = 0;
        int maxPrev = 0;
        int max = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            if (int.PopCount(nums[i]) != cached)
            {
                maxPrev = max;
                cached = int.PopCount(nums[i]);
            }
            if (maxPrev > nums[i]) return false;
            max = Math.Max(max, nums[i]);
        }

        return true;
    }
}