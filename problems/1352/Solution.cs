public class ProductOfNumbers
{
    List<int> prefixSums;
    int lastZeroIndex;
    public ProductOfNumbers()
    {
        lastZeroIndex = 1;
        prefixSums = [1];
    }

    public void Add(int num)
    {
        if (num == 0) lastZeroIndex = 1;
        else lastZeroIndex++;

        prefixSums.Add(Math.Max(1, prefixSums[^1]) * num);
    }

    public int GetProduct(int k)
    {
        if (lastZeroIndex <= k) return 0;

        return prefixSums[^1] / Math.Max(1, prefixSums[^(k + 1)]);
    }
}

/**
 * Your ProductOfNumbers object will be instantiated and called as such:
 * ProductOfNumbers obj = new ProductOfNumbers();
 * obj.Add(num);
 * int param_2 = obj.GetProduct(k);
 */


public class Solution
{
    public List<dynamic> Execute(string[] actions, int[][] values)
    {
        List<dynamic> result = [];
        ProductOfNumbers productOfNumber = null;
        for (int i = 0; i < actions.Length; i++)
        {
            switch (actions[i])
            {
                case "ProductOfNumbers":
                    productOfNumber = new ProductOfNumbers();
                    result.Add(null);
                    break;
                case "add":
                    productOfNumber.Add(values[i][0]);
                    result.Add(null);
                    break;
                case "getProduct":
                    result.Add(productOfNumber.GetProduct(values[i][0]));
                    break;
                default:
                    break;
            }
        }
        return result;
    }
}