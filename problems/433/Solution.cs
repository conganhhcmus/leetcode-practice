public class Solution
{
    public int MinMutation(string startGene, string endGene, string[] bank)
    {
        var graph = BuildGraph(startGene, bank);
        Queue<int> queue = [];
        HashSet<int> visited = [];
        int startHash = HashCode(startGene);
        int endHash = HashCode(endGene);

        queue.Enqueue(startHash);
        visited.Add(startHash);
        int step = 0;
        while (queue.Count > 0)
        {
            int size = queue.Count;
            while (size-- > 0)
            {
                int hash = queue.Dequeue();
                if (hash == endHash) return step;

                foreach (var next in graph.GetValueOrDefault(hash, []))
                {
                    if (visited.Add(next)) queue.Enqueue(next);
                }
            }
            step++;
        }
        return -1;
    }

    private Dictionary<int, List<int>> BuildGraph(string startGene, string[] bank)
    {
        Dictionary<int, List<int>> graph = [];
        foreach (string gene in bank)
        {
            int hashU = HashCode(startGene);
            int hashV = HashCode(gene);
            if (IsMutation(hashU, hashV))
            {
                graph.TryAdd(hashU, []);
                graph.TryAdd(hashV, []);
                graph[hashU].Add(hashV);
                graph[hashV].Add(hashU);
            }
        }

        for (int i = 0; i < bank.Length; i++)
        {
            for (int j = i + 1; j < bank.Length; j++)
            {
                int hashU = HashCode(bank[i]);
                int hashV = HashCode(bank[j]);
                if (IsMutation(hashU, hashV))
                {
                    graph.TryAdd(hashU, []);
                    graph.TryAdd(hashV, []);
                    graph[hashU].Add(hashV);
                    graph[hashV].Add(hashU);
                }
            }
        }

        return graph;
    }

    private int HashCode(string gene)
    {
        Dictionary<char, int> map = new(){
            {'A',0},
            {'C',1},
            {'G',2},
            {'T',3}
        };
        int hash = 0;
        foreach (var c in gene)
        {
            hash = (hash * 4) + map[c];
        }
        return hash;
    }

    private bool IsMutation(int hashA, int hashB)
    {
        int count = 0;
        while (hashA > 0 || hashB > 0)
        {
            int diff = hashA % 4 - hashB % 4;
            if (diff != 0) count++;
            if (count > 1) return false;
            hashA /= 4;
            hashB /= 4;
        }

        return count == 1;
    }
}