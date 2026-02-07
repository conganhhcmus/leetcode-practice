public class Solution
{
    public int NumWaterBottles(int numBottles, int numExchange)
    {
        int ans = numBottles;
        while (numBottles >= numExchange)
        {
            int remain = numBottles % numExchange;
            numBottles /= numExchange;
            ans += numBottles;
            numBottles += remain;
        }

        return ans;
    }
}