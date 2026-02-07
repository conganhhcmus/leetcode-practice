public class TaskManager
{
    PriorityQueue<(int userId, int taskId, int priority), (int taskId, int priority)> pq = new(Comparer<(int taskId, int priority)>.Create((a, b) =>
    {
        if (a.priority == b.priority) return b.taskId.CompareTo(a.taskId);
        return b.priority.CompareTo(a.priority);
    }));

    Dictionary<int, int> mapTaskIdToUser = [];

    Dictionary<int, int> mapTaskIdToPriority = [];

    public TaskManager(IList<IList<int>> tasks)
    {
        foreach (IList<int> task in tasks)
        {
            int userId = task[0];
            int taskId = task[1];
            int priority = task[2];
            Add(userId, taskId, priority);
        }
    }

    public void Add(int userId, int taskId, int priority)
    {
        pq.Enqueue((userId, taskId, priority), (taskId, priority));
        mapTaskIdToUser[taskId] = userId;
        mapTaskIdToPriority[taskId] = priority;
    }

    public void Edit(int taskId, int newPriority)
    {
        mapTaskIdToPriority[taskId] = newPriority;
        int userId = mapTaskIdToUser[taskId];
        pq.Enqueue((userId, taskId, newPriority), (taskId, newPriority));
    }

    public void Rmv(int taskId)
    {
        mapTaskIdToPriority.Remove(taskId);
        mapTaskIdToUser.Remove(taskId);
    }

    public int ExecTop()
    {
        while (pq.Count > 0)
        {
            var (userId, taskId, priority) = pq.Dequeue();
            if (mapTaskIdToPriority.TryGetValue(taskId, out int curPriority) && mapTaskIdToUser.TryGetValue(taskId, out int curUserId))
            {
                if (curPriority == priority && curUserId == userId)
                {
                    Rmv(taskId);
                    return userId;
                }
            }
        }
        return -1;
    }
}

/**
 * Your TaskManager object will be instantiated and called as such:
 * TaskManager obj = new TaskManager(tasks);
 * obj.Add(userId,taskId,priority);
 * obj.Edit(taskId,newPriority);
 * obj.Rmv(taskId);
 * int param_4 = obj.ExecTop();
 */


public class Solution
{
    public List<dynamic> Execute(string[] actions, dynamic values)
    {
        List<dynamic> result = [];
        object[] objectList = JsonConvert.DeserializeObject<object[]>(values);
        TaskManager taskManager = null;
        for (int i = 0; i < actions.Length; i++)
        {
            switch (actions[i])
            {
                case "TaskManager":
                    int[][][] inputs = CastType<int[][]>(objectList[i]);
                    taskManager = new TaskManager(inputs[0]);
                    result.Add(null);
                    break;
                case "add":
                    taskManager.Add(CastType<int>(objectList[i])[0], CastType<int>(objectList[i])[1], CastType<int>(objectList[i])[2]);
                    result.Add(null);
                    break;
                case "rmv":
                    taskManager.Rmv(CastType<int>(objectList[i])[0]);
                    result.Add(null);
                    break;
                case "execTop":
                    result.Add(taskManager.ExecTop());
                    break;
                case "edit":
                    taskManager.Edit(CastType<int>(objectList[i])[0], CastType<int>(objectList[i])[1]);
                    result.Add(null);
                    break;
                default:
                    break;
            }
        }
        return result;
    }

    private T[] CastType<T>(object value)
    {
        return JsonConvert.DeserializeObject<T[]>(JsonConvert.SerializeObject(value));
    }
}