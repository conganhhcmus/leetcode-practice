namespace Library;

public class SparseTable
{
    const int MAX = 10_000;
    const int MAX_BITS = 22;
    readonly int[,] fn = new int[MAX, MAX_BITS];

    int Log2(int n)
    {
        int ans = 0;
        while ((n >>= 1) != 0) ans++;
        return ans;
    }

    // O(n * log n)
    void Build(int[] nums)
    {
        int n = nums.Length;
        for (int i = 1; i <= n; i++) fn[i, 0] = nums[i - 1];
        for (int j = 1; j <= Log2(n); j++)
        {
            for (int i = 1; i + (1 << j) - 1 <= n; i++)
            {
                fn[i, j] = Math.Max(fn[i, j - 1], fn[i + (1 << (j - 1)), j - 1]); // save maximum value
                //table[i, j] = Math.Min(table[i, j - 1], table[i + (1 << (j - 1)), j - 1]); // save minimum value
            }
        }
    }

    // O(1)
    int Query(int l, int r)
    {
        int k = Log2(r - l + 1);
        return Math.Max(fn[l, k], fn[r - (1 << k) + 1, k]); // get max value
        //return Math.Min(table[l, k], table[r - (1 << k) + 1, k]); // get min value
    }
}