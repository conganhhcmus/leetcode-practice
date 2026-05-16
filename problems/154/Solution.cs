public class Solution
{
    public int FindMin(int[] nums)
    {
        int n = nums.Length;
        int ans = nums[0];
        for (int i = 1; i < n; i++)
        {
            if (ans > nums[i]) ans = nums[i];
        }
        return ans;
    }
}
