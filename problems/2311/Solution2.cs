public class Solution
{
    public int LongestSubsequence(string s, int k)
    {
        int n = s.Length;
        int[] dp = new int[n];
        int[] countZero = new int[n + 1];
        for (int i = 1; i <= n; i++)
        {
            countZero[i] = countZero[i - 1] + '1' - s[i - 1];
        }
        string binaryK = IntToBinary(k);
        dp[0] = 1;
        for (int i = 1; i < n; i++)
        {
            if (i < binaryK.Length - 1) dp[i] = i + 1;
            else
            {
                int start = i - binaryK.Length + 1;
                dp[i] = Math.Max(dp[i - 1], countZero[start] + (Compare(s.Substring(start, binaryK.Length), binaryK) <= 0 ? binaryK.Length : binaryK.Length - 1));
            }
        }

        return dp[n - 1];
    }

    string IntToBinary(int n)
    {
        StringBuilder sb = new();
        while (n > 0)
        {
            sb.Append(n & 1);
            n >>= 1;
        }
        char[] tmp = sb.ToString().ToArray();
        Array.Reverse(tmp);
        return new(tmp);
    }

    int Compare(string a, string b)
    {
        if (a.Length != b.Length) return a.Length - b.Length;
        for (int i = 0; i < a.Length; i++)
        {
            if (a[i] - b[i] != 0) return a[i] - b[i];
        }
        return 0;
    }
}