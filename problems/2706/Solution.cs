public class Solution
{
    public int BuyChoco(int[] prices, int money)
    {
        int min1 = int.MaxValue, min2 = int.MaxValue;
        foreach (int price in prices)
        {
            if (min1 > price)
            {
                min2 = min1;
                min1 = price;
            }
            else if (min2 > price)
            {
                min2 = price;
            }
        }
        if (min1 + min2 > money) return money;
        return money - min1 - min2;
    }
}