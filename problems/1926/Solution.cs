namespace Problem_1926;

public class Solution
{
    public int NearestExit(char[][] maze, int[] entrance)
    {
        int maxR = maze.Length - 1;
        int maxC = maze[0].Length - 1;
        Queue<(int r, int c, int step)> queue = [];
        queue.Enqueue((entrance[0], entrance[1], 0));
        while (queue.Count > 0)
        {
            var (r, c, step) = queue.Dequeue();
            if (r < 0 || c < 0 || r > maxR || c > maxC || maze[r][c] == '+') continue;

            if (step > 0 && (r == 0 || r == maxR || c == 0 || c == maxC)) return step;

            maze[r][c] = '+'; // mark as visited

            queue.Enqueue((r - 1, c, step + 1)); // top
            queue.Enqueue((r, c + 1, step + 1)); // right
            queue.Enqueue((r + 1, c, step + 1)); // down
            queue.Enqueue((r, c - 1, step + 1)); // left
        }

        return -1;
    }
}