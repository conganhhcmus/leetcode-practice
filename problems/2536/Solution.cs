public class Solution
{
    public int[][] RangeAddQueries(int n, int[][] queries)
    {
        int[][] mat = new int[n][];
        for (int i = 0; i < n; i++)
        {
            mat[i] = new int[n];
        }
        Dictionary<(int r1, int c1, int r2, int c2), int> map = [];
        foreach (int[] query in queries)
        {
            int r1 = query[0], c1 = query[1], r2 = query[2], c2 = query[3];
            var key = (r1, c1, r2, c2);
            map[key] = map.GetValueOrDefault(key, 0) + 1;
        }

        foreach (var pair in map)
        {
            var (r1, c1, r2, c2) = pair.Key;
            for (int i = r1; i <= r2; i++)
            {
                for (int j = c1; j <= c2; j++)
                {
                    mat[i][j] += pair.Value;
                }
            }
        }

        return mat;
    }
}