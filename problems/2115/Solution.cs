public class Solution
{
    public IList<string> FindAllRecipes(string[] recipes, IList<IList<string>> ingredients, string[] supplies)
    {
        HashSet<string> suppliesSet = supplies.ToHashSet();
        Dictionary<string, List<string>> graph = [];
        int n = recipes.Length;
        for (int i = 0; i < n; i++)
        {
            string recipe = recipes[i];
            graph.TryAdd(recipe, []);
            graph[recipe].AddRange(ingredients[i]);
        }
        IList<string> ret = [];
        Dictionary<string, int> color = [];
        for (int i = 0; i < n; i++)
        {
            if (CanMake(graph, recipes[i], color, suppliesSet)) ret.Add(recipes[i]);
        }
        return ret;
    }

    bool CanMake(Dictionary<string, List<string>> graph, string recipe, Dictionary<string, int> color, HashSet<string> suppliesSet)
    {
        int colored = color.GetValueOrDefault(recipe, 0);
        if (colored > 0) return colored == 2;
        color[recipe] = 1; // visited
        bool can = true;
        List<string> ingredients = graph.GetValueOrDefault(recipe, []);

        if (ingredients.Count == 0)
        {
            can &= suppliesSet.Contains(recipe);
        }

        foreach (string ingredient in ingredients)
        {
            can &= CanMake(graph, ingredient, color, suppliesSet);
        }

        color[recipe] = can ? 2 : 1; // done
        return can;
    }
}