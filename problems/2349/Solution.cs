#if DEBUG
namespace Problems_2349;
#endif

public class NumberContainers
{
    Dictionary<int, int> _data;
    Dictionary<int, SortedSet<int>> _index;

    public NumberContainers()
    {
        _data = [];
        _index = [];
    }

    public void Change(int index, int number)
    {
        int oldNumber = _data.GetValueOrDefault(index, -1);
        if (oldNumber == number) return;
        _data[index] = number;

        if (oldNumber != -1 && _index.TryGetValue(oldNumber, out var value))
        {
            value.Remove(index);
            if (value.Count == 0) _index.Remove(oldNumber);
        }

        var idxList = _index.GetValueOrDefault(number, null);
        if (idxList == null)
        {
            idxList = [];
            _index[number] = idxList;
        }
        idxList.Add(index);
    }

    public int Find(int number)
    {
        return _index.TryGetValue(number, out var idxList) ? idxList.Min : -1;
    }
}

/**
 * Your NumberContainers object will be instantiated and called as such:
 * NumberContainers obj = new NumberContainers();
 * obj.Change(index,number);
 * int param_2 = obj.Find(number);
 */

public class Solution
{
    public List<int?> Execute(string[] actions, int[][] values)
    {
        List<int?> result = [];
        NumberContainers nc = new();
        for (int i = 0; i < actions.Length; i++)
        {
            switch (actions[i])
            {
                case "NumberContainers":
                    nc = new NumberContainers();
                    result.Add(null);
                    break;
                case "change":
                    nc.Change(values[i][0], values[i][1]);
                    result.Add(null);
                    break;
                case "find":
                    result.Add(nc.Find(values[i][0]));
                    break;
                default:
                    break;
            }
        }
        return result;
    }
}