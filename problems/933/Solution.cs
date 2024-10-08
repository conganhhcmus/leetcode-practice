namespace Problem_933;

public class RecentCounter
{
    private readonly Queue<int> _requests;
    public RecentCounter()
    {
        _requests = new Queue<int>();
    }

    public int Ping(int t)
    {
        _requests.Enqueue(t);

        while (_requests.Count > 0 && _requests.Peek() < t - 3000)
        {
            _requests.Dequeue();
        }

        return _requests.Count;
    }
}
public class Solution
{
    public static void Execute()
    {
        string[] actions = ["RecentCounter", "ping", "ping", "ping", "ping"];
        int[][] values = [[], [1], [100], [3001], [3002]];

        RecentCounter counter = new();
        List<int> ans = [];
        for (int i = 0; i < actions.Length; i++)
        {
            if (actions[i] == "ping")
            {
                ans.Add(counter.Ping(values[i][0]));
            }
        }

        Console.WriteLine($"[{string.Join(", ", ans)}]");
    }
}