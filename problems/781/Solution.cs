#if DEBUG
namespace Problems_781;
#endif

public class Solution
{
    public int NumRabbits(int[] answers)
    {
        int[] map = new int[1000];
        foreach (int answer in answers)
        {
            map[answer]++;
        }

        int ret = 0;
        for (int i = 0; i < 1000; i++)
        {
            int group = (map[i] + i) / (i + 1);
            ret += group * (i + 1);
        }
        return ret;
    }
}