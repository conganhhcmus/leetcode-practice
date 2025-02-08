#if DEBUG
namespace Problems_2349_2;
#endif


public class NumberContainers
{
    Dictionary<int, int> _indexToNum;
    Dictionary<int, PriorityQueue<int, int>> _numToIndices;

    public NumberContainers()
    {
        _indexToNum = [];
        _numToIndices = [];
    }

    public void Change(int index, int number)
    {
        _indexToNum[index] = number;

        var pq = _numToIndices.GetValueOrDefault(number, null);
        if (pq == null)
        {
            pq = new PriorityQueue<int, int>();
            _numToIndices[number] = pq;
        }
        pq.Enqueue(index, index);
    }

    public int Find(int number)
    {
        var pq = _numToIndices.GetValueOrDefault(number, new());
        while (pq.Count > 0)
        {
            int index = pq.Peek();
            if (_indexToNum[index] == number) return index;
            pq.Dequeue();
        }
        return -1;
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