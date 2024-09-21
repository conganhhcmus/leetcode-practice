namespace Problem_386;

public class Solution
{
    public static void Execute()
    {
        var solution = new Solution();
        int n = 109;
        Console.WriteLine(string.Join(",", solution.LexicalOrder(n)));
    }
    public IList<int> LexicalOrder(int n)
    {
        //return LexicalOrderByDFS(n);
        return LexicalOrderByIterative(n);
    }

    public IList<int> LexicalOrderByIterative(int n)
    {
        List<int> ans = [];
        int currentNumber = 1;

        for (int i = 0; i < n; i++)
        {
            ans.Add(currentNumber);
            if (currentNumber * 10 <= n) currentNumber *= 10;
            else
            {
                while (currentNumber % 10 == 9 || currentNumber >= n)
                {
                    currentNumber /= 10;
                }

                currentNumber++;
            }
        }

        return ans;
    }

    public IList<int> LexicalOrderByDFS(int n)
    {
        List<int> ans = [];
        for (int i = 1; i <= 9; i++)
        {
            DFS(i, n, ans);
        }
        return ans;
    }

    public void DFS(int i, int n, List<int> ans)
    {
        if (i > n) return;
        ans.Add(i);
        for (int j = 0; j <= 9; j++)
        {
            DFS(i * 10 + j, n, ans);
        }
    }
}