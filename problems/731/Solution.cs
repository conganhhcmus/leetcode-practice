namespace Problem_731;

public class MyCalendarTwo
{
    private readonly List<int[]> bookings;
    private readonly List<int[]> overlapBookings;
    public MyCalendarTwo()
    {
        bookings = [];
        overlapBookings = [];
    }

    private bool doesOverlap(int start1, int end1, int start2, int end2)
    {
        return int.Max(start1, start2) < int.Min(end1, end2);
    }

    private int[] getOverlapped(int start1, int end1, int start2, int end2)
    {
        return [int.Max(start1, start2), int.Min(end1, end2)];
    }

    public bool Book(int start, int end)
    {
        foreach (int[] booking in overlapBookings)
        {
            if (doesOverlap(booking[0], booking[1], start, end))
            {
                return false;
            }
        }

        foreach (int[] booking in bookings)
        {
            if (doesOverlap(booking[0], booking[1], start, end))
            {
                overlapBookings.Add(getOverlapped(booking[0], booking[1], start, end));
            }
        }

        bookings.Add([start, end]);
        return true;
    }
}

public class MyCalendarTwo_2
{
    private SortedDictionary<int, int> eventCount;
    public MyCalendarTwo_2()
    {
        eventCount = [];
    }

    public bool Book(int start, int end)
    {
        if (eventCount.ContainsKey(start))
        {
            eventCount[start]++;
        }
        else
        {
            eventCount.Add(start, 1);
        }

        if (eventCount.ContainsKey(end))
        {
            eventCount[end]--;
        }
        else
        {
            eventCount.Add(end, -1);
        }

        int ongoingEvent = 0;
        foreach (int count in eventCount.Values)
        {
            ongoingEvent += count;
            if (ongoingEvent >= 3)
            {
                eventCount[start]--;
                eventCount[end]++;
                return false;
            }
        }

        return true;
    }
}

public class Solution
{
    public static void Execute()
    {
        string[] events = ["MyCalendarTwo", "book", "book", "book", "book", "book", "book", "book", "book", "book", "book", "book", "book", "book", "book", "book", "book", "book", "book", "book", "book", "book", "book", "book", "book", "book", "book", "book", "book", "book", "book"];
        int[][] times = [[], [47, 50], [1, 10], [27, 36], [40, 47], [20, 27], [15, 23], [10, 18], [27, 36], [17, 25], [8, 17], [24, 33], [23, 28], [21, 27], [47, 50], [14, 21], [26, 32], [16, 21], [2, 7], [24, 33], [6, 13], [44, 50], [33, 39], [30, 36], [6, 15], [21, 27], [49, 50], [38, 45], [4, 12], [46, 50], [13, 21]];
        MyCalendarTwo_2? myCalendar = null;
        List<string> ans = [];

        for (int i = 0; i < events.Length; i++)
        {
            if (events[i].Equals("MyCalendarTwo") || myCalendar is null)
            {
                myCalendar = new MyCalendarTwo_2();
                ans.Add("null");
            }
            else
            {
                ans.Add(myCalendar.Book(times[i][0], times[i][1]).ToString());
            }
        }

        Console.WriteLine($"[{string.Join(",", ans)}]");
    }
}

/**
 * Your MyCalendar object will be instantiated and called as such:
 * MyCalendar obj = new MyCalendar();
 * bool param_1 = obj.Book(start,end);
 */