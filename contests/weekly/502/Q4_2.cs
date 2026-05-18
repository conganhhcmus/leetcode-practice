public class Solution
{
    long M = 1_000_000_007;
    long B = 100001;

    public int SmallestUniqueSubarray(int[] nums)
    {
        int n = nums.Length;
        int low = 1, high = n, ans = n;
        while (low <= high)
        {
            int mid = low + (high - low) / 2;
            if (Check(mid))
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

        bool Check(int x)
        {
            long h = 0;
            long B_x = Pow(B, x);
            for (int i = 0; i < x; i++)
            {
                h = (h * B + nums[i]) % M;
            }
            HashSet<long> all = [h];
            HashSet<long> dup = [];
            for (int i = x; i < n; i++)
            {
                h = (h * B + nums[i] - nums[i - x] * B_x) % M;
                if (h < 0) h += M;
                if (!all.Add(h)) dup.Add(h);
            }
            return all.Count > dup.Count;
        }
    }

    long Pow(long a, long b)
    {
        long ans = 1;
        while (b > 0)
        {
            if ((b & 1) != 0)
            {
                ans = ans * a % M;
            }
            a = a * a % M;
            b >>= 1;
        }
        return ans;
    }
}
