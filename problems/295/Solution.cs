#if DEBUG
namespace Problems_295;
#endif

public class MedianFinder
{
    PriorityQueue<int, int> minHeap;
    PriorityQueue<int, int> maxHeap;

    public MedianFinder()
    {
        minHeap = new();
        maxHeap = new(Comparer<int>.Create((a, b) => b - a));
    }

    public void AddNum(int num)
    {
        maxHeap.Enqueue(num, num);
        int val = maxHeap.Dequeue();
        minHeap.Enqueue(val, val);
        if (minHeap.Count > maxHeap.Count)
        {
            int tmp = minHeap.Dequeue();
            maxHeap.Enqueue(tmp, tmp);
        }
    }

    public double FindMedian()
    {
        if (maxHeap.Count > minHeap.Count) return maxHeap.Peek();
        return (maxHeap.Peek() + minHeap.Peek()) / 2.0;
    }
}

/**
 * Your MedianFinder object will be instantiated and called as such:
 * MedianFinder obj = new MedianFinder();
 * obj.AddNum(num);
 * double param_2 = obj.FindMedian();
 */

public class Solution
{
    public List<dynamic> Execute(string[] actions, int[][] values)
    {
        List<dynamic> result = [];
        MedianFinder medianFinder = null;
        for (int i = 0; i < actions.Length; i++)
        {
            switch (actions[i])
            {
                case "MedianFinder":
                    medianFinder = new MedianFinder();
                    result.Add(null);
                    break;
                case "addNum":
                    medianFinder.AddNum(values[i][0]);
                    result.Add(null);
                    break;
                case "findMedian":
                    result.Add(medianFinder.FindMedian());
                    break;
                default:
                    break;
            }
        }
        return result;
    }
}