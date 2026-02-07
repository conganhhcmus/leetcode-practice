public class Solution
{
    public long CountSubarrays(int[] nums, int k)
    {
        int n = nums.Length;
        int max = 0;
        foreach (int num in nums)
        {
            if (max < num) max = num;
        }
        int[] freq = new int[(int)1e6 + 1];
        long ret = 0;
        int l = 0;
        for (int r = 0; r < n; r++)
        {
            freq[nums[r]]++;
            while (freq[max] >= k)
            {
                freq[nums[l]]--;
                l++;
            }
            ret += l;
        }
        return ret;
    }
}