#if DEBUG
namespace Problems_1352_2;
#endif

public class ProductOfNumbers
{
    List<int> prefixSum;
    public ProductOfNumbers()
    {
        prefixSum = [];
    }

    public void Add(int num)
    {
        if (num == 0) prefixSum.Clear();
        else if (prefixSum.Count == 0) prefixSum.Add(num);
        else prefixSum.Add(prefixSum[^1] * num);
    }

    public int GetProduct(int k)
    {
        if (prefixSum.Count < k) return 0;
        if (prefixSum.Count == k) return prefixSum[^1];
        return prefixSum[^1] / prefixSum[^(k + 1)];
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