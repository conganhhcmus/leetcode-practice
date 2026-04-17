public class Solution
{
    public double[] InternalAngles(int[] sides)
    {
        int a = sides[0],
            b = sides[1],
            c = sides[2];
        if (a + b <= c || a + c <= b || c + b <= a)
            return [];
        double A = Math.Acos((b * b + c * c - a * a) / (2D * b * c)) * 180 / Math.PI;
        double B = Math.Acos((a * a + c * c - b * b) / (2D * a * c)) * 180 / Math.PI;
        double C = Math.Acos((a * a + b * b - c * c) / (2D * a * b)) * 180 / Math.PI;
        double[] ans = [A, B, C];
        Array.Sort(ans);
        return ans;
    }
}
