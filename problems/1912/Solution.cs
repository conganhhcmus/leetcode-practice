public class MovieRentingSystem
{
    public record SearchMovie(int Shop, int Movie);
    public record MovieEntity(int Shop, int Movie, int Price) : IComparable<MovieEntity>
    {
        public int CompareTo(MovieEntity other)
        {
            if (Price == other.Price)
            {
                if (Shop == other.Shop)
                {
                    return Movie - other.Movie;
                }

                return Shop - other.Shop;
            }

            return Price - other.Price;
        }
    }

    Dictionary<int, SortedSet<MovieEntity>> sortedMovies = [];

    Dictionary<SearchMovie, MovieEntity> allMovies = [];

    SortedSet<MovieEntity> rentedMovies = [];


    public MovieRentingSystem(int n, int[][] entries)
    {
        foreach (int[] entry in entries)
        {
            int shop = entry[0], movie = entry[1], price = entry[2];
            var movieEntity = new MovieEntity(shop, movie, price);
            var searchMovie = new SearchMovie(shop, movie);
            allMovies[searchMovie] = movieEntity;
            sortedMovies.TryAdd(movie, []);
            sortedMovies[movie].Add(movieEntity);
        }
    }

    public IList<int> Search(int movie)
    {
        IList<int> ans = [];
        if (sortedMovies.ContainsKey(movie))
        {
            for (int i = 0; i < Math.Min(5, sortedMovies[movie].Count); i++)
            {
                ans.Add(sortedMovies[movie].ElementAt(i).Shop);
            }
        }
        return ans;
    }

    public void Rent(int shop, int movie)
    {
        var searchMovie = new SearchMovie(shop, movie);
        if (allMovies.ContainsKey(searchMovie))
        {
            var movieEntity = allMovies[searchMovie];
            rentedMovies.Add(movieEntity);
            sortedMovies[movie].Remove(movieEntity);
        }
    }

    public void Drop(int shop, int movie)
    {
        var searchMovie = new SearchMovie(shop, movie);
        if (allMovies.ContainsKey(searchMovie))
        {
            var movieEntity = allMovies[searchMovie];
            rentedMovies.Remove(movieEntity);
            sortedMovies[movie].Add(movieEntity);
        }
    }

    public IList<IList<int>> Report()
    {
        IList<IList<int>> ans = [];
        for (int i = 0; i < Math.Min(5, rentedMovies.Count); i++)
        {
            var rentedMovie = rentedMovies.ElementAt(i);
            ans.Add([rentedMovie.Shop, rentedMovie.Movie]);
        }

        return ans;
    }
}

/**
 * Your MovieRentingSystem object will be instantiated and called as such:
 * MovieRentingSystem obj = new MovieRentingSystem(n, entries);
 * IList<int> param_1 = obj.Search(movie);
 * obj.Rent(shop,movie);
 * obj.Drop(shop,movie);
 * IList<IList<int>> param_4 = obj.Report();
 */


#if DEBUG
public class Solution
{
    public List<dynamic> Execute(string[] actions, object[] values)
    {
        List<dynamic> result = [];
        MovieRentingSystem movieRentingSystem = null;
        for (int i = 0; i < actions.Length; i++)
        {
            switch (actions[i])
            {
                case "MovieRentingSystem":
                    object[] constructArgs = CastType<object[]>(values[i]);
                    int n = CastType<int>(constructArgs[0]);
                    int[][] entries = CastType<int[][]>(constructArgs[1]);
                    movieRentingSystem = new MovieRentingSystem(n, entries);
                    result.Add(null);
                    break;
                case "rent":
                    int[] rentArgs = CastType<int[]>(values[i]);
                    movieRentingSystem.Rent(rentArgs[0], rentArgs[1]);
                    result.Add(null);
                    break;
                case "report":
                    result.Add(movieRentingSystem.Report());
                    break;
                case "drop":
                    int[] dropArgs = CastType<int[]>(values[i]);
                    movieRentingSystem.Drop(dropArgs[0], dropArgs[1]);
                    result.Add(null);
                    break;
                case "search":
                    result.Add(movieRentingSystem.Search(CastType<int[]>(values[i])[0]));
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
