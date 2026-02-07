public class Solution
{
    public bool ParseBoolExpr(string expression)
    {
        Stack<char> stack = new();

        foreach (char c in expression)
        {
            if (c == ',') continue;

            if (c != ')')
            {
                stack.Push(c);
            }
            else
            {
                List<char> vals = [];
                while (stack.Peek() != '(')
                {
                    vals.Add(stack.Pop());
                }
                stack.Pop();
                char op = stack.Pop();
                if (op == '!')
                {
                    stack.Push(vals[0] == 't' ? 'f' : 't');
                }
                else if (op == '&')
                {
                    stack.Push(vals.All(c => c == 't') ? 't' : 'f');
                }
                else
                {
                    stack.Push(vals.Any(c => c == 't') ? 't' : 'f');
                }
            }
        }

        return stack.Pop() == 't';
    }
}