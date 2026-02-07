public class Solution
{
    public bool MaxSubstringLength(string s, int k)
    {
        if (k == 0) return true;
        int n = s.Length;
        int[] first = new int[26];
        int[] last = new int[26];
        Array.Fill(first, int.MaxValue);
        Array.Fill(last, -1);
        for (int i = 0; i < n; i++)
        {
            int key = s[i] - 'a';
            first[key] = Math.Min(first[key], i);
            last[key] = i;
        }

        // build valid substring contain characters
        int[] freq = new int[26];
        int[][] prefixSum = new int[n + 1][];
        prefixSum[0] = [.. freq];
        for (int i = 0; i < n; i++)
        {
            freq[s[i] - 'a']++;
            prefixSum[i + 1] = [.. freq];
        }
        List<(int st, int ed)> intervals = [];
        for (int i = 0; i < 26; i++)
        {
            if (last[i] == -1) continue;
            int left = first[i];
            int right = last[i];
            if (left == right)
            {
                intervals.Add((left, right));
                continue;
            }

            for (int j = 0; j < 26; j++)
            {
                if (j == i || last[j] == -1) continue;
                if (prefixSum[right + 1][j] - prefixSum[left][j] == 0) continue;
                left = Math.Min(left, first[j]);
                right = Math.Max(right, last[j]);
                if (left == 0 && right == n - 1) break;
            }

            if (left != 0 || right != n - 1)
            {
                intervals.Add((left, right));
            }
        }

        intervals.Sort((a, b) => a.ed - b.ed);
        // count number of intervals non overlapping
        int count = 0, prev = -1;
        for (int i = 0; i < intervals.Count; i++)
        {
            if (prev == -1 || intervals[prev].ed < intervals[i].st) count++;
            prev = i;
        }

        return count >= k;
    }
}