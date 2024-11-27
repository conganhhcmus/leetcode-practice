namespace Problem_3243;
public class Solution
{
    public static void Execute()
    {
        int n = 31;
        int[][] queries = [[25, 27], [3, 28], [12, 19], [11, 14], [12, 23], [14, 29], [11, 28], [3, 5], [1, 28]];
        var solution = new Solution();
        var result = solution.ShortestDistanceAfterQueries(n, queries);
        Console.WriteLine($"[{string.Join(",", result)}]");
    }
    public int[] ShortestDistanceAfterQueries(int n, int[][] queries)
    {
        List<int>[] paths = new List<int>[n];
        int[] dp = new int[n];
        for (int i = 0; i < n - 1; ++i)
        {
            paths[i] = [i + 1];
            dp[i] = i;
        }
        paths[n - 1] = [];
        dp[n - 1] = n - 1;
        int[] res = new int[queries.Length];
        for (int i = 0; i < queries.Length; ++i)
        {
            paths[queries[i][0]].Add(queries[i][1]);
            for (int j = queries[i][0]; j < n; ++j)
            {
                foreach (int next in paths[j])
                {
                    dp[next] = Math.Min(dp[next], dp[j] + 1);
                }
            }
            res[i] = dp[n - 1];
        }
        return res;
    }
}