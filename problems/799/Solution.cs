public class Solution
{
    public double ChampagneTower(int poured, int query_row, int query_glass)
    {
        // 1
        // 1 1
        // 1 2 1
        // 1 3 3 1
        // 1 4 6 4 1
        double[] row = new double[query_row + 1];
        row[0] = poured;
        for (int i = 1; i <= query_row; i++)
        {
            double[] nextRow = new double[query_row + 1];
            // get poured
            for (int j = 0; j <= i; j++)
            {
                row[j] = Math.Max(0.0, row[j] - 1.0) / 2.0;
            }
            nextRow[0] = row[0];
            for (int j = 1; j <= i; j++)
            {
                nextRow[j] = row[j] + row[j - 1];
            }
            row = nextRow;
        }

        return Math.Min(1.0, row[query_glass]);
    }
}