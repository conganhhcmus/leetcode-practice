#if DEBUG
namespace Problems_1298;
#endif

public class Solution
{
    public int MaxCandies(int[] status, int[] candies, int[][] keys, int[][] containedBoxes, int[] initialBoxes)
    {
        int n = status.Length;
        int ret = 0;
        int[] state = new int[n];
        bool[] hasKeys = new bool[n];
        Queue<int> queue = [];
        foreach (int box in initialBoxes)
        {
            queue.Enqueue(box);
        }

        while (queue.Count > 0)
        {
            int curr = queue.Dequeue();
            if (state[curr] == 2) continue;
            state[curr] = 1;
            if (hasKeys[curr] || status[curr] == 1)
            {
                hasKeys[curr] = true;
                state[curr] = 2;
                ret += candies[curr];
                foreach (int box in keys[curr])
                {
                    hasKeys[box] = true;
                    if (state[box] == 1) queue.Enqueue(box);
                }

                foreach (int next in containedBoxes[curr])
                {
                    if (state[next] == 0) queue.Enqueue(next);
                }
            }
        }

        return ret;
    }
}