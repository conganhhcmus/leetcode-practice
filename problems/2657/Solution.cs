#if DEBUG
namespace Problems_2657;
#endif

public class Solution
{
    public int[] FindThePrefixCommonArray(int[] A, int[] B)
    {
        int n = A.Length;
        int[] map = new int[n + 1];
        int[] res = new int[n];
        int count = 0;
        for (int i = 0; i < n; i++)
        {
            if (++map[A[i]] == 2) count++;
            if (++map[B[i]] == 2) count++;
            res[i] = count;
        }
        return res;
    }
}