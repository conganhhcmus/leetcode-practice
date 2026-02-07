public class Solution
{
    public int[] ResultsArray(int[][] queries, int k)
    {
        var result = new int[queries.Length];
        Array.Fill(result, -1);
        var pq = new PriorityQueue<int, int>();

        for (int i = 0; i < queries.Length; i++)
        {
            var num = Math.Abs(queries[i][0]) + Math.Abs(queries[i][1]);

            pq.Enqueue(num, -num);

            if (pq.Count > k)
            {
                pq.Dequeue();
            }
            if (pq.Count == k)
            {
                result[i] = pq.Peek();
            }
        }

        return result;
    }
}