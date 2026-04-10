public class Solution
{
    public int MinimumDistance(int[] nums)
    {
        int n = nums.Length;
        int[] next = new int[n];
        Array.Fill(next, -1);
        int[] map = new int[n + 1];
        Array.Fill(map, -1);
        for (int i = n - 1; i >= 0; i--)
        {
            if (map[nums[i]] != -1)
            {
                next[i] = map[nums[i]];
            }
            map[nums[i]] = i;
        }
        int ans = n + 1;
        for (int i = 0; i < n; i++)
        {
            int second = next[i];
            if (second == -1) continue;
            int third = next[second];
            if (third == -1) continue;
            ans = Math.Min(ans, third - i);
        }
        return ans == n + 1 ? -1 : 2 * ans;
    }
}