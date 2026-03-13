public class Solution
{
    public long MinNumberOfSeconds(int mountainHeight, int[] workerTimes)
    {
        int maxTime = 0;
        foreach (int time in workerTimes)
        {
            maxTime = Math.Max(maxTime, time);
        }
        long lo = 1;
        long hi = 1L * mountainHeight * (mountainHeight + 1) * maxTime;
        long ans = hi;
        while (lo <= hi)
        {
            long mid = lo + (hi - lo) / 2;
            if (Ok(mid, mountainHeight, workerTimes))
            {
                ans = mid;
                hi = mid - 1;
            }
            else
            {
                lo = mid + 1;
            }
        }
        return ans;
    }

    bool Ok(long t, long h, int[] arr)
    {
        // t = x(x+1)/2 * worker[i];
        // => x(x+1)/2 = t / worker[i];
        // => x(x+1) = 2*t / worker[i];
        // => x^2 <= 2*t / worker[i];
        // => x <= sqrt(2*t / worker[i]);
        long sum = 0;
        foreach (int w in arr)
        {
            long v = 2 * (t / w);
            long x = (long)Math.Sqrt(v);
            if (x * (x + 1) > v) x--;
            sum += x;
            if (sum >= h) return true;
        }

        return sum >= h;
    }
}