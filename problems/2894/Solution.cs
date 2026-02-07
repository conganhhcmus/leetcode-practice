public class Solution
{
    public int DifferenceOfSums(int n, int m)
    {
        int sum = 0;
        for (int i = 1; i <= n; i++)
        {
            if (i % m != 0) sum += i;
        }
        for (int i = 1; i <= n; i++)
        {
            if (i % m == 0) sum -= i;
        }
        return sum;
    }
}