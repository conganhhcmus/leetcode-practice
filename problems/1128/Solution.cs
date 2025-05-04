#if DEBUG
namespace Problems_1128;
#endif

public class Solution
{
    public int NumEquivDominoPairs(int[][] dominoes)
    {
        int ret = 0;
        Dictionary<(int a, int b), int> map = [];
        foreach (int[] domino in dominoes)
        {
            int a = domino[0], b = domino[1];
            if (a > b) (a, b) = (b, a);
            int exist = map.GetValueOrDefault((a, b), 0);
            ret += exist;
            map[(a, b)] = exist + 1;
        }
        return ret;
    }
}