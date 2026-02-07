public class Solution
{
    public double SeparateSquares(int[][] squares)
    {
        long totalArea = 0;
        List<int[]> events = [];
        foreach (var sq in squares)
        {
            int y = sq[1], l = sq[2];
            totalArea += 1L * l * l;
            events.Add([y, l, 1]);
            events.Add([y + l, l, -1]);
        }

        events.Sort((a, b) => a[0].CompareTo(b[0]));
        double coveredWith = 0;
        double currArea = 0;
        double prevHeight = 0;
        foreach (var e in events)
        {
            int y = e[0];
            int l = e[1];
            int d = e[2];

            int diff = y - (int)prevHeight;
            double area = coveredWith * diff;
            if (2L * (currArea + area) >= totalArea)
            {
                return prevHeight + (totalArea - 2.0 * currArea) / (2.0 * coveredWith);
            }

            coveredWith += d * l;
            currArea += area;
            prevHeight = y;
        }

        return 0.0;
    }
}