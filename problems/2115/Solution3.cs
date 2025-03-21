#if DEBUG
namespace Problems_2115_3;
#endif

public class Solution
{
    public IList<string> FindAllRecipes(string[] recipes, IList<IList<string>> ingredients, string[] supplies)
    {
        int n = recipes.Length;
        HashSet<string> set = [];
        foreach (string supply in supplies) set.Add(supply);
        int lastSize = -1;
        IList<string> ret = [];
        Queue<int> queue = [];
        for (int i = 0; i < n; i++)
        {
            queue.Enqueue(i);
        }
        while (set.Count > lastSize)
        {
            lastSize = set.Count;
            int queueSize = queue.Count;
            while (queueSize-- > 0)
            {
                int curr = queue.Dequeue();
                bool canMake = true;
                foreach (var ingredient in ingredients[curr])
                {
                    if (!set.Contains(ingredient))
                    {
                        canMake = false;
                        break;
                    }
                }

                // all ingredient are already
                if (canMake)
                {
                    set.Add(recipes[curr]);
                    ret.Add(recipes[curr]);
                }
                else
                {
                    queue.Enqueue(curr);
                }
            }
        }
        return ret;
    }
}