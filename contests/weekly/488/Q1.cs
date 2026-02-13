public class Solution
{
    public int DominantIndices(int[] nums)
    {
        int n = nums.Length;
        int ans = 0;
        int sum = 0;
        for (int i = n - 1; i >= 0; i--)
        {
            sum += nums[i];
            if (nums[i] * (n - i) > sum) ans++;
        }
        return ans;
    }
}