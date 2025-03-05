#if DEBUG
namespace Problems_2579_2;
#endif

public class Solution
{
    public long ColoredCells(int n)
    {
        return 2L * n * (n - 1) + 1;
    }
}