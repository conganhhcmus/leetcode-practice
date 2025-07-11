#if DEBUG
namespace Problems_2402;
#endif

public class Solution
{
    public record Booking(int id, int end);
    public int MostBooked(int n, int[][] meetings)
    {
        Array.Sort(meetings, (a, b) => a[0] - b[0]);
        int[] count = new int[n];
        int k = meetings.Length;
        PriorityQueue<int, int> available = new();
        for (int i = 0; i < n; i++)
        {
            available.Enqueue(i, i);
        }
        PriorityQueue<Booking, Booking> booking = new(Comparer<Booking>.Create((a, b) =>
        {
            if (a.end == b.end) return a.id - b.id;
            return a.end - b.end;
        }));
        for (int i = 0; i < k; i++)
        {
            while (booking.Count > 0 && booking.Peek().end <= meetings[i][0])
            {
                Booking free = booking.Dequeue();
                available.Enqueue(free.id, free.id);
            }

            if (available.Count > 0)
            {
                int id = available.Dequeue();
                count[id]++;
                Booking book = new(id, meetings[i][1]);
                booking.Enqueue(book, book);
            }
            else
            {
                Booking book = booking.Dequeue();
                count[book.id]++;
                int end = meetings[i][1] + book.end - meetings[i][0];
                Booking nBook = new(book.id, end);
                booking.Enqueue(nBook, nBook);
            }
        }
        int ans = 0;
        for (int i = 0; i < n; i++)
        {
            if (count[i] > count[ans]) ans = i;
        }
        return ans;
    }
}