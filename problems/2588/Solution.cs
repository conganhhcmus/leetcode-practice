public class Solution
{
    public long BeautifulSubarrays(int[] a)
    {
        // a[l..r] have all freq[bit] is even
        // a[r] - a[l] have all freq[bit] is even
        // a[r] == a[l] (freq[bit] mod 2)
        // 10^6 ~ 20 bits
        int n = a.Length;
        int[] freq = new int[21];
        string[] count = new string[n + 1];
        count[0] = GetKey(freq);
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < 21; ++j)
            {
                freq[j] += (a[i] >> j) & 1;
            }
            count[i + 1] = GetKey(freq);
        }

        long ret = 0;
        Dictionary<string, int> map = [];
        for (int i = 0; i <= n; i++)
        {
            ret += map.GetValueOrDefault(count[i], 0);
            map[count[i]] = map.GetValueOrDefault(count[i], 0) + 1;
        }

        return ret;
    }

    string GetKey(int[] freq)
    {
        StringBuilder sb = new();
        for (int i = 0; i < freq.Length; ++i)
        {
            sb.Append(freq[i] % 2);
        }

        return sb.ToString();
    }
}