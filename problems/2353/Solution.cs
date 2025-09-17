#if DEBUG
namespace Problems_2353;
#endif

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


public class Solution
{
    public List<dynamic> Execute(string[] actions, dynamic values)
    {
        List<dynamic> result = [];
        object[] objectList = JsonConvert.DeserializeObject<object[]>(values);
        FoodRatings foodRatings = null;
        for (int i = 0; i < actions.Length; i++)
        {
            switch (actions[i])
            {
                case "FoodRatings":
                    dynamic[][] inputs = CastType<dynamic[]>(objectList[i]);
                    foodRatings = new FoodRatings(CastType<string>(inputs[0]), CastType<string>(inputs[1]), CastType<int>(inputs[2]));
                    result.Add(null);
                    break;
                case "highestRated":
                    result.Add(foodRatings.HighestRated(CastType<string>(objectList[i])[0]));
                    break;
                case "changeRating":
                    dynamic[] updates = CastType<dynamic>(objectList[i]);
                    foodRatings.ChangeRating((string)updates[0], (int)updates[1]);
                    result.Add(null);
                    break;
                default:
                    break;
            }
        }
        return result;
    }

    private T[] CastType<T>(object value)
    {
        return JsonConvert.DeserializeObject<T[]>(JsonConvert.SerializeObject(value));
    }
}