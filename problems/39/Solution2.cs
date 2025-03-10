#if DEBUG
namespace Problems_39_2;
#endif

public class Solution
{

    public IList<IList<int>> CombinationSum(int[] candidates, int target)
    {
        IList<IList<int>> ans = [];
        BackTracking(candidates, target, 0, [], ans);
        return ans;
    }

    void BackTracking(int[] candidates, int target, int start, IList<int> combination, IList<IList<int>> ans)
    {
        if (target == 0)
        {
            ans.Add([.. combination]);
            return;
        }

        for (int i = start; i < candidates.Length; i++)
        {
            if (candidates[i] <= target)
            {
                combination.Add(candidates[i]);
                BackTracking(candidates, target - candidates[i], i, combination, ans);
                combination.RemoveAt(combination.Count - 1);
            }
        }
    }
}