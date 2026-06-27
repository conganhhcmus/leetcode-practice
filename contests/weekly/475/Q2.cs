public class Solution
{
    public int MinimumDistance(int[] nums)
    {
        int n = nums.Length;
        int[] prev = new int[n];
        Array.Fill(prev, -1);
        Dictionary<int, int> map = [];
        for (int i = 0; i < n; i++)
        {
            int x = nums[i];
            prev[i] = map.GetValueOrDefault(x, -1);
            map[x] = i;
        }
        int ans = int.MaxValue;
        for (int i = 0; i < n; i++)
        {
            if (prev[i] != -1 && prev[prev[i]] != -1)
            {
                ans = Math.Min(ans, 2 * (i - prev[prev[i]]));
            }
        }
        if (ans == int.MaxValue) return -1;
        return ans;
    }
}
