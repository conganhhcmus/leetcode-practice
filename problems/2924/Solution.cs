namespace Problem_2924;
public class Solution
{
    public static void Execute()
    {
        int n = 3;
        int[][] edges = [[0, 1], [1, 2]];
        var solution = new Solution();
        Console.WriteLine(solution.FindChampion(n, edges));
    }
    public int FindChampion(int n, int[][] edges)
    {
        HashSet<int> champion = [];
        for (int i = 0; i < n; i++) champion.Add(i);
        foreach (int[] edge in edges)
        {
            champion.Remove(edge[1]);
        }

        if (champion.Count == 1) return champion.ElementAt(0);
        return -1;
    }
}