namespace Problem_1004;

public class Solution
{
    public static void Execute()
    {
        var solution = new Solution();
        int[] nums = [1, 1, 1, 0, 0, 0, 1, 1, 1, 1, 0];
        int k = 2;
        Console.WriteLine(solution.LongestOnes(nums, k));
    }
    public int LongestOnes(int[] nums, int k)
    {
        int left = 0;
        int right = 0;
        int maxCount = 0;
        int zeroCount = 0;
        while (right < nums.Length)
        {
            if (nums[right] == 0) zeroCount++;
            while (zeroCount > k)
            {
                if (nums[left] == 0) zeroCount--;
                left++;
            }
            maxCount = Math.Max(maxCount, right - left + 1);
            right++;
        }

        return maxCount;
    }
}