public class Solution
{
    public int MinMutation(string startGene, string endGene, string[] bank)
    {
        if (bank.Length == 0) return -1;
        Queue<string> queue = [];
        HashSet<string> visited = [];

        queue.Enqueue(startGene);
        visited.Add(startGene);
        int step = 0;
        while (queue.Count > 0)
        {
            int size = queue.Count;
            while (size-- > 0)
            {
                string curr = queue.Dequeue();
                if (curr == endGene) return step;

                foreach (string next in bank)
                {
                    if (!IsMutation(curr, next) || !visited.Add(next)) continue;
                    queue.Enqueue(next);
                }
            }
            step++;
        }
        return -1;
    }

    private bool IsMutation(string geneA, string geneB)
    {
        if (geneA.Length != geneB.Length) return false;
        int diff = 0;
        for (int i = 0; i < geneA.Length; i++)
        {
            if (geneA[i] != geneB[i]) diff++;
            if (diff > 1) return false;
        }
        return diff == 1;
    }
}