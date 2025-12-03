#if DEBUG
namespace Problems_3625;
#endif

public class Solution
{
    public int CountTrapezoids(int[][] points)
    {
        int n = points.Length;
        double INF = 1e9 + 7;

        // slope -> list of intercepts
        Dictionary<double, List<double>> slopeToIntercepts = [];

        // midpointKey -> list of slopes
        Dictionary<double, List<double>> midpointToSlopes = [];

        int ans = 0;

        for (int i = 0; i < n; i++)
        {
            int x1 = points[i][0];
            int y1 = points[i][1];

            for (int j = i + 1; j < n; j++)
            {
                int x2 = points[j][0];
                int y2 = points[j][1];

                int dx = x1 - x2;
                int dy = y1 - y2;

                double slope;
                double intercept;

                // vertical line
                if (x1 == x2)
                {
                    slope = INF;
                    intercept = x1;  // use x-intercept for vertical lines
                }
                else
                {
                    slope = (double)(y2 - y1) / (x2 - x1);
                    intercept = (double)(y1 * dx - x1 * dy) / dx;
                }

                // unique midpoint key (scaled to avoid precision issues)
                double midpointKey = (x1 + x2) * 10000.0 + (y1 + y2);

                if (!slopeToIntercepts.ContainsKey(slope))
                    slopeToIntercepts[slope] = [];

                if (!midpointToSlopes.ContainsKey(midpointKey))
                    midpointToSlopes[midpointKey] = [];

                slopeToIntercepts[slope].Add(intercept);
                midpointToSlopes[midpointKey].Add(slope);
            }
        }

        // Count pairs of parallel segments on different lines
        foreach (var interceptList in slopeToIntercepts.Values)
        {
            if (interceptList.Count <= 1) continue;

            Dictionary<double, int> freq = [];
            foreach (double b in interceptList)
                freq[b] = freq.GetValueOrDefault(b, 0) + 1;

            int prefixSum = 0;
            foreach (int count in freq.Values)
            {
                ans += prefixSum * count;
                prefixSum += count;
            }
        }

        // Remove pairs lying on the same midpoint (same segment mirror)
        foreach (var slopeList in midpointToSlopes.Values)
        {
            if (slopeList.Count <= 1) continue;

            Dictionary<double, int> freq = [];
            foreach (double k in slopeList)
                freq[k] = freq.GetValueOrDefault(k, 0) + 1;

            int prefixSum = 0;
            foreach (int count in freq.Values)
            {
                ans -= prefixSum * count;
                prefixSum += count;
            }
        }

        return ans;
    }
}
