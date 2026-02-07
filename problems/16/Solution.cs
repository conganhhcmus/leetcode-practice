public class Solution
{
    public int ThreeSumClosest(int[] nums, int target)
    {
        int n = nums.Length;
        int ans = int.MinValue / 2;
        for (int i = 0; i < n; i++)
        {
            for (int j = i + 1; j < n; j++)
            {
                for (int k = j + 1; k < n; k++)
                {
                    int sum = nums[i] + nums[j] + nums[k];
                    if (Math.Abs(target - sum) < Math.Abs(target - ans))
                    {
                        ans = sum;
                    }
                }
            }
        }
        return ans;
    }
}