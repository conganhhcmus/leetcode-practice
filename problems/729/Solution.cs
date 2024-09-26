namespace Problem_729;

using System.Collections;

public class MyCalendar
{
    public record Pair(int start, int end);
    private readonly SortedList mySorted;
    public MyCalendar()
    {
        mySorted = [];
    }

    public bool Book(int start, int end)
    {
        if (mySorted.IndexOfKey(start) != -1)
        {
            return false;
        }

        mySorted.Add(start, new Pair(start, end));

        var pos = mySorted.IndexOfKey(start);
        Pair? prevVal = null;
        Pair? nextVal = null;
        if (pos - 1 >= 0)
        {
            prevVal = (Pair?)mySorted.GetByIndex(pos - 1);
        }

        if (pos + 1 < mySorted.Count)
        {
            nextVal = (Pair?)mySorted.GetByIndex(pos + 1);
        }

        if ((prevVal is not null && prevVal.end > start)
        || (nextVal is not null && nextVal.start < end))
        {
            mySorted.RemoveAt(pos);
            return false;
        }

        return true;
    }
}

public class Solution
{
    public static void Execute()
    {
        string[] events = ["MyCalendar", "book", "book", "book"];
        int[][] times = [[], [10, 20], [15, 25], [20, 30]];
        MyCalendar? myCalendar = null;
        List<string> ans = [];

        for (int i = 0; i < events.Length; i++)
        {
            if (events[i].Equals("MyCalendar") || myCalendar is null)
            {
                myCalendar = new MyCalendar();
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