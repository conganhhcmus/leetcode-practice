public class Solution
{
    public int AbsDifference(int[] nums, int k)
    {
        int n = nums.Length;
        Array.Sort(nums);
        int s1 = 0, s2 = 0;
        for (int i = 0; i < k; i++)
        {
            s1 += nums[i];
            s2 += nums[n - i - 1];
        }
        return s2 - s1;
    }
}
