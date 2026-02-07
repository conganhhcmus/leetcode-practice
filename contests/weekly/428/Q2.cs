public class Solution
{
    public double MaxAmount(string initialCurrency, IList<IList<string>> pairs1, double[] rates1, IList<IList<string>> pairs2, double[] rates2)
    {
        var graph1 = BuildGraph(pairs1, rates1);
        Queue<(string currency, double amount)> queue = [];
        queue.Enqueue((initialCurrency, 1.0));
        Dictionary<string, double> maxCurrencyVal = [];
        maxCurrencyVal[initialCurrency] = 1.0;
        while (queue.Count > 0)
        {
            var (currency, amount) = queue.Dequeue();

            foreach (var next in graph1.GetValueOrDefault(currency, []))
            {
                if (amount * next.value > maxCurrencyVal.GetValueOrDefault(next.currency, 0))
                {
                    maxCurrencyVal[next.currency] = amount * next.value;
                    queue.Enqueue((next.currency, amount * next.value));
                }
            }
        }

        var graph2 = BuildGraph(pairs2, rates2);
        queue = [];
        foreach (var pair in maxCurrencyVal)
        {
            queue.Enqueue((pair.Key, pair.Value));
        }
        while (queue.Count > 0)
        {
            var (currency, amount) = queue.Dequeue();

            foreach (var next in graph2.GetValueOrDefault(currency, []))
            {
                if (amount * next.value > maxCurrencyVal.GetValueOrDefault(next.currency, 0))
                {
                    maxCurrencyVal[next.currency] = amount * next.value;
                    queue.Enqueue((next.currency, amount * next.value));
                }
            }
        }

        return maxCurrencyVal.GetValueOrDefault(initialCurrency, 0);
    }

    private Dictionary<string, List<(string currency, double value)>> BuildGraph(IList<IList<string>> pairs, double[] rate)
    {
        Dictionary<string, List<(string currency, double value)>> graph = [];
        for (int i = 0; i < pairs.Count; i++)
        {
            if (!graph.ContainsKey(pairs[i][0]))
            {
                graph[pairs[i][0]] = [];
            }
            if (!graph.ContainsKey(pairs[i][1]))
            {
                graph[pairs[i][1]] = [];
            }
            graph[pairs[i][0]].Add((pairs[i][1], rate[i]));
            graph[pairs[i][1]].Add((pairs[i][0], 1 / rate[i]));
        }
        return graph;
    }
}