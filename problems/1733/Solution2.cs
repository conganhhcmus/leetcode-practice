#if DEBUG
namespace Problems_1733_2;
#endif

public class Solution
{
    public int MinimumTeachings(int n, int[][] languages, int[][] friendships)
    {
        HashSet<int> need = [];
        foreach (int[] friendship in friendships)
        {
            int u = friendship[0] - 1, v = friendship[1] - 1;
            HashSet<int> mp = [];
            bool connected = false;
            foreach (int lang in languages[u])
            {
                mp.Add(lang);
            }

            foreach (int lang in languages[v])
            {
                if (!mp.Add(lang))
                {
                    connected = true;
                    break;
                }
            }

            if (!connected)
            {
                need.Add(u);
                need.Add(v);
            }
        }

        int[] count = new int[n + 1];
        int max = 0;
        foreach (int user in need)
        {
            foreach (int lang in languages[user])
            {
                count[lang]++;
                max = Math.Max(max, count[lang]);
            }
        }
        return need.Count - max;
    }
}