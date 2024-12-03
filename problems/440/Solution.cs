namespace Problem_440;

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

    private int CountSteps(int n, long prefix1, long prefix2)
    {
        int steps = 0;
        while (prefix1 <= n)
        {
            steps += int.Min((int)(n + 1 - prefix1), (int)(prefix2 - prefix1));
            prefix1 *= 10;
            prefix2 *= 10;
        }
        return steps;
    }

    public int FindKthNumber2(int n, int k)
    {
        long currentNum = 1;
        for (int i = 1; i < k; i++)
        {
            if (currentNum * 10 <= n) currentNum *= 10;
            else
            {
                while (currentNum % 10 == 9 || currentNum >= n)
                {
                    currentNum /= 10;
                }
                currentNum++;
            }
        }

        return (int)currentNum;
    }
}