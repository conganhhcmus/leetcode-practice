public class Solution
{
    public int MinMoves(string[] classroom, int energy)
    {
        int m = classroom.Length, n = classroom[0].Length;
        int[] st = [0, 0];
        int cnt = 0;
        Dictionary<int, int> map = [];
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (classroom[i][j] == 'L') map[Idx(i, j)] = 1 << cnt++;
                if (classroom[i][j] == 'S') st = [i, j];
            }
        }

        int fullMask = (1 << cnt) - 1;
        int[] dirs = [1, 0, -1, 0, 1];
        bool[,,,] visited = new bool[m, n, fullMask + 1, energy + 1];
        Queue<(int x, int y, int mask, int e)> q = [];
        q.Enqueue((st[0], st[1], 0, energy));
        visited[st[0], st[1], 0, energy] = true;
        int steps = 0;
        while (q.Count > 0)
        {
            int sz = q.Count;
            while (sz-- > 0)
            {
                var (x, y, mask, e) = q.Dequeue();
                if (mask == fullMask) return steps;
                if (e == 0) continue;
                for (int i = 0; i < 4; i++)
                {
                    int nx = x + dirs[i];
                    int ny = y + dirs[i + 1];
                    if (nx < 0 || nx >= m || ny < 0 || ny >= n) continue;
                    if (classroom[nx][ny] == 'X') continue;
                    int nMask = mask | map.GetValueOrDefault(Idx(nx, ny));
                    int nE = e - 1;
                    if (classroom[nx][ny] == 'R') nE = energy;
                    if (visited[nx, ny, nMask, nE]) continue;
                    visited[nx, ny, nMask, nE] = true;
                    q.Enqueue((nx, ny, nMask, nE));
                }
            }
            steps++;
        }
        return -1;
        int Idx(int x, int y) => x * n + y;
    }
}
