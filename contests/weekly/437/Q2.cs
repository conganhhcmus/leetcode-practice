#if DEBUG
namespace Contests_437_Q2;
#endif

public class Solution
{
    public long MaxWeight(int[] pizzas)
    {
        // odd-numbered choose the largest number
        // even-numbered choose two the largest numbers but choose smaller of them
        // so choose odd-numbered first is optimal than choose even-numbered first
        Array.Sort(pizzas);
        int n = pizzas.Length;
        long ans = 0;
        int m = n / 4;
        for (int i = 0; i < (m + 1) / 2; i++)
        {
            ans += pizzas[n - 1 - i];
        }
        for (int i = 0; i < m / 2; i++)
        {
            ans += pizzas[n - 1 - (m + 1) / 2 - 2 * i - 1];
        }
        return ans;
    }
}