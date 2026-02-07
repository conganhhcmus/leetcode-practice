public class Solution
{
    public int MaxEqualRowsAfterFlips(int[][] matrix)
    {
        int m = matrix.Length;
        int n = matrix[0].Length;
        if (m == 1) return 1;
        if (n == 1) return m;
        Dictionary<string, int> map = [];
        for (int i = 0; i < m; i++)
        {
            string key = FormatMatrixRow(matrix[i]);
            map[key] = map.GetValueOrDefault(key, 0) + 1;
        }
        return map.Max(x => x.Value);
    }

    private string FormatMatrixRow(int[] row)
    {
        if (row[0] == 0)
        {
            return string.Join("", row);
        }
        return string.Join("", row.Select(x => x ^ 1));
    }
}