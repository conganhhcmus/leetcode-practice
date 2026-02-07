public class Solution
{
    public int CenteredSubarrays(int[] nums)
    {
        int n = nums.Length;
        int ans = 0;
        for (int i = 0; i < n; i++)
        {
            int sum = 0;
            HashSet<int> set = [];
            for (int j = i; j < n; j++)
            {
                sum += nums[j];
                set.Add(nums[j]);
                if (set.Contains(sum)) ans++;
            }
        }
        return ans;
    }
}