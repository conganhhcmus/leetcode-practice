public class AllOne_Second
{
    public class DoublyLinkedList
    {
        public DoublyLinkedList(int value)
        {
            Value = value;
            Prev = Next = null;
            Keys = [];
        }
        public int Value;

        public HashSet<string> Keys;
        public DoublyLinkedList Prev;
        public DoublyLinkedList Next;
    }

    public Dictionary<string, DoublyLinkedList> map;

    public DoublyLinkedList tail;
    public DoublyLinkedList head;
    public AllOne_Second()
    {
        map = [];
        tail = head = null;
    }
    public void Inc(string key)
    {
        if (map.ContainsKey(key))
        {
            var node = map[key];
            node.Keys.Remove(key);

            var nextNode = node.Next;
            if (nextNode is null)
            {
                var newNode = new DoublyLinkedList(node.Value + 1);
                newNode.Keys.Add(key);
                map[key] = newNode;
                tail.Next = newNode;
                newNode.Prev = tail;
                tail = newNode;
            }
            else if (nextNode.Value == node.Value + 1)
            {
                nextNode.Keys.Add(key);
                map[key] = nextNode;
            }
            else
            {
                var newNode = new DoublyLinkedList(node.Value + 1);
                newNode.Keys.Add(key);
                map[key] = newNode;
                newNode.Next = nextNode;
                nextNode.Prev = newNode;
                node.Next = newNode;
                newNode.Prev = node;
            }

            if (node.Keys.Count == 0)
            {
                if (node.Prev is null)
                {
                    head = node.Next;
                    node.Next.Prev = null;
                }
                else
                {
                    node.Prev.Next = node.Next;
                    node.Next.Prev = node.Prev;
                }
            }
        }
        else
        {
            if (head is null)
            {
                var node = new DoublyLinkedList(1);
                node.Keys.Add(key);
                map.Add(key, node);
                head = tail = node;
            }
            else if (head.Value == 1)
            {
                map.Add(key, head);
                head.Keys.Add(key);
            }
            else
            {
                var node = new DoublyLinkedList(1);
                node.Keys.Add(key);
                map.Add(key, node);
                node.Next = head;
                head.Prev = node;
                head = node;
            }
        }
    }

    public void Dec(string key)
    {
        var node = map[key];
        node.Keys.Remove(key);

        if (node.Value == 1)
        {
            map.Remove(key);
        }
        else if (node.Prev is null)
        {
            var newNode = new DoublyLinkedList(node.Value - 1);
            newNode.Keys.Add(key);
            map[key] = newNode;
            newNode.Next = node;
            node.Prev = newNode;
            head = newNode;
        }
        else if (node.Prev.Value == node.Value - 1)
        {
            node.Prev.Keys.Add(key);
            map[key] = node.Prev;
        }
        else
        {
            var newNode = new DoublyLinkedList(node.Value - 1);
            newNode.Keys.Add(key);
            map[key] = newNode;
            node.Prev.Next = newNode;
            newNode.Prev = node.Prev;
            newNode.Next = node;
            node.Prev = newNode;
        }

        if (node.Keys.Count == 0)
        {
            if (node.Next is null && node.Prev is null)
            {
                head = tail = null;
            }
            else if (node.Next is null)
            {
                node.Prev.Next = null;
                tail = node.Prev;
            }
            else if (node.Prev is null)
            {
                node.Next.Prev = null;
                head = node.Next;
            }
            else
            {
                node.Next.Prev = node.Prev;
                node.Prev.Next = node.Next;
            }
        }
    }

    public string GetMaxKey()
    {
        if (tail is null) return "";
        return tail.Keys.First();
    }

    public string GetMinKey()
    {
        if (head is null) return "";
        return head.Keys.First();
    }
}
public class AllOne
{
    private Dictionary<string, int> frequency;
    private List<HashSet<string>> dp;
    private int minFrequency;

    public AllOne()
    {
        frequency = [];
        dp = [];
        minFrequency = 0;
    }

    public void Inc(string key)
    {
        if (frequency.ContainsKey(key))
        {
            if (frequency[key] >= dp.Count)
            {
                dp.Add([]);
            }

            dp[frequency[key]].Add(key);
            dp[frequency[key] - 1].Remove(key);
            frequency[key]++;

            if (dp[minFrequency].Count == 0)
            {
                minFrequency++;
            }

            return;
        }

        if (dp.Count == 0)
        {
            dp.Add([]);
        }

        frequency.Add(key, 1);
        dp[0].Add(key);
        minFrequency = 0;
    }

    public void Dec(string key)
    {
        if (!frequency.ContainsKey(key)) return;

        frequency[key]--;
        dp[frequency[key]].Remove(key);
        if (dp[^1].Count == 0)
        {
            dp.RemoveAt(dp.Count - 1);
        }

        if (frequency[key] == 0)
        {
            frequency.Remove(key);
            while (minFrequency < dp.Count && dp[minFrequency].Count == 0)
            {
                minFrequency++;
            }
        }
        else
        {
            dp[frequency[key] - 1].Add(key);
            minFrequency = int.Min(frequency[key] - 1, minFrequency);
        }
    }

    public string GetMaxKey()
    {
        if (dp.Count == 0) return "";
        return dp[^1].FirstOrDefault("");
    }

    public string GetMinKey()
    {
        if (dp.Count == 0) return "";
        return dp[minFrequency].FirstOrDefault("");
    }
}

public class Solution
{
    public List<string> Execute(string[] events, string[][] values)
    {
        List<string> result = [];
        AllOne_Second allOne = new();
        for (int i = 0; i < events.Length; i++)
        {
            switch (events[i])
            {
                case "AllOne":
                    allOne = new AllOne_Second();
                    result.Add("null");
                    break;
                case "inc":
                    allOne.Inc(values[i][0]);
                    result.Add("null");
                    break;
                case "dec":
                    allOne.Dec(values[i][0]);
                    result.Add("null");
                    break;
                case "getMaxKey":
                    result.Add(allOne.GetMaxKey());
                    break;
                case "getMinKey":
                    result.Add(allOne.GetMinKey());
                    break;
            }
        }
        return result;
    }
}

/**
 * Your AllOne object will be instantiated and called as such:
 * AllOne obj = new AllOne();
 * obj.Inc(key);
 * obj.Dec(key);
 * string param_3 = obj.GetMaxKey();
 * string param_4 = obj.GetMinKey();
 */