public class Solution
{
    public IList<string> WatchedVideosByFriends(IList<IList<string>> watchedVideos, int[][] friends, int id, int level)
    {
        int n = friends.Length;
        int[] dist = new int[n];
        dist[id] = 0;
        int INF = 1 << 30;
        Array.Fill(dist, INF);

        Dfs(id, id, 0);

        List<string> ans = [];
        Dictionary<string, int> freq = [];
        for (int i = 0; i < n; i++)
        {
            if (dist[i] == level)
            {
                foreach (string video in watchedVideos[i])
                {
                    if (!freq.ContainsKey(video))
                    {
                        ans.Add(video);
                        freq[video] = 0;
                    }
                    freq[video]++;
                }
            }
        }

        ans.Sort((a, b) =>
        {
            if (freq[a] == freq[b]) return a.CompareTo(b);
            return freq[a].CompareTo(freq[b]);
        });
        return ans;

        void Dfs(int u, int p, int l)
        {
            foreach (int v in friends[u])
            {
                if (v == p) continue;
                if (dist[v] > l + 1)
                {
                    dist[v] = l + 1;
                    Dfs(v, u, l + 1);
                }
            }
        }
    }
}
