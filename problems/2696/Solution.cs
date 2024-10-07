namespace Problem_2696;

public class Solution
{
    public static void Execute()
    {
        string s = "ABFCACDB";
        var solution = new Solution();
        Console.WriteLine(solution.MinLength(s));
        Console.WriteLine(solution.MinLength_Stack(s));
    }
    public int MinLength(string s)
    {
        while (s.Contains("AB", StringComparison.CurrentCulture) || s.Contains("CD", StringComparison.CurrentCulture))
        {
            s = s.Replace("AB", string.Empty).Replace("CD", string.Empty);
        }
        return s.Length;
    }

    public int MinLength_Stack(string s)
    {
        Stack<char> stack = new();
        for (int i = 0; i < s.Length; i++)
        {
            if (stack.Count == 0)
            {
                stack.Push(s[i]);
                continue;
            }

            if ((s[i] == 'B' && stack.Peek() == 'A') || (s[i] == 'D' && stack.Peek() == 'C'))
            {
                stack.Pop();
            }
            else
            {
                stack.Push(s[i]);
            }
        }

        return stack.Count;
    }
}