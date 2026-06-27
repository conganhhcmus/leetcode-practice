public class Solution
{
    public int MaximumLength(int[] nums)
    {
        Dictionary<long, int> cnt = [];
        foreach (int num in nums)
        {
            cnt.TryGetValue(num, out int c);
            cnt[num] = c + 1;
        }
        cnt.TryGetValue(1, out int cntOne);
        int ans = (cntOne & 1) == 1 ? cntOne : cntOne - 1;
        cnt.Remove(1);
        foreach (long num in cnt.Keys)
        {
            int res = 0;
            long x = num;
            while (cnt.TryGetValue(x, out int c) && c > 1)
            {
                res += 2;
                x *= x;
            }
            ans = Math.Max(ans, res + (cnt.ContainsKey(x) ? 1 : -1));
        }
        return ans;
    }
}
