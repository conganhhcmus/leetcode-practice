public class Solution
{
    public int SumOfMultiples(int n)
    {
        int ans = 0;
        ans += SumOfDivide(n, 3); // include 15,21,105
        ans += SumOfDivide(n, 5); // include 15,35,105
        ans += SumOfDivide(n, 7); // include 21,35,105
        ans -= SumOfDivide(n, 15); // include 105
        ans -= SumOfDivide(n, 21); // include 105
        ans -= SumOfDivide(n, 35); // include 105
        ans += SumOfDivide(n, 105);

        return ans;
    }

    private int SumOfDivide(int n, int k)
    {
        int count = n / k;
        return k * count * (count + 1) / 2;
    }
}