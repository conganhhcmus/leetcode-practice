namespace Problem_215;

public class Solution
{
    public int FindKthLargest(int[] nums, int k)
    {
        // return PriorityQueue(nums, k);
        return Heap(nums, k);
    }

    private int Heap(int[] nums, int k)
    {
        int min = int.MaxValue;
        int max = int.MinValue;
        foreach (var num in nums)
        {
            min = Math.Min(min, num);
            max = Math.Max(max, num);
        }
        int[] frequency = new int[max - min + 1];
        foreach (var num in nums)
        {
            frequency[num - min]++;
        }

        for (int i = frequency.Length - 1; i >= 0; i--)
        {
            k -= frequency[i];
            if (k <= 0) return i + min;
        }
        return -1;
    }

    private int PriorityQueue(int[] nums, int k)
    {
        PriorityQueue<int, int> queue = new(Comparer<int>.Create((a, b) => b - a));

        foreach (int num in nums)
        {
            queue.Enqueue(num, num);
        }

        while (k > 1)
        {
            queue.Dequeue();
            k--;
        }
        return queue.Dequeue();
    }
}