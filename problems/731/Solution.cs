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
    public List<string> Execute(string[] events, int[][] times)
    {
        MyCalendarTwo_2 myCalendar = null;
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

        return ans;
    }
}

/**
 * Your MyCalendar object will be instantiated and called as such:
 * MyCalendar obj = new MyCalendar();
 * bool param_1 = obj.Book(start,end);
 */