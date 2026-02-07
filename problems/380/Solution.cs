public class RandomizedSet
{
    private Dictionary<int, int> _set;
    private List<int> _elements;
    private static Random _random = new Random();

    public RandomizedSet()
    {
        _set = [];
        _elements = [];
    }

    public bool Insert(int val)
    {
        if (_set.ContainsKey(val))
        {
            return false;
        }

        _set[val] = _elements.Count;
        _elements.Add(val);

        return true;
    }

    public bool Remove(int val)
    {
        if (!_set.ContainsKey(val))
        {
            return false;
        }

        var index = _set[val];
        var lastValue = _elements[^1];
        _elements[index] = lastValue;
        _set[lastValue] = index;

        _set.Remove(val);
        _elements.RemoveAt(_elements.Count - 1);

        return true;
    }

    public int GetRandom()
    {
        var index = _random.Next(0, _elements.Count);
        return _elements[index];
    }
}

public class Solution
{
    public List<string> Execute(string[] actions, int[][] values)
    {
        RandomizedSet randomizedSet = new RandomizedSet();
        List<string> result = [];
        for (int i = 0; i < actions.Length; i++)
        {
            result.Add(actions[i] switch
            {
                "insert" => randomizedSet.Insert(values[i][0]).ToString(),
                "remove" => randomizedSet.Remove(values[i][0]).ToString(),
                "getRandom" => randomizedSet.GetRandom().ToString(),
                _ => "null"
            });
        }

        return result;
    }
}

/**
 * Your RandomizedSet object will be instantiated and called as such:
 * RandomizedSet obj = new RandomizedSet();
 * bool param_1 = obj.Insert(val);
 * bool param_2 = obj.Remove(val);
 * int param_3 = obj.GetRandom();
 */