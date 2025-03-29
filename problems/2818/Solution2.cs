#if DEBUG
namespace Problems_2818_2;
#endif

public class Solution
{
    int modulo = (int)1e9 + 7;

    public int MaximumScore(IList<int> nums, int k)
    {
        int n = nums.Count;
        int[] numsArr = new int[n];
        int maxNum = 0;
        for (int i = 0; i < n; i++)
        {
            numsArr[i] = nums[i];
            maxNum = Math.Max(maxNum, numsArr[i]);
        }
        int[] primeScore = BuildPrimeScore(maxNum);
        int[] left = new int[n];
        int[] right = new int[n];
        Stack<int> stack = [];
        for (int i = 0; i < n; i++)
        {
            while (stack.Count > 0 && primeScore[numsArr[stack.Peek()]] < primeScore[numsArr[i]])
            {
                stack.Pop();
            }
            left[i] = stack.Count == 0 ? i + 1 : i - stack.Peek();
            stack.Push(i);
        }
        stack.Clear();
        for (int i = n - 1; i >= 0; i--)
        {
            while (stack.Count > 0 && primeScore[numsArr[stack.Peek()]] <= primeScore[numsArr[i]])
            {
                stack.Pop();
            }
            right[i] = stack.Count == 0 ? n - i : stack.Peek() - i;
            stack.Push(i);
        }

        long[] subArrays = new long[n];
        for (int i = 0; i < n; i++)
        {
            subArrays[i] = 1L * left[i] * right[i];
        }

        Array.Sort(numsArr, subArrays, Comparer<int>.Create((a, b) => b.CompareTo(a)));
        long score = 1, remain = k;
        int idx = 0;
        while (remain > 0)
        {
            score = score * FastPower(numsArr[idx], Math.Min(remain, subArrays[idx])) % modulo;
            remain -= subArrays[idx];
            idx++;
        }
        return (int)score;
    }

    // Sieve Prime Factorization
    int[] BuildPrimeScore(int maxValue)
    {
        int[] primeScore = new int[maxValue + 1];
        for (int i = 2; i <= maxValue; i++)
        {
            if (primeScore[i] == 0)
            {
                for (int j = i; j <= maxValue; j += i)
                {
                    primeScore[j]++;
                }
            }
        }

        return primeScore;
    }

    public long FastPower(long a, long b)
    {
        long ans = 1;
        a %= modulo;
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