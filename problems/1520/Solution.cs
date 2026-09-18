public class Solution
{
    public IList<string> MaxNumOfSubstrings(string s)
    {
        int n = s.Length;
        // with each char
        // subs[idx] = [st, ed]
        // sort by (st, ed)
        List<int[]> points = [];
        int[] last = new int[26];
        int[] first = new int[26];
        Array.Fill(last, -1);
        Array.Fill(first, -1);
        for (int i = 0; i < n; i++) last[s[i] - 'a'] = i;
        for (int i = n - 1; i >= 0; i--) first[s[i] - 'a'] = i;

        for (int i = 0; i < 26; i++)
        {
            if (last[i] == -1 || first[i] == -1) continue;
            int st = first[i], ed = last[i];
            int j = st;
            bool isOk = true;
            while (j <= ed)
            {
                int idx = s[j] - 'a';
                if (first[idx] < st)
                {
                    isOk = false;
                    break;
                }
                ed = Math.Max(ed, last[idx]);
                j++;
            }
            if (isOk) points.Add([st, ed]);
        }
        points.Sort((a, b) =>
        {
            if (a[0] == b[0]) return a[1] - b[1];
            return a[0] - b[0];
        });
        // take or ignore to get max
        // have max = 26 points
        Dictionary<int, (int, int, int)> memo = [];
        var (_, _, bitmask) = Dfs(0);
        List<string> ans = [];
        for (int i = 0; i < 26; i++)
        {
            if ((bitmask & (1 << i)) != 0)
            {
                ans.Add(s[points[i][0]..(points[i][1] + 1)]);
            }
        }
        return ans;


        // dp[i] = (num, len, state)
        (int num, int len, int state) Dfs(int pos)
        {
            if (pos >= points.Count) return (0, 0, 0);
            if (memo.TryGetValue(pos, out (int, int, int) cache)) return cache;
            // pick it
            int low = pos + 1, high = points.Count - 1, best = points.Count;
            while (low <= high)
            {
                int mid = low + (high - low) / 2;
                if (points[mid][0] > points[pos][1])
                {
                    best = mid;
                    high = mid - 1;
                }
                else
                {
                    low = mid + 1;
                }
            }
            int num1 = 1, len1 = points[pos][1] - points[pos][0] + 1, state1 = 1 << pos;
            var next1 = Dfs(best);
            num1 += next1.num;
            len1 += next1.len;
            state1 |= next1.state;
            // skip it
            var (num2, len2, state2) = Dfs(pos + 1);
            if (num1 > num2) return memo[pos] = (num1, len1, state1);
            else if (num2 > num1) return memo[pos] = (num2, len2, state2);
            else
            {
                if (len1 < len2) return memo[pos] = (num1, len1, state1);
                return memo[pos] = (num2, len2, state2);
            }
        }
    }
}