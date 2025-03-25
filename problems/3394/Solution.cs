#if DEBUG
namespace Problems_3394;
#endif

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
        int minX = int.MaxValue;
        xPairs.Sort((a, b) => a[0] - b[0]);
        minX = xPairs[0][1];
        for (int i = 0; i < k; i++)
        {
            int x1 = xPairs[i][0], x2 = xPairs[i][1];
            if (x1 < minX && x2 > minX) minX = x2;
        }

        int maxX = int.MinValue;
        xPairs.Sort((a, b) => b[1] - a[1]);
        maxX = xPairs[0][0];
        for (int i = 0; i < k; i++)
        {
            int x1 = xPairs[i][0], x2 = xPairs[i][1];
            if (x2 > maxX && x1 < maxX) maxX = x1;
        }
        int minY = int.MaxValue;
        yPairs.Sort((a, b) => a[0] - b[0]);
        minY = yPairs[0][1];
        for (int i = 0; i < k; i++)
        {
            int y1 = yPairs[i][0], y2 = yPairs[i][1];
            if (y1 < minY && y2 > minY) minY = y2;
        }
        int maxY = int.MinValue;
        yPairs.Sort((a, b) => b[1] - a[1]);
        maxY = yPairs[0][0];
        for (int i = 0; i < k; i++)
        {
            int y1 = yPairs[i][0], y2 = yPairs[i][1];
            if (y2 > maxY && y1 < maxY) maxY = y1;
        }

        if (minY < maxY)
        {
            foreach (var rectangle in rectangles)
            {
                int x1 = rectangle[0], y1 = rectangle[1], x2 = rectangle[2], y2 = rectangle[3];
                if (minY <= y1 && y2 <= maxY) return true;
            }
        }

        if (minX < maxX)
        {
            foreach (var rectangle in rectangles)
            {
                int x1 = rectangle[0], y1 = rectangle[1], x2 = rectangle[2], y2 = rectangle[3];
                if (minX <= x1 && x2 <= maxX) return true;
            }
        }

        return false;
    }
}