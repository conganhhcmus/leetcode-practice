public class Solution
{
    public int MaximumSum(int[] nums)
    {
        int n = nums.Length;
        List<int>[] cnt = new List<int>[3];
        for (int i = 0; i < 3; i++) cnt[i] = [];
        foreach (int x in nums)
        {
            int p = x % 3;
            cnt[p].Add(x);
        }
        for (int i = 0; i < 3; i++) cnt[i].Sort((a, b) => b - a);
        int ans = 0;
        if (cnt[0].Count > 0 && cnt[1].Count > 0 && cnt[2].Count > 0)
        {
            ans = Math.Max(ans, cnt[0][0] + cnt[1][0] + cnt[2][0]);
        }
        for (int i = 0; i < 3; i++)
        {
            if (cnt[i].Count >= 3)
            {
                ans = Math.Max(ans, cnt[i][0] + cnt[i][1] + cnt[i][2]);
            }
        }
        return ans;
    }
}
