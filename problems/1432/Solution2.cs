#if DEBUG
namespace Problems_1432_2;
#endif

public class Solution
{
    public int MaxDiff(int num)
    {
        int minNum = num, maxNum = num;
        string numStr = num.ToString();
        for (char x = '0'; x <= '9'; x++)
        {
            for (char y = '0'; y <= '9'; y++)
            {
                string valStr = numStr.Replace(x, y);
                if (valStr[0] != '0')
                {
                    int val = int.Parse(valStr);
                    minNum = Math.Min(minNum, val);
                    maxNum = Math.Max(maxNum, val);
                }
            }
        }

        return maxNum - minNum;
    }
}