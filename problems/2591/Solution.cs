public class Solution
{
    public int DistMoney(int money, int children)
    {
        money -= children; // fill 1
        if (money < 0) return -1;
        int maxEights = Math.Min(children, money / 7);
        int remain = money - maxEights * 7;
        if (maxEights == children - 1 && remain == 3) maxEights--;
        if (maxEights == children && remain > 0) maxEights--;
        return maxEights;
    }
}