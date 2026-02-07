public class Solution
{
    public int MaxBottlesDrunk(int numBottles, int numExchange)
    {
        int ans = 0;
        while (numBottles >= numExchange)
        {
            ans += numExchange;
            numBottles -= numExchange;
            numExchange++;
            numBottles++;
        }
        ans += numBottles;
        return ans;
    }
}