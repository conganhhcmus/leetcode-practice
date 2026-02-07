public class Solution
{
    public int FindKthLargest(int[] nums, int k)
    {
        PriorityQueue<int, int> pq = new(Comparer<int>.Create((a, b) => b - a));

        foreach (int num in nums)
        {
            pq.Enqueue(num, num);
        }

        while (k > 1)
        {
            pq.Dequeue();
            k--;
        }
        return pq.Dequeue();
    }
}