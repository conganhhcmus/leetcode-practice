public class Solution
{
    public IList<int> LargestDivisibleSubset(int[] nums)
    {
        int n = nums.Length;
        Array.Sort(nums);
        List<int>[] graph = new List<int>[n];
        int[] inDegree = new int[n];
        int[] prev = new int[n];
        Array.Fill(prev, -1);
        for (int i = 0; i < n; i++) graph[i] = [];
        for (int i = 0; i < n; i++)
        {
            for (int j = i + 1; j < n; j++)
            {
                if (nums[j] % nums[i] == 0)
                {
                    graph[i].Add(j);
                    inDegree[j]++;
                }
            }
        }

        Queue<int> queue = [];
        for (int i = 0; i < n; i++)
        {
            if (inDegree[i] == 0) queue.Enqueue(i);
        }
        int lastIdx = -1;
        while (queue.Count > 0)
        {
            int node = queue.Dequeue();
            foreach (int neighbor in graph[node])
            {
                inDegree[neighbor]--;
                if (inDegree[neighbor] == 0) queue.Enqueue(neighbor);
                prev[neighbor] = node;
            }
            lastIdx = node;
        }

        List<int> ans = [];
        while (lastIdx != -1)
        {
            ans.Add(nums[lastIdx]);
            lastIdx = prev[lastIdx];
        }

        return ans;
    }
}