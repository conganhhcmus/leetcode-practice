#if DEBUG
namespace Problems_2086_2;
#endif

public class Solution
{
    public int MinimumBuckets(string hamsters)
    {
        int n = hamsters.Length;
        int ret = 0;
        for (int i = 0; i < n; i++)
        {
            if (hamsters[i] == '.') continue;
            if (!CanFeed(hamsters, i)) return -1;
            if (i < n - 2 && hamsters[i + 1] == '.' && hamsters[i + 2] == 'H') i += 2;
            ret++;
        }

        return ret;
    }

    bool CanFeed(string hamsters, int index)
    {
        return (index > 0 && hamsters[index - 1] == '.') || (index + 1 < hamsters.Length && hamsters[index + 1] == '.');
    }
}