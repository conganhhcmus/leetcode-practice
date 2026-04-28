public class Solution
{
    public IList<string> WatchedVideosByFriends(IList<IList<string>> watchedVideos, int[][] friends, int id, int level)
    {
        int n = friends.Length;
        bool[] visited = new bool[n];
        Queue<int> q = new Queue<int>();

        q.Enqueue(id);
        visited[id] = true;

        int curr = 0;

        while (q.Count > 0 && curr < level)
        {
            int size = q.Count;

            for (int i = 0; i < size; i++)
            {
                int u = q.Dequeue();

                foreach (int v in friends[u])
                {
                    if (visited[v]) continue;
                    visited[v] = true;
                    q.Enqueue(v);
                }
            }

            curr++;
        }

        Dictionary<string, int> freq = new();

        while (q.Count > 0)
        {
            int u = q.Dequeue();

            foreach (string video in watchedVideos[u])
            {
                freq[video] = freq.GetValueOrDefault(video, 0) + 1;
            }
        }

        var ans = freq.Keys.ToList();

        ans.Sort((a, b) =>
        {
            if (freq[a] != freq[b])
                return freq[a].CompareTo(freq[b]);
            return a.CompareTo(b);
        });

        return ans;
    }
}
