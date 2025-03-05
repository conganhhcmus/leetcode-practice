#if DEBUG
namespace Contests_434_Q2;
#endif

public class Solution
{
    public int[] CountMentions(int numberOfUsers, IList<IList<string>> events)
    {
        int[] mentions = new int[numberOfUsers];
        bool[] isOnline = new bool[numberOfUsers];
        Array.Fill(isOnline, true);
        PriorityQueue<(int time, int id), int> pq = new();
        var eventsArray = events.ToArray();
        Array.Sort(eventsArray, (a, b) =>
        {
            int time1 = int.Parse(a[1]);
            int time2 = int.Parse(b[1]);
            if (time1 != time2) return time1 - time2;
            if (a[0] == b[0]) return 0;
            if (a[0] == "MESSAGE") return 1;
            return -1;
        });
        events = eventsArray.ToList();
        foreach (var @event in events)
        {
            if (@event[0] == "MESSAGE")
            {
                while (pq.Count > 0 && pq.Peek().time <= int.Parse(@event[1]))
                {
                    var (_, id) = pq.Dequeue();
                    isOnline[id] = true;
                }
                if (@event[2] == "ALL")
                {
                    for (int i = 0; i < numberOfUsers; i++)
                    {
                        mentions[i]++;
                    }
                }
                else if (@event[2] == "HERE")
                {
                    for (int i = 0; i < numberOfUsers; i++)
                    {
                        if (isOnline[i]) mentions[i]++;
                    }
                }
                else
                {
                    string[] ids = @event[2].Split(" ");
                    foreach (var id in ids)
                    {
                        int userId = int.Parse(id[2..]);
                        mentions[userId]++;
                    }
                }
            }
            else if (@event[0] == "OFFLINE")
            {
                int time = int.Parse(@event[1]);
                int id = int.Parse(@event[2]);
                while (pq.Count > 0 && pq.Peek().time <= time)
                {
                    var (_, id1) = pq.Dequeue();
                    isOnline[id1] = true;
                }
                isOnline[id] = false;
                pq.Enqueue((time + 60, id), time + 60);
            }
        }

        return mentions;
    }
}