#if DEBUG
namespace Problems_18;
#endif

public class Solution
{
    public IList<IList<int>> FourSum(int[] nums, int target)
    {
        IList<IList<int>> ans = [];
        Dictionary<long, HashSet<(int a, int b)>> map = [];
        HashSet<string> keys = [];
        int n = nums.Length;
        if (n < 4) return [];
        // nums[a] + nums[b] + nums[c] + nums[d] = target
        // if a < b < c < d
        // nums[a] + nums[b] = target - (nums[c] + nums[d])

        map[0L + nums[0] + nums[1]] = [(nums[0], nums[1])];
        for (int c = 2; c < n - 1; c++)
        {
            for (int d = c + 1; d < n; d++)
            {
                long key = target - (0L + nums[c] + nums[d]);
                foreach (var pair in map.GetValueOrDefault(key, []))
                {
                    int[] tmp = [pair.a, pair.b, nums[c], nums[d]];
                    Array.Sort(tmp);
                    string ans_key = string.Join("_", tmp);
                    if (keys.Add(ans_key)) ans.Add(tmp);
                }
            }

            for (int a = c - 1, b = c; a >= 0; a--)
            {
                long key = 0L + nums[a] + nums[b];
                if (!map.ContainsKey(key)) map[key] = [];
                map[key].Add((nums[a], nums[b]));
            }
        }

        return ans;
    }
}