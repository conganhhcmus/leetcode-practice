#if DEBUG
namespace Problems_3321;
#endif

public class Solution
{
    static readonly Comparer<(int freq, int num)> compare = Comparer<(int freq, int num)>.Create((a, b) =>
    {
        if (a.freq == b.freq)
        {
            return a.num - b.num;
        }
        return a.freq - b.freq;
    });

    readonly SortedSet<(int freq, int num)> large = new(compare);
    readonly SortedSet<(int freq, int num)> small = new(compare);

    readonly Dictionary<int, int> freq = [];

    readonly HashSet<int> inLarge = [];

    long sum = 0;

    void Add(int num, int x)
    {
        if (freq.TryGetValue(num, out int oldFreq) && oldFreq > 0)
        {
            InternalRemove((oldFreq, num), x);
        }
        int newFreq = oldFreq + 1;
        freq[num] = newFreq;
        InternalAdd((newFreq, num), x);
    }

    void Remove(int num, int x)
    {
        int oldFreq = freq[num];
        InternalRemove((oldFreq, num), x);
        int newFreq = oldFreq - 1;
        if (newFreq == 0)
        {
            freq.Remove(num);
        }
        else
        {
            freq[num] = newFreq;
        }
        if (newFreq > 0)
        {
            InternalAdd((newFreq, num), x);
        }
    }

    void InternalAdd((int freq, int num) p, int x)
    {
        if (large.Count < x)
        {
            large.Add(p);
            inLarge.Add(p.num);
            sum += (long)p.freq * p.num;
            return;
        }

        if (large.Count > 0 && Equal(p, large.Min) > 0)
        {
            var minL = large.Min;
            large.Remove(minL);
            inLarge.Remove(minL.num);
            sum -= (long)minL.freq * minL.num;

            large.Add(p);
            inLarge.Add(p.num);
            sum += (long)p.freq * p.num;
            small.Add(minL);
        }
        else
        {
            small.Add(p);
        }
    }

    void InternalRemove((int freq, int num) p, int x)
    {
        if (inLarge.Contains(p.num))
        {
            if (large.Remove(p))
            {
                inLarge.Remove(p.num);
                sum -= (long)p.freq * p.num;
            }

            if (small.Count > 0)
            {
                var maxS = small.Max;
                small.Remove(maxS);
                large.Add(maxS);
                inLarge.Add(maxS.num);
                sum += (long)maxS.freq * maxS.num;
            }
        }
        else
        {
            small.Remove(p);
        }
    }

    static int Equal((int freq, int num) a, (int freq, int num) b)
    {
        if (a.freq == b.freq)
        {
            return a.num - b.num;
        }
        return a.freq - b.freq;
    }

    public long[] FindXSum(int[] nums, int k, int x)
    {
        int n = nums.Length;
        long[] ans = new long[n - k + 1];
        for (int i = 0; i < k; i++)
        {
            Add(nums[i], x);
        }
        ans[0] = sum;
        for (int i = k; i < n; i++)
        {
            Add(nums[i], x);
            Remove(nums[i - k], x);
            ans[i - k + 1] = sum;
        }
        return ans;
    }
}