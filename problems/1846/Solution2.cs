public class Solution
{
    public int MaximumElementAfterDecrementingAndRearranging(int[] arr)
    {
        int n = arr.Length;
        int[] cnt = new int[n + 1];
        foreach (int x in arr)
        {
            cnt[Math.Min(x, n)]++;
        }
        int ans = 1;
        for (int x = 2; x <= n; x++)
        {
            ans = Math.Min(ans + cnt[x], x);
        }
        return ans;
    }
}
