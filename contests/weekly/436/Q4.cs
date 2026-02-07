public class Solution
{
    public long MaxScore(int[] points, int m)
    {
        int n = points.Length;
        if (m < n) return 0;
        long ans = 0, left = 1, right = long.MaxValue;
        while (left <= right)
        {
            long mid = left + (right - left) / 2;
            if (IsValid(points, m, mid))
            {
                ans = mid;
                left = mid + 1;
            }
            else
            {
                right = mid - 1;
            }
        }

        return ans;
    }

    private bool IsValid(int[] points, int m, long val)
    {
        int n = points.Length;
        long[] need = new long[n];
        for (int i = 0; i < n; i++)
        {
            need[i] = (val + points[i] - 1) / points[i];
            need[i]--;
            if (need[i] >= m) return false;
        }
        long total = n;
        for (int i = 0; i < n - 1; i++)
        {
            if (need[i] > 0)
            {
                total += 2 * need[i];
                need[i + 1] -= need[i];
            }
        }
        if (need[n - 1] < 0) total--;
        else total += 2 * need[n - 1];

        return total <= m;
    }
}