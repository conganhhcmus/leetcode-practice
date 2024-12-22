#if DEBUG
namespace Contests_429_Q3;
#endif

public class Solution
{
    public int MinLength(string s, int numOps)
    {
        int left = 1, right = s.Length, ans = s.Length;
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


        while (left <= right)
        {
            int mid = left + (right - left) / 2;
            if (CanDivide(s, map, numOps, mid))
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

    private bool CanDivide(string s, Dictionary<int, int> map, int n, int len)
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
        else
        {
            int diff = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] != '0' + (i % 2))
                {
                    diff++;
                }
            }
            return Math.Min(diff, s.Length - diff) <= n;
        }
    }
}