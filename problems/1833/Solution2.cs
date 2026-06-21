public class Solution
{
    public int MaxIceCream(int[] costs, int coins)
    {
        int MAX = 100_000;
        int[] cnt = new int[MAX + 1];
        foreach (int x in costs)
        {
            cnt[x]++;
        }
        int ans = 0;
        for (int i = 1; i <= MAX; i++)
        {
            if (i > coins) break;
            int buy = Math.Min(cnt[i], coins / i);
            ans += buy;
            coins -= buy * i;
        }
        return ans;
    }
}
