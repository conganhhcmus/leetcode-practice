public class Solution
{
    public int MinOperations(int[] nums, int x)
    {
        int n = nums.Length;
        Dictionary<int, int> map = [];
        map[0] = 0;
        int sum = 0;
        for (int i = n - 1; i >= 0; i--)
        {
            sum += nums[i];
            if (sum > x) break;
            map[sum] = n - i;
        }
        int ans = map.GetValueOrDefault(x, n + 1);
        for (int i = 0; i < n; i++)
        {
            x -= nums[i];
            if (x < 0) break;
            if (map.TryGetValue(x, out int j))
            {
                ans = Math.Min(ans, i + j + 1);
            }
        }
        if (ans > n) return -1;
        return ans;
    }
}