namespace Problem_1381;

public class CustomStack
{
    private List<int> _stack;
    private int _maxSize;
    public CustomStack(int maxSize)
    {
        _stack = [];
        _maxSize = maxSize;
    }

    public void Push(int x)
    {
        if (_stack.Count >= _maxSize) return;

        _stack.Add(x);
    }

    public int Pop()
    {
        if (_stack.Count == 0) return -1;

        int ans = _stack[^1];
        _stack.RemoveAt(_stack.Count - 1);
        return ans;
    }

    public void Increment(int k, int val)
    {
        int minLength = int.Min(k, _stack.Count);
        for (int i = 0; i < minLength; i++)
        {
            _stack[i] += val;
        }
    }
}

public class Solution
{
    public List<string> Execute(string[] events, int[][] values)
    {
        List<string> result = [];
        CustomStack stack = new(0);

        for (int i = 0; i < events.Length; i++)
        {
            switch (events[i])
            {
                case "CustomStack":
                    stack = new CustomStack(values[i][0]);
                    result.Add("null");
                    break;

                case "push":
                    stack.Push(values[i][0]);
                    result.Add("null");
                    break;

                case "pop":
                    result.Add(stack.Pop().ToString());
                    break;

                case "increment":
                    stack.Increment(values[i][0], values[i][1]);
                    result.Add("null");
                    break;
            }
        }

        return result;
    }
}


/**
 * Your CustomStack object will be instantiated and called as such:
 * CustomStack obj = new CustomStack(maxSize);
 * obj.Push(x);
 * int param_2 = obj.Pop();
 * obj.Increment(k,val);
 */