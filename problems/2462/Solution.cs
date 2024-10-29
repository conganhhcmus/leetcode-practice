namespace Problem_2462;

public class Solution
{
    public static void Execute()
    {
        int[] costs = [1, 2, 4, 1];
        int k = 3;
        int candidates = 3;
        var solution = new Solution();
        Console.WriteLine(solution.TotalCost(costs, k, candidates));
    }
    public long TotalCost(int[] costs, int k, int candidates)
    {
        PriorityQueue<int, int> leftQueue = new();
        PriorityQueue<int, int> rightQueue = new();
        int left = 0;
        int right = costs.Length - 1;
        while (left < right && left < candidates)
        {
            leftQueue.Enqueue(costs[left], costs[left]);
            left++;

            rightQueue.Enqueue(costs[right], costs[right]);
            right--;
        }

        if (left == right && left < candidates)
        {
            leftQueue.Enqueue(costs[left], costs[left]);
            left++;
        }

        long totalCost = 0;
        while (k > 0)
        {
            int valLeft = leftQueue.Count > 0 ? leftQueue.Peek() : int.MaxValue;
            int valRight = rightQueue.Count > 0 ? rightQueue.Peek() : int.MaxValue;

            if (valLeft <= valRight)
            {
                totalCost += leftQueue.Dequeue();
                if (left <= right)
                {
                    leftQueue.Enqueue(costs[left], costs[left]);
                    left++;
                }
            }
            else
            {
                totalCost += rightQueue.Dequeue();
                if (right >= left)
                {
                    rightQueue.Enqueue(costs[right], costs[right]);
                    right--;
                }
            }

            k--;
        }

        return totalCost;
    }
}