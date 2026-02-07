public class Solution
{
    public long MaxKelements(int[] nums, int k)
    {
        PriorityQueue<int, int> queue = new(Comparer<int>.Create((x, y) => y - x));
        foreach (int num in nums)
        {
            queue.Enqueue(num, num);
        }

        long sum = 0;
        while (k-- > 0)
        {
            var value = queue.Dequeue();
            sum += value;
            var newValue = value % 3 == 0 ? value / 3 : (value / 3 + 1);
            queue.Enqueue(newValue, newValue);
        }

        return sum;
    }
}