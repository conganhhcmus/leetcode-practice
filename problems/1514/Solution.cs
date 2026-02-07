public class Solution
{
    public double MaxProbability(int n, int[][] edges, double[] succProb, int start_node, int end_node)
    {
        var probValues = new double[n];
        Array.Fill(probValues, 0.0);
        probValues[start_node] = 1.0;

        bool isStopped;  // flag to check if the algorithm has stopped iterating.

        do
        {
            isStopped = true;
            for (int i = 0; i < edges.Length; i++)
            {
                int u = edges[i][0];
                int v = edges[i][1];
                double prob = succProb[i];

                if (probValues[u] * prob > probValues[v])
                {
                    probValues[v] = probValues[u] * prob;
                    isStopped = false;
                }
                if (probValues[v] * prob > probValues[u])
                {
                    probValues[u] = probValues[v] * prob;
                    isStopped = false;
                }
            }
            Console.WriteLine($"[{string.Join(",", probValues)}]");
        } while (!isStopped);

        return probValues[end_node];
    }
}