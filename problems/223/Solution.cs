public class Solution
{
    public int ComputeArea(int ax1, int ay1, int ax2, int ay2, int bx1, int by1, int bx2, int by2)
    {
        if (ax1 > bx1)
        {
            (ax1, bx1) = (bx1, ax1);
            (ax2, bx2) = (bx2, ax2);
            (ay1, by1) = (by1, ay1);
            (ay2, by2) = (by2, ay2);
        }
        int s1 = Area(ax1, ay1, ax2, ay2);
        int s2 = Area(bx1, by1, bx2, by2);
        int s3 = 0;
        // check overlap

        if (IsOverlap(ax1, ax2, bx1, bx2) && IsOverlap(ay1, ay2, by1, by2))
        {
            int x = Math.Abs(Math.Max(ax1, bx1) - Math.Min(ax2, bx2));
            int y = Math.Abs(Math.Max(ay1, by1) - Math.Min(ay2, by2));
            s3 = x * y;
        }

        return s1 + s2 - s3;
    }

    bool IsOverlap(int x1, int x2, int x3, int x4)
    {
        // [x1, x2]
        // [x3, x4]
        return (Math.Max(x1, x3) < Math.Min(x2, x4));
    }

    int Area(int x1, int y1, int x2, int y2)
    {
        int x = Math.Abs(x1 - x2);
        int y = Math.Abs(y1 - y2);
        return x * y;
    }
}