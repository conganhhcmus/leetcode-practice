public class Solution
{
    IList<IList<int>> ret = [];

    public IList<IList<int>> CombinationSum2(int[] candidates, int target)
    {
        // Array.Sort(candidates);
        Dictionary<int, int> map = [];
        foreach (int num in candidates)
        {
            map[num] = map.GetValueOrDefault(num, 0) + 1;
        }
        candidates = [.. map.Keys];
        Backtracking(candidates, target, 0, map, []);

        return ret;
    }

    void Backtracking(int[] candidates, int target, int start, Dictionary<int, int> map, IList<int> combination)
    {
        if (target < 0) return;
        if (target == 0)
        {
            ret.Add([.. combination]);
            return;
        }

        for (int i = start; i < candidates.Length; i++)
        {
            if (map[candidates[i]] == 0) continue;
            if (candidates[i] <= target)
            {
                combination.Add(candidates[i]);
                map[candidates[i]]--;
                Backtracking(candidates, target - candidates[i], i, map, combination);
                combination.RemoveAt(combination.Count - 1);
                map[candidates[i]]++;
            }
        }
    }
}