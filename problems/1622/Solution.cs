public class Fancy
{
    int mod = (int)1e9 + 7;
    List<long> arr;
    List<(int s, int v)> opt;
    Dictionary<int, int> map;

    public Fancy()
    {
        arr = [];
        opt = [];
        map = [];
    }

    public void Append(int val)
    {
        arr.Add(val);
        map[arr.Count - 1] = opt.Count;
    }

    public void AddAll(int inc)
    {
        opt.Add((0, inc));
    }

    public void MultAll(int m)
    {
        opt.Add((1, m));
    }

    public int GetIndex(int idx)
    {
        if (idx >= arr.Count) return -1;
        int l = map[idx], r = opt.Count - 1;
        long val = arr[idx];
        for (int i = l; i <= r; i++)
        {
            if (opt[i].s == 0)
            {
                val = (val + opt[i].v) % mod;
            }
            else
            {
                val = val * opt[i].v % mod;
            }
        }
        arr[idx] = val;
        map[idx] = opt.Count;
        return (int)val;
    }
}

/**
 * Your Fancy object will be instantiated and called as such:
 * Fancy obj = new Fancy();
 * obj.Append(val);
 * obj.AddAll(inc);
 * obj.MultAll(m);
 * int param_4 = obj.GetIndex(idx);
 */


public class Solution
{
    public List<dynamic> Execute(string[] actions, int[][] values)
    {
        List<dynamic> result = [];
        Fancy fancy = null;
        for (int i = 0; i < actions.Length; i++)
        {
            switch (actions[i])
            {
                case "Fancy":
                    fancy = new Fancy();
                    result.Add(null);
                    break;
                case "append":
                    fancy.Append(values[i][0]);
                    result.Add(null);
                    break;
                case "addAll":
                    fancy.AddAll(values[i][0]);
                    result.Add(null);
                    break;
                case "multAll":
                    fancy.MultAll(values[i][0]);
                    result.Add(null);
                    break;
                case "getIndex":
                    result.Add(fancy.GetIndex(values[i][0]));
                    break;
                default:
                    break;
            }
        }
        return result;
    }
}