public class Solution
{
    public long CountGoodIntegers(int n, int k)
    {
        long[] fact = new long[n + 1];
        fact[0] = 1;
        for (int i = 1; i <= n; i++)
        {
            fact[i] = fact[i - 1] * i;
        }
        long ret = 0;
        Backtracking(0, "", [], n, k, fact, ref ret);
        return ret;
    }

    void Backtracking(int pos, string numStr, HashSet<string> visited, int n, int k, long[] fact, ref long ret)
    {
        if (pos >= ((n + 1) / 2))
        {
            ret += CountKPalindromic(numStr, n, k, fact, visited);
            return;
        }
        for (int d = 0; d <= 9; d++)
        {
            if (pos == 0 && d == 0) continue;
            string newNumStr = numStr + d.ToString();
            Backtracking(pos + 1, newNumStr, visited, n, k, fact, ref ret);
        }
    }

    long CountKPalindromic(string numStr, int n, int k, long[] fact, HashSet<string> visited)
    {
        int len = numStr.Length;
        for (int i = n - len - 1; i >= 0; i--)
        {
            numStr += numStr[i];
        }
        long num = long.Parse(numStr);
        if (num % k != 0) return 0;
        int[] freq = GetFreq(numStr);
        if (!visited.Add(string.Join("_", freq))) return 0;
        long p = 1;
        for (int i = 1; i < 10; i++)
        {
            p *= fact[freq[i]];
        }
        long a = fact[n] / (fact[freq[0]] * p);
        if (freq[0] > 0)
        {
            return a - (fact[n - 1] / (fact[freq[0] - 1] * p));
        }
        return a;
    }

    int[] GetFreq(string numStr)
    {
        int[] freq = new int[10];
        foreach (char d in numStr) freq[d - '0']++;
        return freq;
    }
}