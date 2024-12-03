namespace Problem_2419;

public class Solution
{
    public int LongestSubarray(int[] nums)
    {
        int ans = 1;
        int max = nums.Max();
        int count = 0;

        // key1: a & a = a
        // key2: if a < b => a & b < b
        // solution: find the max value in the array, then count consecutive occurrences

        foreach (int num in nums)
        {
            if (num == max)
            {
                count++;
                ans = Math.Max(ans, count);
            }
            else
            {
                count = 0;
            }
        }

        return ans;
    }
}