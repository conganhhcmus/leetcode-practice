public class Solution
{
    public int MaxFrequency(int[] nums, int k, int numOperations)
    {
        int[] freq = new int[100001];
        int min = nums[0];
        int max = nums[0];
        foreach (int num in nums)
        {
            freq[num]++;
            if (num > max)
            {
                max = num;
            }
            else if (num < min)
            {
                min = num;
            }
        }

        int ans = 0;
        int left = min, right = min;
        int count = 0;

        for (int num = min; num <= max; num++)
        {
            while (left < num - k)
            {
                count -= freq[left];
                left++;
            }
            int maxRight = Math.Min(max, num + k);
            while (right <= maxRight)
            {
                count += freq[right];
                right++;
            }
            ans = Math.Max(ans, freq[num] + Math.Min(count - freq[num], numOperations));
        }

        return ans;
    }
}