public class Solution
{
    public int MaxBalancedSubarray(int[] nums)
    {
        int n = nums.Length;
        int xor = 0;
        int bal = 0;
        Dictionary<(int, int), int> map = [];
        map[(0, 0)] = -1;
        int ans = 0;
        for (int i = 0; i < n; i++)
        {
            if (nums[i] % 2 == 0) bal++;
            else bal--;
            xor ^= nums[i];

            var key = (bal, xor);
            if (map.TryGetValue(key, out int j))
            {
                ans = Math.Max(ans, i - j);
            }
            else
            {
                map[key] = i;
            }
        }
        return ans;
    }
}
