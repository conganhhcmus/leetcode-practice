#if DEBUG
namespace Problems_2818;
#endif

public class Solution
{
    int modulo = 1000000007;

    public int MaximumScore(IList<int> nums, int k)
    {
        int[] spf = BuildSpf(100_000);
        int n = nums.Count;
        int[] primeScore = new int[n];
        Number[] sortedNums = new Number[n];
        for (int i = 0; i < n; i++)
        {
            primeScore[i] = GetPrimeScore(nums[i], spf);
            sortedNums[i] = new Number(nums[i], i);
        }
        Array.Sort(sortedNums, (a, b) => b.value - a.value);
        long score = 1;
        int idx = 0;
        long remain = k;
        while (remain > 0)
        {
            Number best = sortedNums[idx];
            long count = CountSubArrays(primeScore, best.index);
            score = score * FastPower(best.value, Math.Min(remain, count)) % modulo;
            idx++;
            remain -= count;
        }
        return (int)score;
    }

    public record Number(int value, int index);
    // Sieve Prime Factorization
    int[] BuildSpf(int maxValue)
    {
        int[] spf = new int[maxValue + 1];
        for (int i = 2; i <= maxValue; i++) spf[i] = i;
        for (int i = 2; i <= maxValue; i++)
        {
            if (spf[i] == i)
            {
                for (int j = 2 * i; j <= maxValue; j += i)
                {
                    if (spf[j] == j) spf[j] = i;
                }
            }
        }

        return spf;
    }

    int GetPrimeScore(int num, int[] spf)
    {
        HashSet<int> factors = [];
        while (num > 1)
        {
            int prime = spf[num];
            factors.Add(prime);
            num /= prime;
        }

        return factors.Count;
    }

    long CountSubArrays(int[] primeScore, int curr)
    {
        int lastIndex = curr;
        for (int i = curr; i < primeScore.Length; i++)
        {
            if (primeScore[i] <= primeScore[curr])
            {
                lastIndex = i;
            }
            else
            {
                break;
            }
        }
        int firstIndex = curr;
        for (int i = curr - 1; i >= 0; i--)
        {
            if (primeScore[i] < primeScore[curr])
            {
                firstIndex = i;
            }
            else
            {
                break;
            }
        }

        int left = curr - firstIndex + 1;
        int right = lastIndex - curr + 1;

        return 1L * left * right;
    }

    public long FastPower(long a, long b)
    {
        long ans = 1;
        while (b > 0)
        {
            if ((b & 1) > 0)
            {
                ans = ans * a % modulo;
            }
            a = a * a % modulo;
            b >>= 1;
        }
        return ans;
    }
}