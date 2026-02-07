public class Solution
{
    public int LongestMonotonicSubarray(int[] nums)
    {
        int ans = 1, n = nums.Length;
        int currInc = 1, currDec = 1;
        for (int i = 1; i < n; i++)
        {
            if (nums[i] > nums[i - 1])
            {
                ans = Math.Max(ans, currDec);
                currInc++;
                currDec = 1;
            }
            else if (nums[i] < nums[i - 1])
            {
                ans = Math.Max(ans, currInc);
                currDec++;
                currInc = 1;
            }
            else
            {
                ans = Math.Max(ans, Math.Max(currDec, currInc));
                currInc = 1;
                currDec = 1;
            }
        }

        return Math.Max(ans, Math.Max(currDec, currInc));
    }
}