#if DEBUG
namespace Problems_15_2;
#endif

public class Solution
{
    public IList<IList<int>> ThreeSum(int[] nums)
    {
        IList<IList<int>> ans = [];
        int n = nums.Length;
        Dictionary<int, HashSet<(int a, int b)>> map = [];
        HashSet<string> keys = [];
        if (n < 3) return ans;

        Array.Sort(nums);

        map[nums[0] + nums[1]] = [(nums[0], nums[1])];
        for (int k = 2; k < n; k++)
        {
            foreach (var (a, b) in map.GetValueOrDefault(-nums[k], []))
            {
                int[] tmp = [a, b, nums[k]];
                Array.Sort(tmp);
                string key = string.Join("_", tmp);
                if (keys.Add(key)) ans.Add(tmp);
            }

            for (int i = 0, j = k; i < k; i++)
            {
                int key = nums[i] + nums[j];
                if (key > -nums[k]) break;
                if (!map.ContainsKey(key)) map[key] = [];
                int[] tmp = [nums[i], nums[j]];
                Array.Sort(tmp);
                map[key].Add((tmp[0], tmp[1]));
            }
        }
        return ans;
    }
}