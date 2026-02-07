public class Solution
{
    public IList<int> SolveQueries(int[] nums, int[] queries)
    {
        int n = nums.Length;
        Dictionary<int, List<int>> map = [];
        for (int i = 0; i < n; i++)
        {
            map.TryAdd(nums[i], []);
            map[nums[i]].Add(i);
        }

        IList<int> ans = [];
        foreach (int query in queries)
        {
            List<int> all = map[nums[query]];
            if (all.Count > 1)
            {
                int idx = all.BinarySearch(query);
                int min = int.MaxValue;
                if (idx - 1 >= 0)
                {
                    min = Math.Min(min, Math.Min(all[idx] - all[idx - 1], n - all[idx] + all[0]));
                }
                if (idx + 1 < all.Count)
                {
                    min = Math.Min(min, Math.Min(all[idx + 1] - all[idx], n - all[^1] + all[idx]));
                }

                ans.Add(min);
            }
            else
            {
                ans.Add(-1);
            }
        }

        return ans;
    }
}