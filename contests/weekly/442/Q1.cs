#if DEBUG
namespace Weekly_442_Q1;
#endif

public class Solution
{
    public int MaxContainers(int n, int w, int maxWeight)
    {
        return Math.Min(n * n, maxWeight / w);
    }
}