#if DEBUG
using System.Text;

#endif

public class Solution
{
    public string RepeatLimitedString(string s, int repeatLimit)
    {
        int[] counts = new int[26];
        foreach (char c in s) counts[c - 'a']++;

        StringBuilder sb = new();
        int curr = 'z' - 'a';
        while (curr >= 0)
        {
            if (counts[curr] == 0)
            {
                curr--;
                continue;
            }
            int min = Math.Min(counts[curr], repeatLimit);
            sb.Append((char)('a' + curr), min);
            counts[curr] -= min;
            if (counts[curr] > 0)
            {
                int next = curr - 1;
                while (next >= 0 && counts[next] == 0) next--;
                if (next < 0) break;
                sb.Append((char)('a' + next));
                counts[next]--;
            }
        }

        return sb.ToString();
    }
}