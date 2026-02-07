public class Router
{
    int limit = 0;
    Queue<Package> queue;
    HashSet<string> set;
    Dictionary<int, List<int>> map;
    public Router(int memoryLimit)
    {
        limit = memoryLimit;
        queue = new();
        set = [];
        map = [];
    }

    public bool AddPacket(int source, int destination, int timestamp)
    {
        string key = $"{source}_{destination}_{timestamp}";
        if (set.Add(key))
        {
            queue.Enqueue(new(source, destination, timestamp));
            map.TryAdd(destination, []);
            map[destination].Add(timestamp);
            while (queue.Count > limit)
            {
                Package remove = queue.Dequeue();
                set.Remove($"{remove.src}_{remove.dest}_{remove.time}");
                map[remove.dest].RemoveAt(0);
            }
            return true;
        }

        return false;
    }

    public int[] ForwardPacket()
    {
        if (queue.Count == 0) return [];
        Package package = queue.Dequeue();
        set.Remove($"{package.src}_{package.dest}_{package.time}");
        map[package.dest].RemoveAt(0);

        return [package.src, package.dest, package.time];
    }

    public int GetCount(int destination, int startTime, int endTime)
    {
        List<int> timestamps = map.GetValueOrDefault(destination);
        if (timestamps.Count == 0) return 0;
        int left = 0;
        while (left < timestamps.Count && timestamps[left] < startTime) left++;
        int right = timestamps.Count - 1;
        while (right >= 0 && timestamps[right] > endTime) right--;
        if (left > right) return 0;
        return right - left + 1;
    }
}

public record Package(int src, int dest, int time);

/**
 * Your Router object will be instantiated and called as such:
 * Router obj = new Router(memoryLimit);
 * bool param_1 = obj.AddPacket(source,destination,timestamp);
 * int[] param_2 = obj.ForwardPacket();
 * int param_3 = obj.GetCount(destination,startTime,endTime);
 */

public class Solution
{
    public List<dynamic> Execute(string[] actions, int[][] values)
    {
        List<dynamic> result = [];
        Router router = null;
        for (int i = 0; i < actions.Length; i++)
        {
            switch (actions[i])
            {
                case "Router":
                    router = new Router(values[i][0]);
                    result.Add(null);
                    break;
                case "addPacket":
                    result.Add(router.AddPacket(values[i][0], values[i][1], values[i][2]));
                    break;
                case "forwardPacket":
                    result.Add(router.ForwardPacket());
                    break;
                case "getCount":
                    result.Add(router.GetCount(values[i][0], values[i][1], values[i][2]));
                    break;
                default:
                    break;
            }
        }
        return result;
    }
}