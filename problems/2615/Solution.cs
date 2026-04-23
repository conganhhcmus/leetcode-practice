public class Solution
{
    public long[] Distance(int[] nums)
    {
        int n = nums.Length;
        Dictionary<int, long> tot = [];
        Dictionary<int, int> cnt = [];
        for (int i = 0; i < n; i++)
        {
            int x = nums[i];
            if (!tot.ContainsKey(x))
            {
                tot[x] = 0L;
            }
            tot[x] += i;
            cnt[x] = cnt.GetValueOrDefault(x, 0) + 1;
        }
        Dictionary<int, int> map = [];
        Dictionary<int, int> cnt2 = [];
        long[] ans = new long[n];
        for (int i = 0; i < n; i++)
        {
            int x = nums[i];
            int j = map.GetValueOrDefault(x, 0);
            int prevCnt = cnt2.GetValueOrDefault(x, 0);
            int nextCnt = cnt[x] - prevCnt;
            tot[x] -= 1L * (nextCnt - prevCnt) * (i - j);
            ans[i] = tot[x];
            cnt2[x] = prevCnt + 1;
            map[x] = i;
        }
        return ans;
    }
}
