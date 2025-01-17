namespace Helpers;

public static class NodeHelper
{
    public static Node CreateFromArray(int?[][] nums)
    {
        Node dummy = new(0);
        Node current = dummy;
        List<(Node node, int? random)> tmp = [];

        foreach (var num in nums)
        {
            int? val = num[0], random = num[1];
            tmp.Add((new Node(val.GetValueOrDefault()), random));
            current.next = tmp[^1].node;
            current = current.next;
        }

        foreach (var (node, random) in tmp)
        {
            if (random is null) continue;
            node.random = tmp.ElementAt(random.GetValueOrDefault()).node;
        }

        return dummy.next;
    }

    public static string Print(Node head)
    {
        List<Node> tmp = [];
        Node current = head;
        while (current is not null)
        {
            tmp.Add(current);
            current = current.next;
        }
        List<int?[]> vals = [];
        while (head is not null)
        {
            int index = tmp.IndexOf(head.random);
            vals.Add([head.val, index == -1 ? null : index]);
            head = head.next;
        }

        return JsonConvert.SerializeObject(vals);
    }
}