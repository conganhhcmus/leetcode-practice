#if DEBUG
namespace Problems_3085;
#endif

public class Solution
{
    public int MinimumDeletions(string word, int k)
    {
        int[] count = new int[26];
        foreach (char c in word)
        {
            count[c - 'a']++;
        }

        Array.Sort(count);
        int ret = int.MaxValue;
        int sum = 0;
        for (int i = 0; i < 26; i++)
        {
            int adjust = sum;
            for (int j = 25; j > i; j--)
            {
                if (count[j] - count[i] <= k) break;
                adjust += count[j] - (count[i] + k);
            }
            sum += count[i];
            ret = Math.Min(ret, adjust);
        }

        return ret;
    }
}