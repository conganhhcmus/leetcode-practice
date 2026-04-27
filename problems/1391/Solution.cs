public class Solution
{
    public bool HasValidPath(int[][] grid)
    {
        int m = grid.Length, n = grid[0].Length;
        bool[,] visited = new bool[m, n];
        Dictionary<int, List<int[]>> dict = new(){
            {1, [[1,4,6], [1,3,5]]},
            {2, [[2,3,4], [2,5,6]]},
            {3, [[1,4,6], [2,5,6]]},
            {4, [[1,3,5], [2,5,6]]},
            {5, [[2,3,4], [1,4,6]]},
            {6, [[2,3,4], [1,3,5]]},
        };
        bool IsValid(int x, int y, int d, int t)
        {
            if (x >= 0 && x < m && y >= 0 && y < n)
            {
                return dict[d][t].Contains(grid[x][y]);
            }
            return false;
        }
        bool Dfs(int x, int y)
        {
            if (visited[x, y]) return false;
            visited[x, y] = true;
            if (x == m - 1 && y == n - 1) return true;
            int opt = grid[x][y];
            bool ans = false;
            switch (opt)
            {
                case 1:
                    // move left or right
                    if (IsValid(x, y - 1, opt, 0)) ans |= Dfs(x, y - 1);
                    if (IsValid(x, y + 1, opt, 1)) ans |= Dfs(x, y + 1);
                    break;
                case 2:
                    // move top or down
                    if (IsValid(x - 1, y, opt, 0)) ans |= Dfs(x - 1, y);
                    if (IsValid(x + 1, y, opt, 1)) ans |= Dfs(x + 1, y);
                    break;
                case 3:
                    // move left or down
                    if (IsValid(x, y - 1, opt, 0)) ans |= Dfs(x, y - 1);
                    if (IsValid(x + 1, y, opt, 1)) ans |= Dfs(x + 1, y);
                    break;
                case 4:
                    // move right or down
                    if (IsValid(x, y + 1, opt, 0)) ans |= Dfs(x, y + 1);
                    if (IsValid(x + 1, y, opt, 1)) ans |= Dfs(x + 1, y);
                    break;
                case 5:
                    // move top or left
                    if (IsValid(x - 1, y, opt, 0)) ans |= Dfs(x - 1, y);
                    if (IsValid(x, y - 1, opt, 1)) ans |= Dfs(x, y - 1);
                    break;
                case 6:
                    // move top or right
                    if (IsValid(x - 1, y, opt, 0)) ans |= Dfs(x - 1, y);
                    if (IsValid(x, y + 1, opt, 1)) ans |= Dfs(x, y + 1);
                    break;
            }

            return ans;
        }

        return Dfs(0, 0);
    }
}
