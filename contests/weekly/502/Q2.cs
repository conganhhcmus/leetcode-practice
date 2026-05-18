public class Solution
{
    public int CountKthRoots(int l, int r, int k)
    {
        return Count(r, k) - Count(l - 1, k);
    }

    int Count(int n, int k)
    {
        if (n < 0) return 0;
        if (n == 0) return 1;
        int x = (int)Math.Pow(n, 1.0 / k);
        while (Math.Pow(x, k) <= n) x++;
        while (Math.Pow(x, k) > n) x--;
        return x + 1;
    }
}
