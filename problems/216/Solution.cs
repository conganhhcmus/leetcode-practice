namespace Problem_216;

using Helpers;

public class Solution
{
    public static void Execute()
    {
        int k = 3;
        int n = 9;
        var solution = new Solution();
        var result = solution.CombinationSum3(k, n);
        ArrayHelper.Print2DArray(result);
    }
    public IList<IList<int>> CombinationSum3(int k, int n)
    {
        List<IList<int>> result = [];
        void Backtracking(HashSet<int> comb, int sum = 0, int curr = 0)
        {
            if (comb.Count == k)
            {
                if (sum == n)
                {
                    result.Add([.. comb]);
                }
                return;
            }

            for (int i = curr + 1; i < 10 && (sum + i <= n); i++)
            {
                if (comb.Add(i))
                {
                    Backtracking(comb, sum + i, i);
                    comb.Remove(i);
                }
            }
        }

        Backtracking([]);
        return result;
    }
}