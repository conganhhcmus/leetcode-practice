namespace Problem_1405;

public class Solution
{
    public static void Execute()
    {
        int a = 4, b = 4, c = 3;
        var solution = new Solution();
        Console.WriteLine(solution.LongestDiverseString(a, b, c));
    }
    public string LongestDiverseString(int a, int b, int c)
    {
        var ans = "";

        var pq = new PriorityQueue<(int count, char character), int>(Comparer<int>.Create((x, y) => y - x));
        if (a > 0)
        {
            pq.Enqueue((a, 'a'), a);
        }

        if (b > 0)
        {
            pq.Enqueue((b, 'b'), b);
        }

        if (c > 0)
        {
            pq.Enqueue((c, 'c'), c);
        }

        while (pq.Count > 0)
        {
            var p = pq.Dequeue();
            int count = p.count;
            char character = p.character;
            if (ans.Length >= 2 && ans[^1] == p.character && ans[^2] == p.character)
            {
                if (pq.Count == 0) break;

                var temp = pq.Dequeue();
                ans += temp.character;
                if (temp.count - 1 > 0)
                {
                    pq.Enqueue((temp.count - 1, temp.character), temp.count - 1);
                }
            }
            else
            {
                count--;
                ans += character;
            }

            if (count > 0)
            {
                pq.Enqueue((count, character), count);
            }
        }
        return ans;
    }
}