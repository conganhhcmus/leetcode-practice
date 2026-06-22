public class Solution
{
    public int MaxDistance(string moves)
    {
        int ans = 0;
        ans = Math.Max(ans, Check("UL", "DR"));
        ans = Math.Max(ans, Check("UR", "DL"));
        ans = Math.Max(ans, Check("DL", "UR"));
        ans = Math.Max(ans, Check("DR", "UL"));
        return ans;

        int Check(string dir, string rem)
        {
            int x = 0, y = 0;
            int free = 0;
            foreach (char c in moves)
            {
                if (dir[0] == c) x++;
                else if (dir[1] == c) y++;
                else if (c == '_') free++;
                else if (c == rem[0])
                {
                    if (free > 0) free--;
                    else x--;
                }
                else if (c == rem[1])
                {
                    if (free > 0) free--;
                    else y--;
                }
            }

            return x + y + free;
        }
    }
}
