public class Solution
{
    public int FindUnsortedSubarray(int[] nums)
    {
        int n = nums.Length;
        int left = n, right = 0;
        int max = int.MinValue, min = int.MaxValue;
        for (int i = 0; i < n; i++)
        {
            if (nums[i] < max)
            {
                right = i;
            }
            else
            {
                max = nums[i];
            }
        }

        for (int i = n - 1; i >= 0; i--)
        {
            if (nums[i] > min)
            {
                left = i;
            }
            else
            {
                min = nums[i];
            }
        }

        if (left >= right) return 0;
        return right - left + 1;
    }
}