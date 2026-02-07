public class Solution
{
    public bool CheckValidCuts(int n, int[][] rectangles)
    {
        int k = rectangles.Length;
        List<int[]> xPairs = [];
        List<int[]> yPairs = [];
        foreach (var rectangle in rectangles)
        {
            int x1 = rectangle[0], y1 = rectangle[1], x2 = rectangle[2], y2 = rectangle[3];
            xPairs.Add([x1, x2]);
            yPairs.Add([y1, y2]);
        }
        return Check(xPairs) || Check(yPairs);
    }

    bool Check(List<int[]> pairs)
    {
        int ret = 0;
        pairs.Sort((a, b) => a[0] - b[0]);
        int pre = pairs[0][1];
        foreach (var pair in pairs)
        {
            int a = pair[0], b = pair[1];
            if (pre <= a)
            {
                ret++;
            }
            pre = Math.Max(pre, b);
        }
        return ret > 1;
    }
}