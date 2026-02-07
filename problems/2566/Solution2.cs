public class Solution
{
    public int MinMaxDifference(int num)
    {
        char[] arr = num.ToString().ToCharArray();
        int n = arr.Length;
        char maxMap = '9', minMap = '0';
        for (int i = 0; i < n; i++)
        {
            if (maxMap == '9') maxMap = arr[i];
            if (minMap == '0') minMap = arr[i];
        }
        int ret = 0;
        for (int i = 0; i < n; i++)
        {
            int max = arr[i] - '0';
            int min = arr[i] - '0';
            if (arr[i] == maxMap) max = 9;
            if (arr[i] == minMap) min = 0;
            ret = ret * 10 + (max - min);
        }
        return ret;
    }
}