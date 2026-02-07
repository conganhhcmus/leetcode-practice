public class Solution
{
    public int MinSwaps(string s)
    {
        int ans = 0;
        Stack<char> stack = new();

        foreach (char c in s)
        {
            if (c == '[')
            {
                stack.Push(c);
            }
            else
            {
                if (stack.Count == 0)
                {
                    ans++;
                    stack.Push('[');
                }
                else if (stack.Peek() == ']')
                {
                    ans++;
                    stack.Pop();
                    stack.Push('[');
                }
                else
                {
                    stack.Pop();
                }
            }
        }
        return ans;
    }
}