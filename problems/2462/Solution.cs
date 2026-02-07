public class Solution
{
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