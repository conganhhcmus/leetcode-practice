namespace Problem_643;

public class Solution
{
    public static void Execute()
    {
        var solution = new Solution();
        int[] nums = [4, 2, 1, 3, 3];
        int k = 2;
        Console.WriteLine(solution.FindMaxAverage(nums, k));
    }
    public double FindMaxAverage(int[] nums, int k)
    {
        int left = 0;
        int right = k;
        double sum = nums[left..right].Sum();
        double maxSum = sum;

        while (right < nums.Length)
        {
            sum += nums[right] - nums[left];
            maxSum = Math.Max(maxSum, sum);
            left++;
            right++;
        }

        return maxSum * 1.0 / k;
    }
}