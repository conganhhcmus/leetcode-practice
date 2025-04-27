#if DEBUG
namespace Weekly_447_Q4;
#endif

public class Solution
{
    public int[] PathExistenceQueries(int n, int[] nums, int maxDiff, int[][] queries)
    {
        int[] idx = new int[n];
        for (int i = 0; i < n; i++)
        {
            idx[i] = i;
        }
        Array.Sort(nums, idx);
        int[] mapIdx = new int[n];
        for (int i = 0; i < n; i++)
        {
            mapIdx[idx[i]] = i;
        }

        int[] next = new int[n];
        int p = 0;
        for (int i = 0; i < n; i++)
        {
            while (p < n && Math.Abs(nums[p] - nums[i]) <= maxDiff) p++;
            next[i] = p - 1;
        }
        int[][] sf = SparseTable(next);
        int[] ret = new int[queries.Length];
        for (int i = 0; i < queries.Length; i++)
        {
            int u = queries[i][0], v = queries[i][1];
            int st = mapIdx[u], ed = mapIdx[v];
            if (st > ed) (st, ed) = (ed, st);
            if (sf[21][st] < ed)
            {
                ret[i] = -1;
                continue;
            }
            if (st == ed)
            {
                ret[i] = 0;
                continue;
            }
            for (int j = 21; j >= 0; j--)
            {
                int ne = sf[j][st];
                if (ne < ed)
                {
                    st = ne;
                    ret[i] |= 1 << j;
                }
            }
            if (next[st] >= ed)
            {
                ret[i]++;
            }
            else
            {
                ret[i] = -1;
            }

        }
        return ret;
    }

    int[][] SparseTable(int[] next)
    {
        int n = next.Length;
        int m = 22;
        int[][] sf = new int[m][];
        for (int i = 0; i < m; i++)
        {
            sf[i] = new int[n];
        }
        Array.Copy(next, sf[0], n);
        for (int i = 1; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                sf[i][j] = (sf[i - 1][j] == -1) ? -1 : sf[i - 1][sf[i - 1][j]];
            }
        }
        return sf;
    }
}