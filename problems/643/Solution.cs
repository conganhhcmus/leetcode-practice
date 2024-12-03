namespace Problem_643;

public class Solution
{
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