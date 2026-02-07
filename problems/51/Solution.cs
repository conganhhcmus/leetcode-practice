public class Solution
{
    public IList<IList<string>> SolveNQueens(int n)
    {
        IList<IList<string>> ret = [];
        bool[] cols = new bool[n];
        bool[] diag1 = new bool[2 * n];
        bool[] diag2 = new bool[2 * n];

        BackTracking(ret, 0, n, diag1, diag2, cols, []);
        return ret;
    }
    void BackTracking(IList<IList<string>> ret, int pos, int n, bool[] diag1, bool[] diag2, bool[] cols, IList<string> choose)
    {
        if (pos >= n)
        {
            ret.Add([.. choose]);
            return;
        }
        StringBuilder sb = new();
        sb.Append('.', n);
        for (int i = 0; i < n; i++)
        {
            if (cols[i] || diag1[i + pos] || diag2[pos - i + n]) continue;
            cols[i] = diag1[i + pos] = diag2[pos - i + n] = true;
            sb[i] = 'Q';
            choose.Add(sb.ToString());
            BackTracking(ret, pos + 1, n, diag1, diag2, cols, choose);
            choose.RemoveAt(choose.Count - 1);
            sb[i] = '.';
            cols[i] = diag1[i + pos] = diag2[pos - i + n] = false;
        }
    }
}