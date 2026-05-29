public class Solution
{
    public int MinLength(int[] nums, int k)
    {
        int n = nums.Length;
        int[] cnt = new int[100_001];
        int sum = 0;
        int ans = int.MaxValue;
        for (int r = 0, l = 0; r < n; r++)
        {
            cnt[nums[r]]++;
            if (cnt[nums[r]] == 1) sum += nums[r];

            while (sum >= k)
            {
                ans = Math.Min(ans, r - l + 1);
                cnt[nums[l]]--;
                if (cnt[nums[l]] == 0) sum -= nums[l];
                l++;
            }
        }

        return ans == int.MaxValue ? -1 : ans;
    }
}
