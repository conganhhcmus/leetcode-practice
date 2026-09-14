public class Solution
{
    public bool IsRectangleOverlap(int[] rec1, int[] rec2)
    {
        // check overlap vertical
        // check overlap horizontal
        // [x1, x2], [x3, x4] => min (x2, x4) > max (x1, x3)
        return Math.Min(rec1[2], rec2[2]) > Math.Max(rec1[0], rec2[0]) && Math.Min(rec1[3], rec2[3]) > Math.Max(rec1[1], rec2[1]);

    }
}