public class MyQueue
{
    Stack<int> inSt;
    Stack<int> outSt;
    public MyQueue()
    {
        inSt = [];
        outSt = [];
    }

    public void Push(int x)
    {
        inSt.Push(x);
    }

    public int Pop()
    {
        if (outSt.Count == 0)
        {
            Transfer();
        }
        return outSt.Pop();
    }

    public int Peek()
    {
        if (outSt.Count == 0)
        {
            Transfer();
        }
        return outSt.Peek();
    }

    public bool Empty()
    {
        return inSt.Count + outSt.Count == 0;
    }

    void Transfer()
    {
        while (inSt.Count > 0)
        {
            outSt.Push(inSt.Pop());
        }
    }
}

/**
 * Your MyQueue object will be instantiated and called as such:
 * MyQueue obj = new MyQueue();
 * obj.Push(x);
 * int param_2 = obj.Pop();
 * int param_3 = obj.Peek();
 * bool param_4 = obj.Empty();
 */

public class Solution
{
    public List<dynamic> Execute(string[] actions, int[][] values)
    {
        List<dynamic> result = [];
        MyQueue myQueue = null;
        for (int i = 0; i < actions.Length; i++)
        {
            switch (actions[i])
            {
                case "MyQueue":
                    myQueue = new MyQueue();
                    result.Add(null);
                    break;
                case "push":
                    myQueue.Push(values[i][0]);
                    result.Add(null);
                    break;
                case "empty":
                    result.Add(myQueue.Empty());
                    break;
                case "peek":
                    result.Add(myQueue.Peek());
                    break;
                case "pop":
                    result.Add(myQueue.Pop());
                    break;
                default:
                    break;
            }
        }
        return result;
    }
}