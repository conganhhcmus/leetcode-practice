#if DEBUG
namespace Problems_2353_2;
#endif

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