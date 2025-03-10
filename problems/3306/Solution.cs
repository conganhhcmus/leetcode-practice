#if DEBUG
namespace Problems_3306;
#endif

public class Solution
{
    public long CountOfSubstrings(string word, int k)
    {
        int[] freq = new int[6];
        Dictionary<char, int> map = [];
        map['a'] = 1;
        map['e'] = 2;
        map['i'] = 3;
        map['o'] = 4;
        map['u'] = 5;
        int n = word.Length;
        int[][] prefixFreq = new int[n + 1][];
        prefixFreq[0] = [.. freq];
        for (int i = 1; i <= n; i++)
        {
            freq[map.GetValueOrDefault(word[i - 1], 0)]++;
            prefixFreq[i] = [.. freq];
        }

        long ans = 0;
        int l = 0, r = 0;
        while (r < n)
        {
            while (l < r && prefixFreq[r + 1][0] - prefixFreq[l][0] > k) l++;
            while (r < n && !Ok(prefixFreq, l, r, k))
            {
                r++;
                while (l < r && r < n && prefixFreq[r + 1][0] - prefixFreq[l][0] > k) l++;
            }
            if (r == n) break;
            // binary search max l
            int low = l, high = r, maxl = l;
            while (low <= high)
            {
                int mid = low + (high - low) / 2;
                if (Ok(prefixFreq, mid, r, k))
                {
                    maxl = mid;
                    low = mid + 1;
                }
                else high = mid - 1;
            }
            ans += maxl - l + 1;
            r++;
        }

        return ans;
    }

    bool Ok(int[][] prefixFreq, int l, int r, int k)
    {
        int[] currFreq = new int[6];
        for (int i = 0; i < 6; i++)
        {
            currFreq[i] = prefixFreq[r + 1][i] - prefixFreq[l][i];
        }
        if (currFreq[0] != k) return false;
        for (int i = 1; i < 6; i++)
        {
            if (currFreq[i] == 0) return false;
        }

        return true;
    }
}