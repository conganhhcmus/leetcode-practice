public class Solution
{
    public bool CheckOverlap(int radius, int xCenter, int yCenter, int x1, int y1, int x2, int y2)
    {
        int dx = Math.Max(x1, Math.Min(xCenter, x2)) - xCenter;
        int dy = Math.Max(y1, Math.Min(yCenter, y2)) - yCenter;
        return dx * dx + dy * dy <= radius * radius;
    }
}
