public class EventManager
{
    public record Pair(int Id, int P);

    public class PairComparer : IComparer<Pair>
    {
        public int Compare(Pair a, Pair b)
        {
            if (a.P == b.P) return a.Id.CompareTo(b.Id);
            return b.P.CompareTo(a.P);
        }
    }

    PriorityQueue<Pair, Pair> pq;
    Dictionary<int, int> map;
    public EventManager(int[][] events)
    {
        pq = new(new PairComparer());
        map = [];
        foreach (int[] e in events)
        {
            Pair pair = new(e[0], e[1]);
            pq.Enqueue(pair, pair);
            map[e[0]] = e[1];
        }
    }

    public void UpdatePriority(int eventId, int newPriority)
    {
        Pair pair = new(eventId, newPriority);
        map[eventId] = newPriority;
        pq.Enqueue(pair, pair);
    }

    public int PollHighest()
    {
        while (pq.Count > 0)
        {
            Pair pair = pq.Dequeue();
            if (map.ContainsKey(pair.Id) && map[pair.Id] == pair.P)
            {
                map.Remove(pair.Id);
                return pair.Id;
            }
        }
        return -1;
    }
}

/**
 * Your EventManager object will be instantiated and called as such:
 * EventManager obj = new EventManager(events);
 * obj.UpdatePriority(eventId,newPriority);
 * int param_2 = obj.PollHighest();
 */