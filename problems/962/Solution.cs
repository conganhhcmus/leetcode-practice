namespace Problem_962;

public class Solution
{
    public int MaxWidthRamp(int[] nums)
    {
        int[] maxRight = new int[nums.Length];
        maxRight[^1] = nums[^1];
        for (int i = nums.Length - 2; i >= 0; i--)
        {
            maxRight[i] = Math.Max(nums[i], maxRight[i + 1]);
        }

        int left = 0;
        int right = 0;
        int maxLength = 0;
        while (right < nums.Length)
        {
            while (left < right && nums[left] > maxRight[right])
            {
                left++;
            }
            maxLength = Math.Max(maxLength, right - left);
            right++;
        }

        return maxLength;
    }
}