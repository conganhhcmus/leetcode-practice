public class Solution
{
    public IList<IList<int>> Combine(int n, int k)
    {
        IList<IList<int>> result = [];
        BackTracking(0, 1, k, n, result, []);
        return result;
    }

    void BackTracking(int i, int start, int k, int n, IList<IList<int>> result, IList<int> curr)
    {
        if (i == k)
        {
            result.Add([.. curr]);
            return;
        }
        if (start > n) return;

        for (int j = start; j <= n; j++)
        {
            curr.Add(j);
            BackTracking(i + 1, j + 1, k, n, result, curr);
            curr.RemoveAt(curr.Count - 1);
        }
    }
}