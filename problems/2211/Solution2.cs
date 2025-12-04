#if DEBUG
namespace Problems_2211_2;
#endif

public class Solution
{
    public int CountCollisions(string directions)
    {
        int ans = 0;
        int flag = -1;
        foreach (char c in directions)
        {
            if (c == 'L')
            {
                if (flag >= 0)
                {
                    ans += flag + 1;
                    flag = 0;
                }
            }
            else if (c == 'S')
            {
                if (flag > 0)
                {
                    ans += flag;
                }
                flag = 0;
            }
            else
            {
                if (flag >= 0)
                {
                    flag++;
                }
                else
                {
                    flag = 1;
                }
            }
        }
        return ans;
    }
}