public class Solution
{
    public bool SumGame(string num)
    {
        int n = num.Length;
        int cntL = 0, cntR = 0;
        int sumL = 0, sumR = 0;
        for (int i = 0; i < n / 2; i++)
        {
            if (num[i] == '?') cntL++;
            else sumL += num[i] - '0';
        }

        for (int i = n / 2; i < n; i++)
        {
            if (num[i] == '?') cntR++;
            else sumR += num[i] - '0';
        }

        int diffSum = sumL - sumR;
        int diffCnt = cntL - cntR;
        return (diffSum + 4.5 * diffCnt) != 0;
    }
}
