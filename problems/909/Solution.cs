public class Solution
{
    public int SnakesAndLadders(int[][] board)
    {
        int n = board.Length;
        Dictionary<int, (int r, int c)> mapTo2D = [];
        Dictionary<(int r, int c), int> mapTo1D = [];
        int index = 1;
        bool reverse = false;
        for (int r = n - 1; r >= 0; r--)
        {
            if (!reverse)
            {
                for (int c = 0; c < n; c++)
                {
                    mapTo2D[index] = (r, c);
                    mapTo1D[(r, c)] = index;
                    index++;
                }
            }
            else
            {
                for (int c = n - 1; c >= 0; c--)
                {
                    mapTo2D[index] = (r, c);
                    mapTo1D[(r, c)] = index;
                    index++;
                }
            }

            reverse = !reverse;
        }
        bool[,] visited = new bool[n, n];
        Queue<(int r, int c)> queue = [];
        queue.Enqueue((n - 1, 0));
        int count = 0;
        while (queue.Count > 0)
        {
            int size = queue.Count;
            count++;
            while (size-- > 0)
            {
                var (r, c) = queue.Dequeue();
                if (visited[r, c]) continue;
                visited[r, c] = true;
                int curr = mapTo1D[(r, c)];
                for (int i = 1; i <= 6; i++)
                {
                    int next = curr + i;
                    if (next >= n * n) return count;
                    var (nr, nc) = mapTo2D[next];
                    if (board[nr][nc] != -1)
                    {
                        next = board[nr][nc];
                        if (next >= n * n) return count;
                        var (nnr, nnc) = mapTo2D[next];
                        queue.Enqueue((nnr, nnc));
                    }
                    else
                    {
                        queue.Enqueue((nr, nc));
                    }
                }
            }
        }
        return -1;
    }
}