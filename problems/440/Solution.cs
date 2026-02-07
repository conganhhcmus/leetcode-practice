public class Solution
{
    public int FindKthNumber(int n, int k)
    {
        int curr = 1;
        k--;

        while (k > 0)
        {
            int step = CountSteps(n, curr, curr + 1);
            if (step <= k)
            {
                curr++;
                k -= step;
            }
            else
            {
                curr *= 10;
                k--;
            }
        }

        return curr;
    }

    private int CountSteps(int n, long d1, long d2)
    {
        int steps = 0;
        while (d1 <= n)
        {
            steps += int.Min((int)(n + 1 - d1), (int)(d2 - d1));
            d1 *= 10;
            d2 *= 10;
        }
        return steps;
    }
}