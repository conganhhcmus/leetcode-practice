public class Solution
{
    public int MaximizeSquareHoleArea(int n, int m, int[] hBars, int[] vBars)
    {
        Array.Sort(hBars);
        Array.Sort(vBars);
        int count1 = 1;
        int max1 = 1;
        for (int i = 1; i < hBars.Length; i++)
        {
            if (hBars[i] == hBars[i - 1] + 1) count1++;
            else count1 = 1;
            max1 = Math.Max(max1, count1);
        }
        int count2 = 1;
        int max2 = 1;
        for (int i = 1; i < vBars.Length; i++)
        {
            if (vBars[i] == vBars[i - 1] + 1) count2++;
            else count2 = 1;
            max2 = Math.Max(max2, count2);
        }

        return (Math.Min(max1, max2) + 1) * (Math.Min(max1, max2) + 1);
    }
}