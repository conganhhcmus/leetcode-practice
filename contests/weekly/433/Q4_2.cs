public class Solution
{
    public long MinMaxSubarraySum(int[] nums, int k)
    {
        int n = nums.Length;
        var st = new SparseTable(nums);

        int[,] dp = new int[n, 4];
        for (int i = 0; i < n; i++)
        {
            // dp[i] = number of subarray where nums[i] is maximum or minimum
            int l = 0, r = i - 1, res = i;
            while (l <= r)
            {
                int mid = l + (r - l) / 2;
                if (st.Query(mid + 1, i).min > nums[i])
                {
                    res = mid;
                    r = mid - 1;
                }
                else l = mid + 1;
            }
            dp[i, 0] = i - res + 1;

            l = i + 1; r = n - 1; res = i;
            while (l <= r)
            {
                int mid = l + (r - l) / 2;
                if (st.Query(i + 2, mid + 1).min >= nums[i])
                {
                    res = mid;
                    l = mid + 1;
                }
                else r = mid - 1;
            }

            dp[i, 1] = res - i + 1;

            l = 0; r = i - 1; res = i;
            while (l <= r)
            {
                int mid = l + (r - l) / 2;
                if (st.Query(mid + 1, i).max < nums[i])
                {
                    res = mid;
                    r = mid - 1;
                }
                else l = mid + 1;
            }
            dp[i, 2] = i - res + 1;

            l = i + 1; r = n - 1; res = i;
            while (l <= r)
            {
                int mid = l + (r - l) / 2;
                if (st.Query(i + 2, mid + 1).max <= nums[i])
                {
                    res = mid;
                    l = mid + 1;
                }
                else r = mid - 1;
            }

            dp[i, 3] = res - i + 1;
        }

        long ans = 0;
        for (int i = 0; i < n; i++)
        {
            ans += 1L * nums[i] * Calc(dp[i, 0], dp[i, 1], k);
            ans += 1L * nums[i] * Calc(dp[i, 2], dp[i, 3], k);
        }
        return ans;
    }

    private long Calc(int left, int right, int k)
    {
        left = Math.Min(k, left);
        right = Math.Min(k, right);
        int extra = Math.Max(0, left + right - 1 - k);
        long sub = (1L * extra * (extra + 1)) / 2;
        return 1L * left * right - sub;
    }
}

public class SparseTable
{
    const int MAX_BITS = 18;
    readonly int[,] fnMax;
    readonly int[,] fnMin;
    public SparseTable(int[] nums)
    {
        fnMax = new int[nums.Length + 1, MAX_BITS];
        fnMin = new int[nums.Length + 1, MAX_BITS];
        Build(nums);
    }

    private int Log2(int n)
    {
        int ans = 0;
        while ((n >>= 1) != 0) ans++;
        return ans;
    }

    // O(n * log n)
    private void Build(int[] nums)
    {
        int n = nums.Length;
        for (int i = 1; i <= n; i++)
        {
            fnMax[i, 0] = nums[i - 1];
            fnMin[i, 0] = nums[i - 1];
        }
        for (int j = 1; j <= Log2(n); j++)
        {
            for (int i = 1; i + (1 << j) - 1 <= n; i++)
            {
                fnMax[i, j] = Math.Max(fnMax[i, j - 1], fnMax[i + (1 << (j - 1)), j - 1]); // save maximum value
                fnMin[i, j] = Math.Min(fnMin[i, j - 1], fnMin[i + (1 << (j - 1)), j - 1]); // save minimum value
            }
        }
    }

    // O(log n)
    public (int min, int max) Query(int l, int r)
    {
        int k = Log2(r - l + 1);
        int min = Math.Min(fnMin[l, k], fnMin[r - (1 << k) + 1, k]); // get min value
        int max = Math.Max(fnMax[l, k], fnMax[r - (1 << k) + 1, k]); // get max value

        return (min, max);
    }
}