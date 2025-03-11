#if DEBUG
namespace Problems_52_3;
#endif

public class Solution
{
    public int TotalNQueens(int n)
    {
        return Solve(0, 0, 0, 0, n);
    }

    int Solve(int row, int cols, int diag1, int diag2, int n)
    {
        if (row == n) return 1;
        int ans = 0;
        int allPos = (1 << n) - 1;
        int availablePos = allPos & ~(cols | diag1 | diag2);
        while (availablePos != 0)
        {
            int pos = availablePos & -availablePos; // get last set bit position
            ans += Solve(row + 1, cols | pos, (diag1 | pos) >> 1, (diag2 | pos) << 1, n);
            availablePos ^= pos; // clear the last set bit position
        }
        return ans;
    }
}