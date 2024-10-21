namespace Problem_547;

public class Solution
{
    public static void Execute()
    {
        var solution = new Solution();
        int[][] isConnected = [[1, 1, 0], [1, 1, 0], [0, 0, 1]];
        Console.WriteLine(solution.FindCircleNum(isConnected));
    }
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