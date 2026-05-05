public class Solution
{
    public int MinCostConnectPoints(int[][] points)
    {
        int n = points.Length;
        int INF = 1 << 30;
        bool[] inTree = new bool[n];
        int[] minDist = new int[n];
        Array.Fill(minDist, INF);
        minDist[0] = 0;
        int ans = 0;
        for (int i = 0; i < n; i++)
        {
            int min = INF;
            int curr = -1;
            for (int j = 0; j < n; j++)
            {
                if (!inTree[j] && minDist[j] < min)
                {
                    min = minDist[j];
                    curr = j;
                }
            }
            ans += min;
            inTree[curr] = true;
            for (int j = 0; j < n; j++)
            {
                int dist = Math.Abs(points[j][0] - points[curr][0]) + Math.Abs(points[j][1] - points[curr][1]);
                if (!inTree[j] && minDist[j] > dist)
                {
                    minDist[j] = dist;
                }
            }
        }
        return ans;
    }
}
