#if DEBUG
namespace Problems_155;
#endif

public class MinStack
{
    public class Node
    {
        public Node next;
        public int val;
        public int min;
        public Node(int val, int min, Node next)
        {
            this.val = val;
            this.min = min;
            this.next = next;
        }
    }
    Node head = null;
    public MinStack()
    {
        head = new Node(0, int.MaxValue, null);
    }

    public void Push(int val)
    {
        head = new Node(val, int.Min(val, head.min), head);
    }

    public void Pop()
    {
        Node tmp = head;
        head = head.next;
        tmp.next = null;
    }

    public int Top()
    {
        return head.val;
    }

    public int GetMin()
    {
        return head.min;
    }
}

/**
 * Your MinStack object will be instantiated and called as such:
 * MinStack obj = new MinStack();
 * obj.Push(val);
 * obj.Pop();
 * int param_3 = obj.Top();
 * int param_4 = obj.GetMin();
 */

public class Solution
{
    public List<int?> Execute(string[] actions, int[][] values)
    {
        List<int?> result = [];
        MinStack st = new();
        for (int i = 0; i < actions.Length; i++)
        {
            switch (actions[i])
            {
                case "MinStack":
                    st = new MinStack();
                    result.Add(null);
                    break;
                case "push":
                    st.Push(values[i][0]);
                    result.Add(null);
                    break;
                case "pop":
                    st.Pop();
                    result.Add(null);
                    break;
                case "top":
                    result.Add(st.Top());
                    break;
                case "getMin":
                    result.Add(st.GetMin());
                    break;
                default:
                    break;
            }
        }
        return result;
    }
}