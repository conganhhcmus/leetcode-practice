#if DEBUG
namespace Problems_2375_6;
#endif

public class Solution
{
    public string SmallestNumber(string pattern)
    {
        int n = pattern.Length;
        int maxSoFar = 0, currMax = 0, temp;
        int[] arrD = new int[n + 1];
        for (int i = n; i >= 0; i--)
        {
            if (i < n && pattern[i] == 'D') arrD[i] = arrD[i + 1] + 1;
        }

        StringBuilder sb = new();
        for (int i = 0; i <= n; i++)
        {
            if (i < n && pattern[i] == 'I')
            {
                maxSoFar++;
                sb.Append(maxSoFar);
                maxSoFar = Math.Max(maxSoFar, currMax);
                currMax = 0;
            }
            else
            {
                temp = 1 + maxSoFar + arrD[i];
                sb.Append(temp);
                currMax = Math.Max(currMax, temp);
            }
        }
        return sb.ToString();
    }
}