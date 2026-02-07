public class Solution
{
    public IList<string> FindAllRecipes(string[] recipes, IList<IList<string>> ingredients, string[] supplies)
    {
        int n = recipes.Length;
        HashSet<string> set = [];
        foreach (string supply in supplies) set.Add(supply);
        Dictionary<string, int> map = [];
        for (int i = 0; i < n; i++) map[recipes[i]] = i;
        Dictionary<string, List<string>> graph = [];
        int[] inDegree = new int[n];
        for (int i = 0; i < n; i++)
        {
            foreach (string ingredient in ingredients[i])
            {
                if (!set.Contains(ingredient))
                {
                    graph.TryAdd(ingredient, []);
                    graph[ingredient].Add(recipes[i]);
                    inDegree[i]++;
                }
            }
        }

        Queue<int> queue = [];
        for (int i = 0; i < n; i++)
        {
            if (inDegree[i] == 0)
            {
                queue.Enqueue(i);
            }
        }

        IList<string> ret = [];
        while (queue.Count > 0)
        {
            int curr = queue.Dequeue();
            ret.Add(recipes[curr]);
            foreach (string neighbor in graph.GetValueOrDefault(recipes[curr], []))
            {
                if (--inDegree[map[neighbor]] == 0)
                {
                    queue.Enqueue(map[neighbor]);
                }
            }
        }
        return ret;
    }
}