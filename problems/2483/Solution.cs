#if DEBUG
namespace Problems_2483;
#endif

public class Solution
{
    public int BestClosingTime(string customers)
    {
        int n = customers.Length;
        int totY = 0, totN = 0;
        foreach (char c in customers)
        {
            if (c == 'Y') totY++;
            else totN++;
        }
        int ans = n, minPenalty = int.MaxValue;
        int countN = 0, countY = 0;
        for (int i = 0; i <= n; i++)
        {
            int penalty = countN + totY - countY;
            if (penalty < minPenalty)
            {
                minPenalty = penalty;
                ans = i;
            }
            if (i == n) break;
            if (customers[i] == 'Y') countY++;
            else countN++;
        }

        return ans;
    }
}