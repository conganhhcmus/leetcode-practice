public class Solution
{
    public string SmallestPalindrome(string s, int k)
    {
        int n = s.Length;
        int[] freq = new int[26];
        for (int i = 0; i < n / 2; i++)
        {
            freq[s[i] - 'a']++;
        }
        long total = CountPermutations(freq, k + 1);
        if (total < k) return "";
        StringBuilder sb = new();
        for (int pos = 0; pos < n / 2; pos++)
        {
            for (int i = 0; i < 26; i++)
            {
                if (freq[i] == 0) continue;
                freq[i]--;
                long count = CountPermutations(freq, k + 1);
                if (count >= k)
                {
                    sb.Append((char)('a' + i));
                    break;
                }
                else
                {
                    k -= (int)count;
                    freq[i]++;
                }
            }
        }
        string firstHalf = sb.ToString();
        string center = n % 2 == 0 ? "" : s[n / 2].ToString();
        char[] secondHalfChars = firstHalf.ToCharArray();
        Array.Reverse(secondHalfChars);
        string secondHalf = new(secondHalfChars);
        return firstHalf + center + secondHalf;
    }

    long CountPermutations(int[] freq, int limit)
    {
        long ret = 1;
        int j = 0;
        for (int i = 0; i < 26; i++)
        {
            ret *= Ckn(freq[i], j + freq[i], limit);
            if (ret >= limit) return limit;
            j += freq[i];
        }
        return ret;
    }

    long Ckn(int k, int n, int limit)
    {
        if (k > n) return 0;
        k = Math.Min(k, n - k);
        long ret = 1;
        for (int i = 1; i <= k; i++)
        {
            ret *= n - i + 1;
            ret /= i;
            if (ret >= limit) return limit;
        }
        return ret;
    }
}