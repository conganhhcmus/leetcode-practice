public class Solution
{
    public int MaxIceCream(int[] costs, int coins)
    {
        Array.Sort(costs, (a, b) => a - b);
        int cnt = 0;
        foreach (int x in costs)
        {
            if (x > coins) break;
            coins -= x;
            cnt++;
        }
        return cnt;
    }
}
