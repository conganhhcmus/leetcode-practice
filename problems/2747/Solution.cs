public class Solution
{
    public int[] CountServers(int n, int[][] logs, int x, int[] queries)
    {
        int MAX = queries.Max();
        Array.Sort(logs, (a, b) => a[1].CompareTo(b[1]));
        Dictionary<int, int> freq = [];
        Queue<int> queue = [];
        int[] count = new int[MAX + 1];
        for (int i = 0, j = 0; i <= MAX; i++)
        {
            while (j < logs.Length && logs[j][1] <= i)
            {
                int s = logs[j][0];
                queue.Enqueue(j);
                freq[s] = freq.GetValueOrDefault(s, 0) + 1;
                j++;
            }

            while (queue.Count > 0 && logs[queue.Peek()][1] < i - x)
            {
                int t = queue.Dequeue();
                int s = logs[t][0];
                if (freq[s] == 1) freq.Remove(s);
                else freq[s]--;
            }
            // count server from i-x to i
            count[i] = freq.Count;
        }
        int m = queries.Length;
        int[] ans = new int[m];
        for (int i = 0; i < m; i++)
        {
            ans[i] = n - count[queries[i]];
        }
        return ans;
    }
}