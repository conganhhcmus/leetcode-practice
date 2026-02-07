public class Solution
{
    public string SmallestNumber(string pattern)
    {
        StringBuilder sb = new();
        Stack<int> stack = [];
        for (int i = 0; i <= pattern.Length; i++)
        {
            stack.Push(i + 1);
            if (i == pattern.Length || pattern[i] == 'I')
            {
                while (stack.Count > 0)
                {
                    sb.Append(stack.Pop());
                }
            }
        }

        return sb.ToString();
    }
}