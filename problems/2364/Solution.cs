#if DEBUG
namespace Problems_2364;
#endif

public class Solution
{
    public long CountBadPairs(int[] nums)
    {
        int n = nums.Length;
        long ans = 0;
        Dictionary<int, int> map = [];
        map[nums[0]] = 1;
        for (int i = 1; i < n; i++)
        {
            int key = nums[i] - i;
            int val = map.GetValueOrDefault(key, 0);
            ans += val;
            map[key] = val + 1;
        }

        return (1L * n * (n - 1) / 2) - ans;
    }
}