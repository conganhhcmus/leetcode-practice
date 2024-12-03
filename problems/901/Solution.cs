namespace Problem_901;

public class StockSpanner
{
    private Stack<int[]> _stack;
    private int _count;
    public StockSpanner()
    {
        _stack = [];
        _count = 0;
    }

    public int Next(int price)
    {
        _count++;
        while (_stack.Count > 0 && _stack.Peek()[0] <= price)
        {
            _stack.Pop();
        }
        int ans = _stack.Count == 0 ? _count : _count - _stack.Peek()[1];
        _stack.Push([price, _count]);
        return ans;
    }
}

public class Solution
{
    public List<string> Execute(string[] requests, int[][] values)
    {
        var stockSpanner = new StockSpanner();
        List<string> result = [];
        for (int i = 0; i < requests.Length; i++)
        {
            switch (requests[i])
            {
                case "next":
                    result.Add(stockSpanner.Next(values[i][0]).ToString());
                    break;
                default:
                    result.Add("null");
                    break;
            }
        }
        return result;
    }
}