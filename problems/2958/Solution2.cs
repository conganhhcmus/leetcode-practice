public class Solution
{
    public int MaxSubarrayLength(int[] nums, int k)
    {
        int n = nums.Length;
        Dictionary<int, int> cnt = [];
        int cntExceed = 0;
        int st = 0;
        for (int ed = 0; ed < n; ed++)
        {
            cnt[nums[ed]] = cnt.GetValueOrDefault(nums[ed], 0) + 1;
            if (cnt[nums[ed]] == k + 1) cntExceed++;
            if (cntExceed > 0)
            {
                cnt[nums[st]]--;
                if (cnt[nums[st]] == k) cntExceed--;
                st++;
            }
        }
        return n - st;
    }
}
