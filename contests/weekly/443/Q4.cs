public class Solution
{
    public long MinOperations(int[] nums, int x, int k)
    {
        int n = nums.Length;
        long[] minCost = MinCost(nums, x);
        long[,] dp = new long[n + 1, k + 1];
        for (int i = 0; i <= n; i++)
        {
            dp[i, 0] = 0;
            for (int j = 1; j <= k; j++)
            {
                dp[i, j] = long.MaxValue / 3;
            }
        }
        for (int i = 1; i <= n; i++)
        {
            for (int t = 1; t <= k; t++)
            {
                dp[i, t] = dp[i - 1, t];
                if (i >= x)
                {
                    dp[i, t] = Math.Min(dp[i, t], dp[i - x, t - 1] + minCost[i - x]);
                }
            }
        }

        return dp[n, k];
    }

    long[] MinCost(int[] nums, int x)
    {
        int n = nums.Length;
        long[] ret = new long[n];
        MaxHeap lows = new(n);
        MinHeap highs = new(n);
        long hCost = 0, lCost = 0;
        Array.Fill(ret, long.MaxValue / 3);
        for (int i = 0; i < n; i++)
        {
            highs.Add(i, nums[i]);
            hCost += nums[i];
            if (i - x >= 0)
            {
                if (lows.Remove(i - x) != MaxHeap.INF)
                {
                    lCost -= nums[i - x];
                }
                if (highs.Remove(i - x) != MinHeap.INF)
                {
                    hCost -= nums[i - x];
                }
            }
            while (highs.Size > lows.Size + 1)
            {
                int arg = highs.ArgMin;
                highs.Remove(arg);
                lows.Add(arg, nums[arg]);
                hCost -= nums[arg];
                lCost += nums[arg];
            }

            while (lows.Size > highs.Size)
            {
                int arg = lows.ArgMax;
                lows.Remove(arg);
                highs.Add(arg, nums[arg]);
                hCost += nums[arg];
                lCost -= nums[arg];
            }
            while (lows.Size > 0 && highs.Min < lows.Max)
            {
                int argl = lows.ArgMax;
                int argh = highs.ArgMin;
                lows.Remove(argl);
                highs.Remove(argh);
                highs.Add(argl, nums[argl]);
                lows.Add(argh, nums[argh]);
                hCost += nums[argl] - nums[argh];
                lCost += nums[argh] - nums[argl];
            }

            if (i - x + 1 >= 0)
            {
                long mid = highs.Min;
                ret[i - x + 1] = hCost - mid * highs.Size + mid * lows.Size - lCost;
            }
        }
        return ret;
    }
}

public class MinHeap
{
    public int[] a;
    public int[] map;
    public int[] imap;
    public int n;
    public int pos;
    public const int INF = int.MaxValue;

    public MinHeap(int m)
    {
        n = m + 2;
        a = new int[n];
        map = new int[n];
        imap = new int[n];
        for (int i = 0; i < n; i++)
        {
            a[i] = INF;
            map[i] = -1;
            imap[i] = -1;
        }
        pos = 1;
    }

    public int Add(int ind, int x)
    {
        int ret = imap[ind];
        if (imap[ind] < 0)
        {
            a[pos] = x;
            map[pos] = ind;
            imap[ind] = pos;
            pos++;
            Up(pos - 1);
        }
        return ret != -1 ? a[ret] : x;
    }

    public int Update(int ind, int x)
    {
        int ret = imap[ind];
        if (imap[ind] < 0)
        {
            Add(ind, x);
        }
        else
        {
            a[ret] = x;
            Up(ret);
            Down(ret);
        }
        return x;
    }

    public int Remove(int ind)
    {
        if (pos == 1) return INF;
        if (imap[ind] == -1) return INF;

        pos--;
        int rem = imap[ind];
        int ret = a[rem];
        map[rem] = map[pos];
        imap[map[pos]] = rem;
        imap[ind] = -1;
        a[rem] = a[pos];
        a[pos] = INF;
        map[pos] = -1;

        Up(rem);
        Down(rem);
        return ret;
    }

    public int Min => a[1];
    public int ArgMin => map[1];
    public int Size => pos - 1;
    public int Get(int ind) => a[imap[ind]];

