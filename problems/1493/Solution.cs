namespace Problem_1493;

public class Solution
{
    public static void Execute()
    {
        var solution = new Solution();
        int[] nums = [1, 1, 0, 1];
        Console.WriteLine(solution.LongestSubarray(nums));
    }
    public int LongestSubarray(int[] nums)
    {
        int p1 = 0;
        int p2 = 0;
        int maxLen = 0;
        int del = 0;

        while (p2 < nums.Length)
        {
            if (nums[p2] == 0) del++;
            while (del > 1)
            {
                if (nums[p1] == 0) del--;
                p1++;
            }
            maxLen = Math.Max(maxLen, p2 - p1);
            p2++;
        }

        return maxLen;
    }
}