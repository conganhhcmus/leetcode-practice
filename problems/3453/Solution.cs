#if DEBUG
namespace Problems_3453;
#endif

public class Solution
{
    public double SeparateSquares(int[][] squares)
    {
        double totArea = 0.0;
        int maxY = 0;
        foreach (int[] sq in squares)
        {
            int x = sq[0], y = sq[1], l = sq[2];
            totArea += (double)l * l;
            maxY = Math.Max(maxY, y + l);
        }
        double eps = 1e-5;
        double lo = 0.0, hi = maxY;
        while (Math.Abs(hi - lo) > eps)
        {
            double mid = lo + (hi - lo) / 2;
            if (Check(mid, totArea, squares))
            {
                hi = mid;
            }
            else
            {
                lo = mid;
            }
        }
        return lo;
    }

    bool Check(double limitY, double totArea, int[][] squares)
    {
        double area = 0;
        foreach (int[] sq in squares)
        {
            int x = sq[0], y = sq[1], l = sq[2];
            if (y <= limitY)
            {
                area += (double)l * Math.Min(l, limitY - y);
            }
        }

        return area >= (totArea / 2);
    }
}