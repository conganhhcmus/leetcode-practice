namespace Problem_394;

public class Solution
{
    public static void Execute()
    {
        var solution = new Solution();
        string encodedString = "2[abc]3[cd]ef";
        Console.WriteLine(solution.DecodeString(encodedString));
    }
    public string DecodeString(string s)
    {
        Stack<int> repeatNum = new();
        Stack<string> result = new();
        int num = 0;
        foreach (char c in s)
        {
            if (c >= '0' && c <= '9')
            {
                num = num * 10 + (c - '0');
            }
            else if (c == ']')
            {
                string tmp = "";
                while (result.Peek() != "[")
                {
                    tmp = result.Pop() + tmp;
                }
                result.Pop(); // remove '['
                result.Push(string.Concat(Enumerable.Repeat(tmp, repeatNum.Pop())));
            }
            else
            {
                if (num > 0)
                {
                    repeatNum.Push(num);
                    num = 0;
                }
                result.Push(c.ToString());
            }
        }

        return string.Join("", result.Reverse());
    }
}