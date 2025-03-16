#if DEBUG
namespace Problems_2594;
#endif

public class Solution
{
    public long RepairCars(int[] ranks, int cars)
    {
        int minRank = int.MaxValue;
        foreach (int rank in ranks) minRank = Math.Min(minRank, rank);
        long low = 1, high = 1L * minRank * cars * cars, ans = 0;
        while (low <= high)
        {
            long mid = low + (high - low) / 2;
            if (Ok(ranks, cars, mid))
            {
                ans = mid;
                high = mid - 1;
            }
            else
            {
                low = mid + 1;
            }
        }
        return ans;
    }

    bool Ok(int[] ranks, int cars, long mid)
    {
        long total = 0;
        for (int i = 0; i < ranks.Length; i++)
        {
            total += (long)Math.Sqrt(mid / ranks[i]);
        }

        return total >= cars;
    }
}