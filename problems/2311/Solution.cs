#if DEBUG
namespace Problems_2311;
#endif

public class Solution
{
    public int LongestSubsequence(string s, int k)
    {
        string binaryK = IntToBinary(k);
        int ret = 1;
        for (int i = 1; i <= s.Length; i++)
        {
            ret = Math.Max(ret, LongestSubsequence(s[..i], binaryK));
        }
        return ret;
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

    int LongestSubsequence(string a, string b)
    {
        if (a.Length < b.Length) return a.Length;
        int remain = a.Length - b.Length;
        int count = 0;
        for (int i = 0; i < remain; i++)
        {
            if (a[i] == '0') count++;
        }
        for (int i = 0; i < b.Length; i++)
        {
            if (a[remain + i] - b[i] < 0) break;
            if (a[remain + i] - b[i] > 0)
            {
                count--;
                break;
            }
        }
        return count + b.Length;
    }
}