public class Solution
{
    public int[] ValidSequence(string word1, string word2)
    {
        int n = word1.Length, m = word2.Length;
        List<int>[] map = new List<int>[26];
        for (int i = 0; i < 26; i++) map[i] = [];
        for (int i = 0; i < n; i++)
        {
            map[word1[i] - 'a'].Add(i);
        }

        int[] ans = new int[m];
        Dictionary<(int, int, bool), bool> memo = [];
        bool changed = false;
        int cur = -1;
        for (int i = 0; i < m; i++)
        {
            bool ok1 = Ok(cur, i, changed);
            bool ok2 = !changed && (word2[i] != word1[cur + 1]) && Ok(cur + 1, i + 1, true);
            if (!ok1 && !ok2) return [];
            if (ok2)
            {
                cur++;
                ans[i] = cur;
                changed = true;
            }
            else if (ok1)
            {
                int best = LowerBound(cur, word2[i] - 'a');
                ans[i] = best;
                cur = best;
            }
        }

        return ans;

        int LowerBound(int st, int t)
        {
            List<int> idx = map[t];
            int low = 0, high = idx.Count - 1, best = -1;
            while (low <= high)
            {
                int mid = (low + high) / 2;
                if (idx[mid] > st)
                {
                    best = idx[mid];
                    high = mid - 1;
                }
                else
                {
                    low = mid + 1;
                }
            }
            return best;
        }

        bool Ok(int st, int pos, bool changed)
        {
            if (st >= n) return false;
            if (pos >= m) return true;
            var key = (st, pos, changed);
            if (memo.TryGetValue(key, out bool cache)) return cache;
            int best = LowerBound(st, word2[pos] - 'a');
            bool ans = false;
            if (best != -1) ans |= Ok(best, pos + 1, changed);

            if (!changed) ans |= Ok(st + 1, pos + 1, true);

            return memo[key] = ans;
        }
    }
}
