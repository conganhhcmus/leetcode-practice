public class Solution
{
    // max sum for 15 digits of 9 is 135; if you expect longer numbers increase this
    bool[] goodSums = new bool[136];

    public long CountFancy(long l, long r)
    {
        for (int i = 0; i <= 135; i++)
        {
            if (i < 10)
            {
                goodSums[i] = true;
            }
            else if (i < 100)
            {
                int d1 = i % 10, d2 = i / 10 % 10;
                goodSums[i] = d1 != d2;
            }
            else
            {
                int d1 = i % 10, d2 = i / 10 % 10, d3 = i / 100 % 10;
                goodSums[i] = (d1 < d2 && d2 < d3) || (d1 > d2 && d2 > d3);
            }
        }

        return CountFancy(r) - CountFancy(l - 1);
    }

    long CountFancy(long n)
    {
        if (n < 0) return 0;
        string str = n.ToString();
        memo.Clear();
        return DP(0, true, 0, -1, 0, str);
    }

    // memo key: (pos, tight, state, last, sum)
    // pos: 15
    // state: 4
    // last: 11
    // sum: 135
    Dictionary<int, long> memo = [];

    int FlatIndex(int pos, int state, int last, int sum)
    {
        return sum + last * 135 + state * 135 * 11 + pos * 135 * 11 * 4;
    }

    // state: 0 (unknown), 1 (increase), 2 (decrease), 3 (invalid)
    long DP(int pos, bool tight, int state, int last, int sum, string str)
    {
        int n = str.Length;
        if (pos == n)
        {
            // if sum is good OR state is not invalid, count this number
            return (goodSums[sum] || state != 3) ? 1L : 0L;
        }

        int key = FlatIndex(pos, state, last, sum);
        if (!tight && memo.TryGetValue(key, out long cache)) return cache;

        long ans = 0;
        int digit = str[pos] - '0';
        int max = tight ? digit : 9;

        for (int d = 0; d <= max; d++)
        {
            bool nTight = tight && (d == digit);

            int nState;
            if (last == -1 || (last == 0 && state == 0))
            {
                nState = 0;
            }
            else if ((state == 0 || state == 1) && d > last)
            {
                nState = 1;
            }
            else if ((state == 0 || state == 2) && d < last)
            {
                nState = 2;
            }
            else
            {
                nState = 3;
            }

            ans += DP(pos + 1, nTight, nState, d, sum + d, str);
        }

        if (!tight) memo[key] = ans;
        return ans;
    }
}
