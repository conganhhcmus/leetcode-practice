public class Solution
{
    public int[] FinalPrices(int[] prices)
    {
        int n = prices.Length;
        Stack<int> stack = [];
        for (int i = 0; i < n; i++)
        {
            while (stack.Count > 0 && prices[stack.Peek()] >= prices[i])
            {
                prices[stack.Pop()] -= prices[i];
            }

            stack.Push(i);
        }

        return prices;
    }
}