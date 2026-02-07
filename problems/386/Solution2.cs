public class Solution
{
    public IList<int> LexicalOrder(int n)
    {
        List<int> ans = [];
        for (int i = 1; i <= 9; i++)
        {
            DFS(i, n, ans);
        }
        return ans;
    }

    private void DFS(int i, int n, List<int> ans)
    {
        if (i > n) return;
        ans.Add(i);
        for (int j = 0; j <= 9; j++)
        {
            DFS(i * 10 + j, n, ans);
        }
    }
}