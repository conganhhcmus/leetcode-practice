public class Solution
{
    public long MinPartitionScore(int[] nums, int k)
    {
        int n = nums.Length;
        long[] S = new long[n + 1];
        for (int i = 0; i < n; i++) S[i + 1] = S[i] + nums[i];

        long[] dp = new long[n + 1];

        // Initial case: Partition into 1 subarray
        for (int i = 1; i <= n; i++)
        {
            dp[i] = S[i] * (S[i] + 1) / 2;
        }

        if (k == 1) return dp[n];

        // Levels 2 to k
        for (int j = 2; j <= k; j++)
        {
            long[] nextDp = new long[n + 1];
            // Initialize CHT for this level
            ConvexHullTrick cht = new ConvexHullTrick(n);

            for (int i = 1; i <= n; i++)
            {
                // 1. Add line from previous split point (i-1)
                // Slope m = -2 * S[i-1]
                // Constant c = 2 * dp[i-1] + S[i-1]^2 - S[i-1]
                int p = i - 1;
                if (p >= j - 1)
                { // Ensure we have enough elements for previous partitions
                    long Sp = S[p];
                    cht.AddLine(-2 * Sp, 2 * dp[p] + Sp * Sp - Sp);
                }

                // 2. Query for current prefix sum S[i]
                if (i >= j)
                {
                    long val = cht.Query(S[i]);
                    nextDp[i] = (val + S[i] * S[i] + S[i]) / 2;
                }
            }
            dp = nextDp;
        }

        return dp[n];
    }
}

public class ConvexHullTrick
{
    private struct Line
    {
        public long M, C;
        public long Eval(long x) => M * x + C;

        // Using decimal for intersection to avoid precision issues with double
        public decimal IntersectX(Line other)
        {
            return (decimal)(other.C - C) / (M - other.M);
        }
    }

    private Line[] _dq;
    private int _head;
    private int _tail;

    public ConvexHullTrick(int maxSize)
    {
        _dq = new Line[maxSize + 1];
        _head = 0;
        _tail = -1;
    }

    /// <summary>
    /// Adds a line y = mx + c to the hull. 
    /// Assumes slopes are added in strictly decreasing order.
    /// </summary>
    public void AddLine(long m, long c)
    {
        Line newLine = new Line { M = m, C = c };

        while (_tail - _head >= 1)
        {
            if (newLine.IntersectX(_dq[_tail]) <= _dq[_tail].IntersectX(_dq[_tail - 1]))
            {
                _tail--;
            }
            else
            {
                break;
            }
        }
        _dq[++_tail] = newLine;
    }

    /// <summary>
    /// Queries the minimum y-value for a given x.
    /// Assumes x-queries are strictly increasing.
    /// </summary>
    public long Query(long x)
    {
        if (_tail < _head) throw new InvalidOperationException("Hull is empty");

        while (_tail - _head >= 1)
        {
            // if (_dq[_head].Eval(x) <= _dq[_head + 1].Eval(x)) // get maxinum
            if (_dq[_head].Eval(x) >= _dq[_head + 1].Eval(x)) // get minimum
            {
                _head++;
            }
            else
            {
                break;
            }
        }
        return _dq[_head].Eval(x);
    }
}
