namespace Problem_216;

public class Solution
{
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