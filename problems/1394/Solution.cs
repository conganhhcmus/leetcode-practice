#if DEBUG
namespace Problems_1394;
#endif

public class Solution
{
    public int FindLucky(int[] arr)
    {
        int[] count = new int[501];
        foreach (int num in arr)
        {
            count[num]++;
        }

        for (int i = 500; i > 0; i--)
        {
            if (count[i] == i) return i;
        }
        return -1;
    }
}