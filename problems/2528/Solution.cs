public class Solution
{
    public long MaxPower(int[] stations, int r, int k)
    {
        int n = stations.Length;
        long[] prefix = new long[n + 1];
        for (int i = 0; i < n; i++)
        {
            prefix[i + 1] = prefix[i] + stations[i];
        }
        long[] power = new long[n];
        for (int i = 0; i < n; i++)
        {
            int left = Math.Max(0, i - r);
            int right = Math.Min(n - 1, i + r);
            power[i] = prefix[right + 1] - prefix[left];
        }
        long low = 0, high = prefix[n] + k, ans = 0;

        while (low <= high)
        {
            long mid = low + (high - low) / 2;
            if (IsValid(power, mid, r, k))
            {
                ans = mid;
                low = mid + 1;
            }
            else
            {
                high = mid - 1;
            }
        }

        return ans;
    }

    bool IsValid(long[] power, long val, int r, long k)
    {
        int n = power.Length;
        long[] add = new long[n + 1];
        long curr = 0;

        for (int i = 0; i < n; i++)
        {
            curr += add[i];
            long total = power[i] + curr;
            if (total < val)
            {
                long need = val - total;
                k -= need;
                if (k < 0) return false;
                curr += need;
                if (i + 2 * r + 1 < n)
                    add[i + 2 * r + 1] -= need;
            }
        }

        return true;
    }
}