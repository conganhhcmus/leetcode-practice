public class Solution
{
    public int FindCircleNum(int[][] isConnected)
    {
        if (isConnected.Length == 0) return 0;

        HashSet<int> connected = [];
        int count = 0;
        void DFS(int start, int curr)
        {
            for (int i = 0; i < isConnected.Length; i++)
            {
                if (isConnected[curr][i] == 1 && connected.Add(i))
                {
                    DFS(start, i);
                }
            }
        }

        for (int i = 0; i < isConnected.Length; i++)
        {
            if (connected.Add(i))
            {
                count++;
                DFS(i, i);
            }
        }

        return count;
    }
}