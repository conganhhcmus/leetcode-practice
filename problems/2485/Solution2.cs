public class Solution
{
    public int PivotInteger(int n)
    {
        int sum = n * (n + 1) / 2;
        int pivot = (int)Math.Sqrt(sum);
        // If pivot * pivot is equal to sum (pivot found) return pivot, else return -1
        return pivot * pivot == sum ? pivot : -1;
    }
}