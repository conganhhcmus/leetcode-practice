public class Solution
{
    public long CountRatioSubarrays(int[] nums, int a, int b)
    {
        int n = nums.Length;
        // compute all prefix values
        long[] prefix = new long[n + 1];
        int odd = 0, even = 0;
        for (int i = 0; i < n; i++)
        {
            if (nums[i] % 2 == 0) even++;
            else odd++;
            prefix[i + 1] = 1L * odd * a - 1L * even * b;
        }

        long[] values = [.. prefix];
        Array.Sort(values);
        int m = 1;
        for (int i = 1; i < values.Length; i++)
        {
            if (values[i] != values[m - 1])
            {
                values[m] = values[i];
                m++;
            }
        }
        Fenwick bit = new(m);
        long ans = 0;
        foreach (long x in prefix)
        {
            int idx = LowerBound(values, m, x) + 1;
            ans += bit.Query(idx);
            bit.Add(idx, 1);
        }
        return ans;
    }

    int LowerBound(long[] arr, int len, long t)
    {
        int l = 0, r = len - 1, ans = len;
        while (l <= r)
        {
            int mid = (l + r) >> 1;
            if (arr[mid] >= t)
            {
                ans = mid;
                r = mid - 1;
            }
            else
            {
                l = mid + 1;
            }
        }
        return ans;
    }

    class Fenwick
    {
        long[] tree;
        public Fenwick(int n)
        {
            tree = new long[n + 1];
        }
        public void Add(int idx, long delta)
        {
            while (idx < tree.Length)
            {
                tree[idx] += delta;
                idx += idx & -idx;
            }
        }
        public long Query(int idx)
        {
            long sum = 0;
            while (idx > 0)
            {
                sum += tree[idx];
                idx -= idx & -idx;
            }
            return sum;
        }
    }
}
