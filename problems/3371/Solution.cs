namespace Problem_3371;
public class Solution
{
    public int GetLargestOutlier(int[] nums)
    {
        Dictionary<int, int> freq = [];
        long sum = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            sum += nums[i];
            freq[nums[i]] = freq.GetValueOrDefault(nums[i], 0) + 1;
        }
        int result = int.MinValue;
        for (int i = 0; i < nums.Length; i++)
        {
            freq[nums[i]]--;
            int find = (int)(sum - (2 * nums[i]));
            if (freq.GetValueOrDefault(find) > 0)
            {
                result = Math.Max(result, find);
            }
            freq[nums[i]]++;
        }

        return result;
    }
}