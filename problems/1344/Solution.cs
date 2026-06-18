public class Solution
{
    public double AngleClock(int hour, int minutes)
    {
        double m = minutes * 360.0 / 60.0;
        double h = hour * 360.0 / 12.0;
        double e = minutes / 60.0 * 360.0 / 12.0;
        double ans = Math.Abs(h - m + e);
        return Math.Min(ans, 360.0 - ans);
    }
}
