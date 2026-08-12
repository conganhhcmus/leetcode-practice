public class Solution
{
    public int MaxSubarrayLength(int[] nums, int k)
    {
        int n = nums.Length;
        int ans = 0;
        Dictionary<int, int> cnt = [];
        for (int i = 0, j = 0; i < n; i++)
        {
            int x = nums[i];
            cnt[x] = cnt.GetValueOrDefault(x, 0) + 1;
            while (j < i && cnt[x] > k)
            {
                cnt[nums[j]]--;
                j++;
            }
            ans = Math.Max(ans, i - j + 1);
        }
        return ans;
    }
}
