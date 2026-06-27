public class Solution
{
    public int MinimumDistance(int[] nums)
    {
        int n = nums.Length;
        int ans = int.MaxValue;
        for (int i = 0; i < n; i++)
        {
            for (int j = i + 1; j < n; j++)
            {
                for (int k = j + 1; k < n; k++)
                {
                    if (nums[i] == nums[j] && nums[j] == nums[k])
                    {
                        int val = Math.Abs(i - j) + Math.Abs(j - k) + Math.Abs(k - i);
                        if (ans > val) ans = val;
                    }
                }
            }
        }
        if (ans == int.MaxValue) return -1;
        return ans;
    }
}
