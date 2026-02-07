public class Solution
{
    public int CountTrapezoids(int[][] points)
    {
        int mod = (int)1e9 + 7;
        Dictionary<int, int> pointNum = [];
        long ans = 0, sum = 0;

        foreach (int[] point in points)
        {
            int y = point[1];
            if (pointNum.ContainsKey(y))
            {
                pointNum[y]++;
            }
            else
            {
                pointNum[y] = 1;
            }
        }

        foreach (int pNum in pointNum.Values)
        {
            long edge = (long)pNum * (pNum - 1) / 2;
            ans = (ans + edge * sum) % mod;
            sum = (sum + edge) % mod;
        }

        return (int)ans;
    }
}