public class Solution
{
    public int MinimizedMaximum(int n, int[] quantities)
    {
        int min = 1;
        int max = quantities.Max();
        while (min <= max)
        {
            int mid = min + (max - min) / 2;
            if (CanDistribute(n, quantities, mid))
            {
                max = mid - 1;
            }
            else
            {
                min = mid + 1;
            }
        }
        return min;
    }

    private bool CanDistribute(int n, int[] quantities, int k)
    {
        int result = 0;
        foreach (var quantity in quantities)
        {
            result += (int)Math.Ceiling(1.0 * quantity / k);
        }

        return result <= n;
    }
}