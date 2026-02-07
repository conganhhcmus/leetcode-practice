public class Solution
{
    public int MinLength(string s, int numOps)
    {
        int rep = 1;
        Dictionary<int, int> map = [];
        for (int i = 1; i < s.Length; i++)
        {
            if (s[i] == s[i - 1]) rep++;
            else
            {
                map[rep] = map.GetValueOrDefault(rep, 0) + 1;
                rep = 1;
            }
        }
        map[rep] = map.GetValueOrDefault(rep, 0) + 1;

        int minOpsLen1 = 0;
        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] != '0' + (i % 2))
            {
                minOpsLen1++;
            }
        }
        minOpsLen1 = Math.Min(minOpsLen1, s.Length - minOpsLen1);

        int left = 1, right = s.Length, ans = s.Length;
        while (left <= right)
        {
            int mid = left + (right - left) / 2;
            if (CanDivide(s, map, numOps, mid, minOpsLen1))
            {
                ans = mid;
                right = mid - 1;
            }
            else
            {
                left = mid + 1;
            }
        }
        return ans;
    }

    private bool CanDivide(string s, Dictionary<int, int> map, int n, int len, int minOpsLen1)
    {
        if (len > 1)
        {
            int ans = 0;
            foreach (int h in map.Keys)
            {
                if (h > len)
                {
                    ans += h / (len + 1) * map[h];
                }
            }
            return ans <= n;
        }

        return minOpsLen1 <= n;
    }
}