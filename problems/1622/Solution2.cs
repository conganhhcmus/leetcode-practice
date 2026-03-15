public class Fancy
{
    long mod = (long)1e9 + 7;
    List<long> data;
    long multi = 1;
    long add = 0;
    public Fancy()
    {
        data = [];
    }

    long FastPow(long a, long b)
    {
        long ans = 1;
        while (b > 0)
        {
            if ((b & 1) != 0)
            {
                ans = ans * a % mod;
            }
            a = a * a % mod;
            b >>= 1;
        }
        return ans;
    }

    public void Append(int val)
    {
        // Normalize: store x such that x * multi + add ≡ val (mod MOD)
        long invMod = FastPow(multi, mod - 2);
        data.Add(((val - add) % mod + mod) % mod * invMod % mod);
    }

    public void AddAll(int inc)
    {
        add = (add + inc) % mod;
    }

    public void MultAll(int m)
    {
        add = add * m % mod;
        multi = multi * m % mod;
    }

    public int GetIndex(int idx)
    {
        if (idx >= data.Count) return -1;
        return (int)((data[idx] * multi % mod + add) % mod);
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