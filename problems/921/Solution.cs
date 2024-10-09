namespace Problem_921;

public class Solution
{
    public static void Execute()
    {
        var solution = new Solution();
        string s = "())";
        Console.WriteLine(solution.MinAddToMakeValid(s));
    }
    public int MinAddToMakeValid(string s)
    {
        Stack<char> stack = new();
        foreach (char c in s)
        {
            if (c != ')')
            {
                stack.Push(c);
            }
            else
            {
                if (stack.Count == 0 || stack.Peek() == ')')
                {
                    stack.Push(c);
                }
                else
                {
                    stack.Pop();
                }
            }
        }

        return stack.Count;
    }
}