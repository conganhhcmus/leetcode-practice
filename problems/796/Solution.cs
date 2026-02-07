public class Solution
{
    public bool RotateString(string s, string goal)
    {
        if (s.Length != goal.Length) return false;
        for (int start = 0; start < s.Length; start++)
        {
            while (start < s.Length && s[start] != goal[0]) start++;
            int index = 0;
            bool found = true;
            for (int i = start; i < s.Length; i++)
            {
                if (s[i] != goal[index])
                {
                    found = false;
                    break;
                }
                index++;
            }
            if (!found) continue;
            for (int i = 0; i < start; i++)
            {
                if (s[i] != goal[index])
                {
                    found = false;
                    break;
                }
                index++;
            }
            if (found) return true;
        }

        return false;
    }
}