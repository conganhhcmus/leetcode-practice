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
            if (Feasible(distances, mid, k))
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
        long[] extDistances = new long[2 * n];
        Array.Copy(distances, extDistances, n);
        for (int i = 0; i < n; i++)
        {
            extDistances[i + n] = 4L * side + extDistances[i];
        }
        return extDistances;
    }

    private bool Feasible(long[] extDistances, int d, int k)
    {
        int n = extDistances.Length;
        int[] fn = new int[n]; // fn[i] = first point is at least d units away from dis[i]
        int r = 0;
        for (int l = 0; l < n; l++)
        {
            while (r < n && extDistances[r] < extDistances[l] + d) r++;
            fn[l] = r == n ? -1 : r;
        }

        for (int i = 0; i < n / 2; i++)
        {
            int count = 1;
            int next = fn[i];
            while (next <= i + n / 2 && next != -1)
            {
                next = fn[next];
                count++;
            }
            if (count > k) return true;
        }

        return false;
    }
}