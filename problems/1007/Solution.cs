#if DEBUG
namespace Problems_1007;
#endif

public class Solution
{
    public int MinDominoRotations(int[] tops, int[] bottoms)
    {
        // n = 2*10^4
        int n = tops.Length;
        int ret = int.MaxValue;
        for (int i = 1; i <= 6; i++)
        {
            int countTop = 0;
            int countBottom = 0;
            bool can = true;
            for (int j = 0; j < n; j++)
            {
                if (tops[j] == i && bottoms[j] == i) continue;
                if (tops[j] != i && bottoms[j] != i)
                {
                    can = false;
                    break;
                }
                if (tops[j] == i) countBottom++;
                if (bottoms[j] == i) countTop++;
            }
            if (can) ret = Math.Min(ret, Math.Min(countTop, countBottom));
        }
        if (ret == int.MaxValue) return -1;
        return ret;
    }
}