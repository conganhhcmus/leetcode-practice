#if DEBUG
namespace Problems_2226;
#endif

public class Solution
{
    public int MaximumCandies(int[] candies, long k)
    {
        int low = 1, high = 10_000_000, ans = 0;
        while (low <= high)
        {
            int mid = low + (high - low) / 2;
            if (Ok(candies, k, mid))
            {
                ans = mid;
                low = mid + 1;
            }
            else high = mid - 1;
        }
        return ans;
    }

    bool Ok(int[] candies, long k, int mid)
    {
        int n = candies.Length;
        long count = 0;
        for (int i = 0; i < n; i++)
        {
            count += candies[i] / mid;
            if (count >= k) return true;
        }
        return false;
    }
}