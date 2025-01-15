#if DEBUG
namespace Problems_150;
#endif

public class Solution
{
    public int EvalRPN(string[] tokens)
    {
        Stack<int> stack = [];
        HashSet<string> operators = ["+", "-", "*", "/"];
        foreach (string token in tokens)
        {
            if (!operators.Contains(token))
            {
                stack.Push(ParseIntFast(token));
                continue;
            }

            int a = stack.Pop();
            int b = stack.Pop();
            switch (token)
            {
                case "+":
                    stack.Push(b + a);

                    break;
                case "-":
                    stack.Push(b - a);

                    break;
                case "*":
                    stack.Push(b * a);

                    break;
                case "/":
                    stack.Push(b / a);
                    break;
            }
        }

        return stack.Pop();
    }

    private static int ParseIntFast(string input)
    {
        int sign = input[0] == '-' ? -1 : 1;

        int result = 0;

        for (int i = sign == -1 ? 1 : 0; i < input.Length; i++)
        {
            result *= 10;
            result += input[i] - '0';
        }

        return sign == 1 ? result : -result;
    }
}