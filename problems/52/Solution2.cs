public class Solution
{
    public int TotalNQueens(int n)
    {
        bool[] cols = new bool[n];
        bool[] diag1 = new bool[2 * n];
        bool[] diag2 = new bool[2 * n];
        return Solve(0, cols, diag1, diag2);
    }

    int Solve(int row, bool[] cols, bool[] diag1, bool[] diag2)
    {
        int n = cols.Length;
        if (row == n) return 1;
        int ans = 0;
        for (int col = 0; col < n; col++)
        {
            if (cols[col] || diag1[row + col] || diag2[row - col + n]) continue;
            cols[col] = true;
            diag1[row + col] = true; // main diagonal, (i,j) => (i+1, j-1) => i+j = constant 
            diag2[row - col + n] = true; // anti diagonal, (i,j) => (i+1,j+1) => i-j = constant. i-j + n = constant
            ans += Solve(row + 1, cols, diag1, diag2);
            cols[col] = false;
            diag1[row + col] = false;
            diag2[row - col + n] = false;
        }
        return ans;
    }
}