public class Solution
{
    public int LongestBalanced(string s)
    {
        int n = s.Length;
        Dictionary<int, int> map = [];
        int bal = 0;
        int ans = 0;
        map[0] = -1;
        int ones = 0;
        for (int i = 0; i < n; i++)
        {
            char c = s[i];
            if (c == '1')
                ones++;
        }
        int zeros = n - ones;
        int cntO = 0,
            cntZ = 0;
        for (int i = 0; i < n; i++)
        {
            char c = s[i];
            if (c == '1')
            {
                bal++;
                cntO++;
            }
            else
            {
                bal--;
                cntZ++;
            }
            if (map.ContainsKey(bal))
            {
                ans = Math.Max(ans, i - map[bal]);
            }
            else
            {
                map[bal] = i;
            }

            if (bal > 0 && zeros > cntZ)
            {
                if (map.TryGetValue(bal - 2, out int j))
                {
                    ans = Math.Max(ans, i - j);
                }
            }

            if (bal < 0 && ones > cntO)
            {
                if (map.TryGetValue(bal + 2, out int j))
                {
                    ans = Math.Max(ans, i - j);
                }
            }
        }

        cntO = 0;
        cntZ = 0;
        bal = 0;
        map.Clear();
        map[0] = n;
        for (int i = n - 1; i >= 0; i--)
        {
            char c = s[i];
            if (c == '1')
            {
                bal++;
                cntO++;
            }
            else
            {
                bal--;
                cntZ++;
            }
            if (map.ContainsKey(bal))
            {
                ans = Math.Max(ans, map[bal] - i);
            }
            else
            {
                map[bal] = i;
            }

            if (bal > 0 && zeros > cntZ)
            {
                if (map.TryGetValue(bal - 2, out int j))
                {
                    ans = Math.Max(ans, j - i);
                }
            }

            if (bal < 0 && ones > cntO)
            {
                if (map.TryGetValue(bal + 2, out int j))
                {
                    ans = Math.Max(ans, j - i);
                }
            }
        }

        return ans;
    }
}
