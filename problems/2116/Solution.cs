#if DEBUG
namespace Problems_2116;
#endif

public class Solution
{
    public bool CanBeValid(string s, string locked)
    {
        if ((s.Length & 1) != 0) return false;
        Stack<int> opened = [];
        Stack<int> unLocked = [];
        for (int i = 0; i < s.Length; i++)
        {
            if (locked[i] == '0') unLocked.Push(i);
            else if (s[i] == '(') opened.Push(i);
            else
            {
                if (opened.Count > 0) opened.Pop();
                else if (unLocked.Count > 0) unLocked.Pop();
                else return false;
            }
        }
        while (opened.Count > 0 && unLocked.Count > 0 && opened.Peek() < unLocked.Peek())
        {
            opened.Pop();
            unLocked.Pop();
        }

        return opened.Count == 0;
    }
}