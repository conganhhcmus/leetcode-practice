namespace Problem_2419;

public class Solution
{
    public static void Execute()
    {
        var solution = new Solution();
        int[] nums = [1, 2, 3, 3, 2, 2];
        Console.WriteLine(solution.LongestSubarray(nums));
    }
    public int LongestSubarray(int[] nums)
    {
        int ans = 1;
        int max = nums.Max();
        int count = 0;

        // key1: a & a = a
        // key2: if a < b => a & b < b
        // solution: find the max value in the array, then count consecutive occurrences

        foreach (int num in nums)
        {
            if (num == max)
            {
                count++;
                ans = Math.Max(ans, count);
            }
            else
            {
                count = 0;
            }
        }

        return ans;
    }
}