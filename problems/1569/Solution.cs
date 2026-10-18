public class Solution {
    private long[][] table;
    private const long Mod = 1_000_000_007;

    public int NumOfWays(int[] nums) {
        int m = nums.Length;
        // Table of Pascal's triangle
        table = new long[m + 1][];
        for (int i = 0; i < m + 1; ++i) {
            table[i] = new long[i + 1];
            Array.Fill(table[i], 1L);
            for (int j = 1; j < i; ++j) {
                table[i][j] = (table[i - 1][j - 1] + table[i - 1][j]) % Mod;
            }
        }

        return (int)((Dfs(new List<int>(nums)) - 1 + Mod) % Mod);
    }

    private long Dfs(List<int> nums) {
        int m = nums.Count;
        if (m < 3) {
            return 1;
        }

        var leftNodes = new List<int>();
        var rightNodes = new List<int>();
        for (int i = 1; i < m; ++i) {
            if (nums[i] < nums[0]) {
                leftNodes.Add(nums[i]);
            } else {
                rightNodes.Add(nums[i]);
            }
        }

        long leftWays = Dfs(leftNodes) % Mod;
        long rightWays = Dfs(rightNodes) % Mod;

        return (((leftWays * rightWays) % Mod) * table[m - 1][leftNodes.Count]) % Mod;
    }
}