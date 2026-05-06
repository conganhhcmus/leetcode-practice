public class Solution
{
    public int KthFactor(int n, int k)
    {
        List<int> f1 = [], f2 = [];
        for (int i = 1; i * i <= n; i++)
        {
            if (n % i == 0)
            {
                f1.Add(i);
                if (i * i != n) f2.Add(n / i);
            }
        }
        if (k <= f1.Count) return f1[k - 1];
        k -= f1.Count;
        if (k <= f2.Count) return f2[f2.Count - k];
        return -1;
    }
}
