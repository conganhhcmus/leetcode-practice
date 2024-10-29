namespace Problem_2684;

public class Solution
{
    public static void Execute()
    {
        int[][] grid = [
            [1000000, 92910, 1021, 1022, 1023, 1024, 1025, 1026, 1027, 1028, 1029, 1030, 1031, 1032, 1033, 1034, 1035, 1036, 1037, 1038, 1039, 1040, 1041, 1042, 1043, 1044, 1045, 1046, 1047, 1048, 1049, 1050, 1051, 1052, 1053, 1054, 1055, 1056, 1057, 1058, 1059, 1060, 1061, 1062, 1063, 1064, 1065, 1066, 1067, 1068],
            [1069, 1070, 1071, 1072, 1073, 1074, 1075, 1076, 1077, 1078, 1079, 1080, 1081, 1082, 1083, 1084, 1085, 1086, 1087, 1088, 1089, 1090, 1091, 1092, 1093, 1094, 1095, 1096, 1097, 1098, 1099, 1100, 1101, 1102, 1103, 1104, 1105, 1106, 1107, 1108, 1109, 1110, 1111, 1112, 1113, 1114, 1115, 1116, 1117, 1118]];
        var solution = new Solution();
        Console.WriteLine(solution.MaxMoves(grid));
    }

    public int MaxMoves(int[][] grid)
    {
        return MaxMoves_BFS(grid);
    }
    public int MaxMoves_BFS(int[][] grid)
    {
        int m = grid.Length;
        int n = grid[0].Length;
        int maxMove = 0;

        bool[][] map = new bool[m][];
        for (int i = 0; i < m; i++)
        {
            map[i] = new bool[n];
        }

        Queue<(int r, int c, int len)> queue = [];
        for (int i = 0; i < m; i++)
        {
            queue.Enqueue((i, 0, 0));
            map[i][0] = true;
        }

        while (queue.Count > 0)
        {
            var (r, c, len) = queue.Dequeue();

            maxMove = Math.Max(maxMove, len);


            if (r - 1 >= 0 && c + 1 < n && grid[r][c] < grid[r - 1][c + 1] && map[r - 1][c + 1] == false)
            {
                queue.Enqueue((r - 1, c + 1, len + 1));
                map[r - 1][c + 1] = true;
            }

            if (c + 1 < n && grid[r][c] < grid[r][c + 1] && map[r][c + 1] == false)
            {
                queue.Enqueue((r, c + 1, len + 1));
                map[r][c + 1] = true;
            }

            if (r + 1 < m && c + 1 < n && grid[r][c] < grid[r + 1][c + 1] && map[r + 1][c + 1] == false)
            {
                queue.Enqueue((r + 1, c + 1, len + 1));
                map[r + 1][c + 1] = true;
            }
        }

        return maxMove;
    }

    public int MaxMoves_DP(int[][] grid)
    {
        int m = grid.Length;
        int n = grid[0].Length;
        int[][] dp = new int[m][];
        for (int i = 0; i < m; i++)
        {
            dp[i] = new int[n];
        }

        for (int col = n - 2; col >= 0; col--)
        {
            for (int row = 0; row < m; row++)
            {
                int max = 0;
                if (row - 1 >= 0 && grid[row][col] < grid[row - 1][col + 1])
                {
                    max = Math.Max(max, dp[row - 1][col + 1] + 1);
                }

                if (grid[row][col] < grid[row][col + 1])
                {
                    max = Math.Max(max, dp[row][col + 1] + 1);
                }

                if (row + 1 < m && grid[row][col] < grid[row + 1][col + 1])
                {
                    max = Math.Max(max, dp[row + 1][col + 1] + 1);
                }

                dp[row][col] = max;
            }
        }

        return dp.Max(x => x[0]);
    }
}