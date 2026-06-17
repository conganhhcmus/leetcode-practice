public class Solution
{
    public long MaxPoints(int[] technique1, int[] technique2, int k)
    {
        int n = technique1.Length;
        long sum = 0L;
        foreach (int x in technique2) sum += x;
        long[] diff = new long[n];
        for (int i = 0; i < n; i++)
        {
            diff[i] = (long)technique1[i] - technique2[i];
        }
        Array.Sort(diff, (a, b) => b.CompareTo(a));
        // pick at lest k with max sum
        for (int i = 0; i < n; i++)
        {
            if (i >= k && diff[i] < 0) break;
            sum += diff[i];
        }
        return sum;
    }
}
