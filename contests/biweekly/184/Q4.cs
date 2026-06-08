public class Solution
{
    int MAX = 100_000;
    int[] spf;
    int[] divCnt;
    int[] freq;
    public int MaxScore(int[] nums, int maxVal)
    {
        spf = BuildSpf();
        divCnt = new int[MAX + 1];
        freq = new int[MAX + 1];
        foreach (int x in nums)
        {
            freq[x]++;
            List<int> primes = Factor(x);
            int k = primes.Count;
            for (int mask = 1; mask < (1 << k); mask++)
            {
                int prod = 1;
                for (int i = 0; i < k; i++)
                {
                    if ((mask & (1 << i)) != 0)
                    {
                        prod *= primes[i];
                    }
                }
                if (prod <= MAX)
                {
                    divCnt[prod]++;
                }
            }
        }
        int ans = int.MinValue;
        for (int v = 1; v <= MAX; v++)
        {
            if (freq[v] == 0 && v > maxVal) continue;
            if (v == 1)
            {
                int cost = freq[v] > 0 ? 0 : 1;
                ans = Math.Max(ans, v - cost);
            }
            else
            {
                int bad = Bad(v);
                int cost = freq[v] > 0 ? bad - 1 : Math.Max(1, bad);
                ans = Math.Max(ans, v - cost);
            }
        }
        return ans;
    }

    int Bad(int v)
    {
        List<int> primes = Factor(v);
        int k = primes.Count;
        int bad = 0;
        for (int mask = 1; mask < (1 << k); mask++)
        {
            int prod = 1;
            int bits = 0;
            for (int i = 0; i < k; i++)
            {
                if ((mask & (1 << i)) != 0)
                {
                    prod *= primes[i];
                    bits++;
                }
            }
            if ((bits & 1) == 1) bad += divCnt[prod];
            else bad -= divCnt[prod];
        }
        return bad;
    }

    List<int> Factor(int v)
    {
        HashSet<int> fact = [];
        while (spf[v] != v)
        {
            fact.Add(spf[v]);
            v /= spf[v];
        }
        if (v > 1) fact.Add(v);
        return [.. fact];
    }

    int[] BuildSpf()
    {
        int[] spf = new int[MAX + 1];
        for (int i = 0; i <= MAX; i++)
        {
            spf[i] = i;
        }
        for (int i = 2; i <= MAX; i++)
        {
            if (spf[i] == i)
            {
                for (int j = 2 * i; j <= MAX; j += i)
                {
                    spf[j] = i;
                }
            }
        }
        return spf;
    }
}
