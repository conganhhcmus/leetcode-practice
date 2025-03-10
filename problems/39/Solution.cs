#if DEBUG
namespace Problems_39;
#endif

public class Solution
{

    public IList<IList<int>> CombinationSum(int[] candidates, int target)
    {
        IList<IList<int>> ans = [];
        HashSet<string> existed = [];

        BackTracking(candidates, target, 0, [], ans, existed);
        return ans;
    }

    void BackTracking(int[] candidates, int target, int current, IList<int> combination, IList<IList<int>> ans, HashSet<string> existed)
    {
        if (current > target) return;
        if (current == target)
        {
            List<int> cloned = [.. combination];
            cloned.Sort();
            string key = string.Join("_", cloned);
            if (existed.Add(key))
            {
                ans.Add(cloned);
            }
            return;
        }

        for (int i = 0; i < candidates.Length; i++)
        {
            current += candidates[i];
            combination.Add(candidates[i]);
            BackTracking(candidates, target, current, combination, ans, existed);
            current -= candidates[i];
            combination.RemoveAt(combination.Count - 1);
        }
    }
}