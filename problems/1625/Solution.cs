public class Solution
{
    public string FindLexSmallestString(string s, int a, int b)
    {
        string ans = s;

        HashSet<string> visited = [];
        Queue<string> queue = [];
        queue.Enqueue(s);
        visited.Add(s);
        while (queue.Count > 0)
        {
            string curr = queue.Dequeue();
            if (string.Compare(curr, ans) < 0)
            {
                ans = curr;
            }
            string rotate = Rotate(curr, b);
            string update = Update(curr, a);
            if (visited.Add(rotate))
            {
                queue.Enqueue(rotate);
            }

            if (visited.Add(update))
            {
                queue.Enqueue(update);
            }
        }

        return ans;
    }

    string Rotate(string s, int k)
    {
        int n = s.Length;
        StringBuilder sb = new();
        for (int i = k; i < n; i++)
        {
            sb.Append(s[i]);
        }
        for (int i = 0; i < k; i++)
        {
            sb.Append(s[i]);
        }
        return sb.ToString();
    }

    string Update(string s, int k)
    {
        int n = s.Length;
        StringBuilder sb = new(s);
        for (int i = 1; i < n; i += 2)
        {
            sb[i] = (char)(((sb[i] - '0' + k) % 10 + 10) % 10 + '0');
        }

        return sb.ToString();
    }
}