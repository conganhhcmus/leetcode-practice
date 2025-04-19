#if DEBUG
namespace Problems_47;
#endif

public class Solution
{
    IList<IList<int>> ret = [];
    public IList<IList<int>> PermuteUnique(int[] nums)
    {
        Dictionary<int, int> map = [];
        foreach (int num in nums)
        {
            map[num] = map.GetValueOrDefault(num, 0) + 1;
        }

        int n = nums.Length;
        nums = [.. map.Keys];

        Backtracking(nums, n, map, []);
        return ret;
    }

    void Backtracking(int[] nums, int len, Dictionary<int, int> map, IList<int> permutation)
    {
        if (len == 0)
        {
            ret.Add([.. permutation]);
            return;
        }

        foreach (int num in nums)
        {
            if (map[num] == 0) continue;
            permutation.Add(num);
            map[num]--;
            Backtracking(nums, len - 1, map, permutation);
            permutation.RemoveAt(permutation.Count - 1);
            map[num]++;
        }
    }
}