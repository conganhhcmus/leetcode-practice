public class Solution
{
    public int MinOperations(int[] nums)
    {
        int n = nums.Length;
        bool inc = true, dec = true;
        int pos = 0;
        for (int i = 0; i < n; i++)
        {
            if ((nums[i] + 1) % n != nums[(i + 1) % n])
            {
                inc = false;
            }
            if ((nums[i] + n - 1) % n != nums[(i + 1) % n])
            {
                dec = false;
            }
            if (nums[i] == 0) pos = i;
        }
        int INF = 1 << 30;
        int ans = INF;
        if (inc)
        {
            ans = Math.Min(ans, Math.Min(pos, 2 + n - pos));
        }
        if (dec)
        {
            ans = Math.Min(ans, Math.Min(2 + pos, n - pos));
        }
        return ans == INF ? -1 : ans;
    }
}