    private void Up(int cur)
    {
        for (int c = cur, p = c >> 1; p >= 1 && a[p] > a[c]; c = p, p = c >> 1)
        {
            // Swap a[p] and a[c]
            (a[c], a[p]) = (a[p], a[c]);

            // Swap imap entries for the original map[p] and map[c]
            (imap[map[c]], imap[map[p]]) = (imap[map[p]], imap[map[c]]);

            // Swap map[p] and map[c]
            (map[c], map[p]) = (map[p], map[c]);
        }
    }

    private void Down(int cur)
    {
        int c = cur;
        while (true)
        {
            int left = 2 * c;
            int right = left + 1;
            int smallest = c;

            if (left < pos && a[left] < a[smallest])
                smallest = left;
            if (right < pos && a[right] < a[smallest])
                smallest = right;

            if (smallest == c)
                break;

            // Swap a[c] and a[smallest]
            (a[smallest], a[c]) = (a[c], a[smallest]);

            // Swap imap entries for the original map[c] and map[smallest]
            (imap[map[smallest]], imap[map[c]]) = (imap[map[c]], imap[map[smallest]]);

            // Swap map[c] and map[smallest]
            (map[smallest], map[c]) = (map[c], map[smallest]);
            c = smallest;
        }
    }
}

public class MaxHeap
{
    public int[] a;
    public int[] map;
    public int[] imap;
    public int n;
    public int pos;
    public const int INF = int.MinValue;

    public MaxHeap(int m)
    {
        n = m + 2;
        a = new int[n];
        map = new int[n];
        imap = new int[n];
        for (int i = 0; i < n; i++)
        {
            a[i] = INF;
            map[i] = -1;
            imap[i] = -1;
        }
        pos = 1;
    }

    public int Add(int ind, int x)
    {
        int ret = imap[ind];
        if (imap[ind] < 0)
        {
            a[pos] = x;
            map[pos] = ind;
            imap[ind] = pos;
            pos++;
            Up(pos - 1);
        }
        return ret != -1 ? a[ret] : x;
    }

    public int Update(int ind, int x)
    {
        int ret = imap[ind];
        if (imap[ind] < 0)
        {
            Add(ind, x);
        }
        else
        {
            a[ret] = x;
            Up(ret);
            Down(ret);
        }
        return x;
    }

    public int Remove(int ind)
    {
        if (pos == 1) return INF;
        if (imap[ind] == -1) return INF;

        pos--;
        int rem = imap[ind];
        int ret = a[rem];
        map[rem] = map[pos];
        imap[map[pos]] = rem;
        imap[ind] = -1;
        a[rem] = a[pos];
        a[pos] = INF;
        map[pos] = -1;

        Up(rem);
        Down(rem);
        return ret;
    }

    public int Max => a[1];
    public int ArgMax => map[1];
    public int Size => pos - 1;
    public int Get(int ind) => a[imap[ind]];

    private void Up(int cur)
    {
        for (int c = cur, p = c >> 1; p >= 1 && a[p] < a[c]; c = p, p = c >> 1)
        {
            // Swap a[p] and a[c]
            (a[c], a[p]) = (a[p], a[c]);

            // Swap imap entries for the original map[p] and map[c]
            (imap[map[c]], imap[map[p]]) = (imap[map[p]], imap[map[c]]);

            // Swap map[p] and map[c]
            (map[c], map[p]) = (map[p], map[c]);
        }
    }

    private void Down(int cur)
    {
        int c = cur;
        while (true)
        {
            int left = 2 * c;
            int right = left + 1;
            int smallest = c;

            if (left < pos && a[left] > a[smallest])
                smallest = left;
            if (right < pos && a[right] > a[smallest])
                smallest = right;

            if (smallest == c)
                break;

            // Swap a[c] and a[smallest]
            (a[smallest], a[c]) = (a[c], a[smallest]);

            // Swap imap entries for the original map[c] and map[smallest]
            (imap[map[smallest]], imap[map[c]]) = (imap[map[c]], imap[map[smallest]]);

            // Swap map[c] and map[smallest]
            (map[smallest], map[c]) = (map[c], map[smallest]);
            c = smallest;
        }
    }
}