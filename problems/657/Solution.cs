public class Solution
{
    public bool JudgeCircle(string moves)
    {
        int x = 0, y = 0;
        foreach (char c in moves)
        {
            if (c == 'L') x++;
            else if (c == 'R') x--;
            else if (c == 'U') y++;
            else y--;
        }
        return x == 0 && y == 0;
    }
}