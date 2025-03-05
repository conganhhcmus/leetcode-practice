#if DEBUG
namespace Contests_431_Q2;
#endif

public class Solution
{
    public long CalculateScore(string s)
    {
        char[] map = new char[26];
        for (char ch = 'a'; ch <= 'z'; ch++) map[ch - 'a'] = ch;
        Array.Sort(map, (a, b) => b - a);
        SortedList<int, int>[] preIndex = new SortedList<int, int>[26];
        for (int i = 0; i < 26; i++)
        {
            preIndex[i] = new SortedList<int, int>(Comparer<int>.Create((a, b) => b - a));
        }

        int n = s.Length;
        long ans = 0;
        bool[] marked = new bool[n];
        for (int i = 0; i < n; i++)
        {
            if (marked[i]) continue;
            int mapCh = map[s[i] - 'a'];
            if (preIndex[mapCh - 'a'].Count == 0)
            {
                preIndex[s[i] - 'a'].Add(i, i);
            }
            else
            {
                int j = preIndex[mapCh - 'a'].First().Value;
                ans += i - j;
                marked[i] = true;
                marked[j] = true;
                preIndex[mapCh - 'a'].RemoveAt(0);
            }
        }
        return ans;
    }
}