#if DEBUG
namespace Weekly_444_Q4;
#endif

public class Solution
{
    public int MinimumPairRemoval(int[] nums)
    {
        int n = nums.Length;
        if (n <= 1) return 0;
        Node[] nodes = new Node[n];
        for (int i = 0; i < n; i++)
        {
            nodes[i] = new(nums[i], i);
        }
        for (int i = 0; i < n; i++)
        {
            if (i > 0) nodes[i].Prev = nodes[i - 1];
            if (i < n - 1) nodes[i].Next = nodes[i + 1];
        }

        Node head = nodes[0];
        int bad = 0;
        Node curr = head;
        while (curr != null && curr.Next != null)
        {
            if (curr.Value > curr.Next.Value)
            {
                bad++;
            }
            curr = curr.Next;
        }

        if (bad == 0) return 0;
        PriorityQueue<Pair, Pair> pq = new();
        curr = head;
        while (curr != null && curr.Next != null)
        {
            Pair pair = new(curr, curr.Next);
            pq.Enqueue(pair, pair);
            curr = curr.Next;
        }

        int len = n;
        int ans = 0;
        while (bad > 0 && len > 1)
        {
            Pair pair = null;
            while (pq.Count > 0)
            {
                Pair candidate = pq.Peek();
                if (candidate.Left.Removed || candidate.Right.Removed || candidate.Left.Next != candidate.Right)
                {
                    pq.Dequeue();
                    continue;
                }
                long currSum = candidate.Left.Value + candidate.Right.Value;
                if (currSum != candidate.Sum)
                {
                    pq.Dequeue();
                    candidate.Sum = currSum;
                    pq.Enqueue(candidate, candidate);
                    continue;
                }
                pair = candidate;
                break;
            }
            if (pair == null) break;
            pq.Dequeue();
            Node left = pair.Left;
            Node right = pair.Right;
            long newValue = left.Value + right.Value;
            if (left.Prev != null)
            {
                bad -= IsBad(left.Prev.Value, left.Value);
                bad += IsBad(left.Prev.Value, newValue);
            }
            bad -= IsBad(left.Value, right.Value);
            if (right.Next != null)
            {
                bad -= IsBad(right.Value, right.Next.Value);
                bad += IsBad(newValue, right.Next.Value);
            }

            left.Value = newValue;
            right.Removed = true;
            left.Next = right.Next;
            if (right.Next != null)
            {
                right.Next.Prev = left;
            }
            len--;
            if (left.Prev != null)
            {
                Pair nPair = new(left.Prev, left);
                pq.Enqueue(nPair, nPair);
            }

            if (left.Next != null)
            {
                Pair nPair = new(left, left.Next);
                pq.Enqueue(nPair, nPair);
            }
            ans++;
        }
        return ans;
    }

    int IsBad(long a, long b)
    {
        return a > b ? 1 : 0;
    }
}

public class Node
{
    public long Value;
    public int Pos;
    public Node Prev, Next;
    public bool Removed = false;
    public Node(long value, int pos)
    {
        Value = value;
        Pos = pos;
    }
}

public class Pair : IComparable<Pair>
{
    public Node Left, Right;

    public long Sum;

    public int Order;

    public Pair(Node left, Node right)
    {
        Left = left;
        Right = right;
        Sum = left.Value + right.Value;
        Order = left.Pos;
    }

    public int CompareTo(Pair other)
    {
        if (Sum != other.Sum) return Sum.CompareTo(other.Sum);
        return Order.CompareTo(other.Order);
    }
}