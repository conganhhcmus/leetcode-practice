public class Solution
{
    public double MaxAverageRatio(int[][] classes, int extraStudents)
    {
        int n = classes.Length;
        PriorityQueue<(int pass, int total), double> pq = new(Comparer<double>.Create((a, b) =>
        {
            if (b == a) return 0;
            if (b > a) return 1;
            return -1;
        }));
        for (int i = 0; i < n; ++i)
        {
            double diff = ((classes[i][0] + 1) * 1.0 / (classes[i][1] + 1)) - (classes[i][0] * 1.0 / classes[i][1]);
            pq.Enqueue((classes[i][0], classes[i][1]), diff);
        }

        while (extraStudents-- > 0)
        {
            var (pass, total) = pq.Dequeue();
            total++;
            pass++;
            double diff = ((pass + 1) * 1.0 / (total + 1)) - (pass * 1.0 / total);
            pq.Enqueue((pass, total), diff);
        }

        double ans = 0;
        while (pq.Count > 0)
        {
            var (pass, total) = pq.Dequeue();
            ans += pass * 1.0 / total;
        }

        return ans / n;
    }
}