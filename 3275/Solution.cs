namespace Contest_413_Q2;
public class Solution
{
    public static void Execute()
    {
        var queries = new int[5][];
        queries[0] = [-9, -5];
        queries[1] = [0, 4];
        queries[2] = [-10, 5];
        queries[3] = [-6, 9];
        queries[4] = [-4, 8];
        var k = 5;

        var solution = new Solution();
        var res = solution.ResultsArray(queries, k);
        Console.WriteLine($"[{string.Join(",", res)}]");
    }
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