namespace Problem_2390;

public class Solution
{
    public string RemoveStars(string s)
    {
        Stack<char> stack = new();

        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] == '*')
            {
                stack.Pop();
            }
            else
            {
                stack.Push(s[i]);
            }
        }

        return string.Join("", stack.Reverse());
    }
}