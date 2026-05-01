public class FoodRatings
{
    Dictionary<string, int> mapFoodToRating = [];
    Dictionary<string, string> mapFoodToCuisine = [];

    Dictionary<string, SortedSet<Pair>> map = [];

    public record Pair(int Value, string Name);

    public class PairComparer : IComparer<Pair>
    {
        public int Compare(Pair x, Pair y)
        {
            if (x.Value == y.Value) return x.Name.CompareTo(y.Name);
            return y.Value.CompareTo(x.Value);
        }
    }
    public FoodRatings(string[] foods, string[] cuisines, int[] ratings)
    {
        int n = foods.Length;
        for (int i = 0; i < n; i++)
        {
            string food = foods[i];
            string cuisine = cuisines[i];
            int rating = ratings[i];
            mapFoodToCuisine[food] = cuisine;
            mapFoodToRating[food] = rating;
            map.TryAdd(cuisine, new(new PairComparer()));
            map[cuisine].Add(new(rating, food));
        }
    }

    public void ChangeRating(string food, int newRating)
    {
        string cuisine = mapFoodToCuisine[food];
        int oldRating = mapFoodToRating[food];
        mapFoodToRating[food] = newRating;
        map[cuisine].Remove(new(oldRating, food));
        map[cuisine].Add(new(newRating, food));
    }

    public string HighestRated(string cuisine)
    {
        return map[cuisine].First().Name;
    }
}

/**
 * Your FoodRatings object will be instantiated and called as such:
 * FoodRatings obj = new FoodRatings(foods, cuisines, ratings);
 * obj.ChangeRating(food,newRating);
 * string param_2 = obj.HighestRated(cuisine);
 */


#if DEBUG
public class Solution
{
    public List<dynamic> Execute(string[] actions, object[] values)
    {
        List<dynamic> result = [];
        FoodRatings foodRatings = null;
        for (int i = 0; i < actions.Length; i++)
        {
            switch (actions[i])
            {
                case "FoodRatings":
                    object[] constructArgs = CastType<object[]>(values[i]);
                    foodRatings = new FoodRatings(CastType<string[]>(constructArgs[0]), CastType<string[]>(constructArgs[1]), CastType<int[]>(constructArgs[2]));
                    result.Add(null);
                    break;
                case "highestRated":
                    result.Add(foodRatings.HighestRated(CastType<string[]>(values[i])[0]));
                    break;
                case "changeRating":
                    object[] changeArgs = CastType<object[]>(values[i]);
                    foodRatings.ChangeRating(CastType<string>(changeArgs[0]), CastType<int>(changeArgs[1]));
                    result.Add(null);
                    break;
                default:
                    break;
            }
        }
        return result;
    }

    private static T CastType<T>(object value) => ((JsonElement)value).Deserialize<T>(Program.JsonOptions);
}
#endif
