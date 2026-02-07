public class Solution
{
    public int MinimumSize(int[] nums, int maxOperations)
    {
        int maxLength = nums.Length + maxOperations;
        int min = 0;
        int max = nums.Max();

        while (min <= max)
        {
            int mid = min + (max - min) / 2;
            int minSize = CalculateMinSize(nums, mid);
            if (minSize > maxLength)
            {
                min = mid + 1;
            }
            else
            {
                max = mid - 1;
            }
        }
        return min;
    }

    private int CalculateMinSize(int[] nums, int maxSize)
    {
        if (maxSize == 0) return int.MaxValue;
        int ans = 0;
        foreach (int num in nums)
        {
            ans += (int)Math.Ceiling(num * 1.0 / maxSize);
        }
        return ans;
    }
}