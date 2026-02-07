public class Solution
{
    public int LargestPerimeter(int[] nums)
    {
        Array.Sort(nums);
        int n = nums.Length;
        int ans = 0;
        for (int i = n - 1; i > 1; i--)
        {
            int j = i - 1, k = 0;
            while (j > k)
            {
                if (nums[j] + nums[k] > nums[i])
                {
                    ans = Math.Max(ans, nums[i] + nums[j] + nums[Math.Max(k, j - 1)]);
                    break;
                }
                else
                {
                    k++;
                }
            }
        }
        return ans;
    }
}