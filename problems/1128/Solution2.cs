#if DEBUG
namespace Problems_1128_2;
#endif

public class Solution
{
    public int NumEquivDominoPairs(int[][] dominoes)
    {
        int[] count = new int[100];
        int ret = 0;
        foreach (int[] domino in dominoes)
        {
            if (domino[0] > domino[1]) (domino[0], domino[1]) = (domino[1], domino[0]);
            int key = domino[0] * 10 + domino[1];
            ret += count[key];
            count[key]++;
        }
        return ret;
    }
}