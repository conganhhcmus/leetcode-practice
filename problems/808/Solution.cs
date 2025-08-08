#if DEBUG
namespace Problems_808;
#endif

public class Solution
{
    public double SoupServings(int n)
    {
        int m = (n + 24) / 25;
        Dictionary<(int, int), double> dp = [];
        dp[(0, 0)] = 0.5;
        for (int i = 1; i <= m; i++)
        {
            dp[(0, i)] = 1;
            dp[(i, 0)] = 0;
            for (int j = 1; j <= i; j++)
            {
                dp[(j, i)] = Calc(dp, j, i);
                dp[(i, j)] = Calc(dp, i, j);
            }
            if (dp[(i, i)] > (1 - 1e-5))
            {
                return 1;
            }
        }

        return dp[(m, m)];
    }

    double Calc(Dictionary<(int, int), double> dp, int i, int j)
    {
        return (dp[(Math.Max(0, i - 4), j)] +
        dp[(Math.Max(0, i - 3), Math.Max(0, j - 1))] +
        dp[(Math.Max(0, i - 2), Math.Max(0, j - 2))] +
        dp[(Math.Max(0, i - 1), Math.Max(0, j - 3))]) / 4.0;
    }
}