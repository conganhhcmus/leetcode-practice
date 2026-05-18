public class Solution
{
    public int SmallestUniqueSubarray(int[] nums)
    {
        int n = nums.Length;
        RollingHash rh = new(n, 100001);
        for (int i = 0; i < n; i++)
        {
            rh.Add(nums[i]);
        }
        int low = 1, high = n, ans = n;
        while (low <= high)
        {
            int mid = low + (high - low) / 2;
            if (Ok(mid))
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

        bool Ok(int x)
        {
            HashSet<long> all = [];
            HashSet<long> dup = [];
            for (int i = 0; i + x <= n; i++)
            {
                long v = rh.Hash(i, i + x - 1);
                if (!all.Add(v)) dup.Add(v);
            }
            return all.Count > dup.Count;
        }
    }
}

public class RollingHash
{
    long mod = (long)1e9 + 7;
    long p = 31;
    int n;
    long[] hash;
    long[] pow;
    int len;

    public RollingHash(int n, int p)
    {
        this.len = 0;
        this.n = n;
        this.p = p;
        hash = new long[n + 1];
        pow = new long[n + 1];

        pow[0] = 1;
        for (int i = 1; i <= n; i++)
        {
            pow[i] = Mod(pow[i - 1] * p);
        }
    }

    long Mod(long a) => (a % mod + mod) % mod;

    public void Add(long val)
    {
        hash[len + 1] = Mod(hash[len] * p + val);
        len++;
    }

    // hash from [l..r]
    public long Hash(int l, int r)
    {
        return Mod(hash[r + 1] - Mod(hash[l] * pow[r - l + 1]));
    }
}
