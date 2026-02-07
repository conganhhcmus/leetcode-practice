public class Solution
{
    public long PickGifts(int[] gifts, int k)
    {
        long ans = 0;
        PriorityQueue<int, int> queue = new(Comparer<int>.Create((a, b) => b - a));
        foreach (int gift in gifts)
        {
            queue.Enqueue(gift, gift);
            ans += gift;
        }

        while (k > 0)
        {
            int gift = queue.Dequeue();
            int remaining = (int)Math.Sqrt(gift);
            queue.Enqueue(remaining, remaining);
            ans -= gift - remaining;
            k--;
        }

        return ans;
    }
}