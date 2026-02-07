public class Solution
{
    public int PivotIndex(int[] nums)
    {
        int totalSum = nums.Sum();
        int sum = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            if (sum * 2 == totalSum - nums[i]) return i;
            sum += nums[i];
        }

        return -1;
    }
}