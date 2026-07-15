public class Solution
{
    public int GcdOfOddEvenSums(int n)
    {
        int maxOdd = 2 * n - 1;
        int maxEven = 2 * n;
        int a = n * (maxOdd + 1) / 2;
        int b = n * (maxEven + 2) / 2;

        while (b != 0)
        {
            (a, b) = (b, a % b);
        }
        return a;
    }
}
