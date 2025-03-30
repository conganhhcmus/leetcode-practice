namespace Library;

public class MinHeap
{
    public int[] a;
    public int[] map;
    public int[] imap;
    public int n;
    public int pos;
    public const int INF = int.MaxValue;

    public MinHeap(int m)
    {
        n = m + 2;
        a = new int[n];
        map = new int[n];
        imap = new int[n];
        for (int i = 0; i < n; i++)
        {
            a[i] = INF;
            map[i] = -1;
            imap[i] = -1;
        }
        pos = 1;
    }

    public int Add(int ind, int x)
    {
        int ret = imap[ind];
        if (imap[ind] < 0)
        {
            a[pos] = x;
            map[pos] = ind;
            imap[ind] = pos;
            pos++;
            Up(pos - 1);
        }
        return ret != -1 ? a[ret] : x;
    }

    public int Update(int ind, int x)
    {
        int ret = imap[ind];
        if (imap[ind] < 0)
        {
            Add(ind, x);
        }
        else
        {
            a[ret] = x;
            Up(ret);
            Down(ret);
        }
        return x;
    }

    public int Remove(int ind)
    {
        if (pos == 1) return INF;
        if (imap[ind] == -1) return INF;

        pos--;
        int rem = imap[ind];
        int ret = a[rem];
        map[rem] = map[pos];
        imap[map[pos]] = rem;
        imap[ind] = -1;
        a[rem] = a[pos];
        a[pos] = INF;
        map[pos] = -1;

        Up(rem);
        Down(rem);
        return ret;
    }

    public int Min => a[1];
    public int ArgMin => map[1];
    public int Size => pos - 1;
    public int Get(int ind) => a[imap[ind]];

    private void Up(int cur)
    {
        for (int c = cur, p = c >> 1; p >= 1 && a[p] > a[c]; c = p, p = c >> 1)
        {
            // Swap a[p] and a[c]
            (a[c], a[p]) = (a[p], a[c]);

            // Swap imap entries for the original map[p] and map[c]
            (imap[map[c]], imap[map[p]]) = (imap[map[p]], imap[map[c]]);

            // Swap map[p] and map[c]
            (map[c], map[p]) = (map[p], map[c]);
        }
    }

    private void Down(int cur)
    {
        int c = cur;
        while (true)
        {
            int left = 2 * c;
            int right = left + 1;
            int smallest = c;

            if (left < pos && a[left] < a[smallest]) smallest = left;
            if (right < pos && a[right] < a[smallest]) smallest = right;

            if (smallest == c) break;

            // Swap a[c] and a[smallest]
            (a[smallest], a[c]) = (a[c], a[smallest]);

            // Swap imap entries for the original map[c] and map[smallest]
            (imap[map[smallest]], imap[map[c]]) = (imap[map[c]], imap[map[smallest]]);

            // Swap map[c] and map[smallest]
            (map[smallest], map[c]) = (map[c], map[smallest]);
            c = smallest;
        }
    }
}