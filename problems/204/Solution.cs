public class Solution
{
    public int CountPrimes(int n)
    {
        if (n < 2) return 0;
        bool[] arr = new bool[n];
        int total = n - 2;
        for (int i = 2; i < n; i++)
        {
            if (arr[i]) continue;
            int j = 2 * i;
            while (j < n)
            {
                if (!arr[j])
                {
                    total--;
                    arr[j] = true;
                }
                j += i;
            }
        }

        return total;
    }
}
