public class Solution
{
    public IList<int> FindSmallestSetOfVertices(int n, IList<IList<int>> edges)
    {
        int[] degree = new int[n];
        foreach (var e in edges)
        {
            degree[e[1]]++;
        }
        List<int> ans = [];
        for (int i = 0; i < n; i++)
        {
            if (degree[i] == 0) ans.Add(i);
        }
        return ans;
    }
}
