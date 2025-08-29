#if DEBUG
namespace Problems_3021;
#endif

public class Solution
{
    public long FlowerGame(int n, int m)
    {
        int oddFirst = (n + 1) / 2;
        int evenFirst = n - oddFirst;
        int oddSecond = (m + 1) / 2;
        int evenSecond = m - oddSecond;
        return 1L * oddFirst * evenSecond + 1L * evenFirst * oddSecond;
    }
}