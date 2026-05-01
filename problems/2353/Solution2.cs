public class FoodRatings
{
    Dictionary<string, string> foodToCuisineMap = [];
    Dictionary<string, PriorityQueue<(string food, int rating), (string food, int rating)>> cuisineToFoodRatings = [];
    Dictionary<string, int> foodToRating = [];
    public FoodRatings(string[] foods, string[] cuisines, int[] ratings)
    {
        for (int i = 0; i < foods.Length; i++)
        {
            foodToRating[foods[i]] = ratings[i];
            foodToCuisineMap[foods[i]] = cuisines[i];
            if (!cuisineToFoodRatings.TryGetValue(cuisines[i], out var ratingQueue))
            {
                ratingQueue = new(Comparer<(string food, int rating)>.Create((a, b) =>
                {
                    if (a.rating != b.rating)
                    {
                        return b.rating.CompareTo(a.rating);
                    }

                    return a.CompareTo(b);
                }));

                cuisineToFoodRatings[cuisines[i]] = ratingQueue;
            }

            ratingQueue.Enqueue((foods[i], ratings[i]), (foods[i], ratings[i]));
        }
    }

    public void ChangeRating(string food, int newRating)
    {
        foodToRating[food] = newRating;
        string cuisine = foodToCuisineMap[food];
        cuisineToFoodRatings[cuisine].Enqueue((food, newRating), (food, newRating));
    }

    public string HighestRated(string cuisine)
    {
        while (true)
        {
            (string food, int rating) = cuisineToFoodRatings[cuisine].Peek();
            if (rating == foodToRating[food])
            {
                return food;
            }

            cuisineToFoodRatings[cuisine].Dequeue();
        }
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
