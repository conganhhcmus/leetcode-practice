public class Solution
{
    public int MaxDiff(int num)
    {
        string numStr = num.ToString();
        int n = numStr.Length;
        int ret = 0;
        char maxMap = '9';
        int maxVal = 9;
        for (int i = 0; i < n; i++)
        {
            if (maxMap == '9') maxMap = numStr[i];
        }
        char minMap = numStr[0];
        int minVal = 0;
        if (numStr[0] != '1')
        {
            minMap = numStr[0];
            minVal = 1;
        }
        else
        {
            for (int i = 1; i < n; i++)
            {
                if (minMap == '1' || minMap == '0') minMap = numStr[i];
            }
            if (minMap == '1' && minVal == 0) minVal = 1;
        }
        for (int i = 0; i < n; i++)
        {
            int max = numStr[i] - '0', min = numStr[i] - '0';
            if (numStr[i] == maxMap) max = maxVal;
            if (numStr[i] == minMap) min = minVal;
            ret = ret * 10 + (max - min);
        }
        return ret;
    }
}