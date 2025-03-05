#if DEBUG
namespace Contests_438_Q4_2;
#endif

public class Solution
{
    public int MaxDistance(int side, int[][] points, int k)
    {
        long[] distances = BuildDistance(points, side);
        // since k >= 4 so max of (min distance of 2 points) is side because choose 4 points (0,0), (0,side), (side,side), (side,0)
        int lo = 1, hi = side;
        int ans = 0;
        while (lo <= hi)
        {
            int mid = lo + (hi - lo) / 2;
            if (Ok(distances, mid, k))
            {
                ans = mid;
                lo = mid + 1;
            }
            else hi = mid - 1;
        }

        return ans;
    }

    long[] BuildDistance(int[][] points, int side)
    {
        // flat 2D to 1D array
        int n = points.Length;
        long[] distances = new long[n];
        int curr = 0;
        foreach (int[] p in points)
        {
            if (p[0] == 0)
            {
                distances[curr] = p[1];
            }
            else if (p[1] == side)
            {
                distances[curr] = 1L * side + p[0];
            }
            else if (p[0] == side)
            {
                distances[curr] = 2L * side + side - p[1];
            }
            else
            {
                distances[curr] = 3L * side + side - p[0];
            }
            curr++;
        }
        Array.Sort(distances);
        long[] ans = new long[2 * n];
        Array.Copy(distances, ans, n);
        for (int i = 0; i < n; i++)
        {
            ans[i + n] = 4L * side + ans[i];
        }
        return ans;
    }

    private bool Ok(long[] dis, int d, int k)
    {
        int n = dis.Length;
        int[] fn = new int[n]; // fn[i] = first point is at least d units away from dis[i]
        int r = 0;
        for (int l = 0; l < n; l++)
        {
            while (r < n && dis[r] < dis[l] + d) r++;
            fn[l] = r == n ? -1 : r;
        }

        int[,] sf = BuildSparseTable(fn, k);
        for (int i = 0; i < n / 2; i++)
        {
            int end = Query(i, k, sf);
            if (end <= i + n / 2 && end != -1) return true;
        }

        return false;
    }

    private int[,] BuildSparseTable(int[] fn, int k)
    {
        int n = fn.Length;
        int max = int.Log2(k) + 1;
        int[,] sf = new int[max, n]; // s[i,j] = index value of after jumping 2^i times from j
        for (int i = 0; i < n; i++) sf[0, i] = fn[i];
        for (int i = 1; i < max; i++)
        {
            for (int j = 0; j < n; j++)
            {
                sf[i, j] = sf[i - 1, j] == -1 ? -1 : sf[i - 1, sf[i - 1, j]];
            }
        }

        return sf;
    }

    private int Query(int from, int k, int[,] sf)
    {
        int max = int.Log2(k) + 1;
        int next = from;
        for (int i = max - 1; i >= 0; i--)
        {
            if (k << 31 - i < 0) // check i-th bit in k is set ~ (k >> i & 1) != 0
            {
                next = sf[i, next];
                if (next == -1) break;
            }
        }

        return next;
    }
}