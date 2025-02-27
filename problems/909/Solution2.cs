#if DEBUG
namespace Problems_909_2;
#endif

public class Solution
{
    public int SnakesAndLadders(int[][] board)
    {
        int n = board.Length;
        int[] dp = new int[n * n + 1];
        Array.Fill(dp, -1);
        dp[0] = 0;
        dp[1] = 0;
        Queue<int> queue = [];
        queue.Enqueue(1);
        while (queue.Count > 0)
        {
            int curr = queue.Dequeue();
            for (int i = 1; i <= 6; i++)
            {
                if (curr + i > n * n) continue;
                var (r, c) = Resolve(curr + i, n);
                int next = board[r][c] == -1 ? curr + i : board[r][c];
                if (dp[next] == -1)
                {
                    dp[next] = dp[curr] + 1;
                    queue.Enqueue(next);
                }
                if (dp[n * n] != -1) return dp[n * n];
            }
        }
        return -1;
    }

    private (int r, int c) Resolve(int curr, int n)
    {
        int p = (curr - 1) / n, q = (curr - 1) % n;
        int row = n - 1 - p;
        int col = ((p & 1) != 0) ? (n - q - 1) : q;
        return (row, col);
    }
}