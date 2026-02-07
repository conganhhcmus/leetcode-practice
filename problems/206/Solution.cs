public class Solution
{
    public ListNode ReverseList(ListNode head)
    {
        if (head is null || head.next is null) return head;

        var cloneHead = head;
        ListNode resHead = head;
        ListNode prevNode = null;

        while (cloneHead.next is not null)
        {
            resHead = cloneHead;
            cloneHead = cloneHead.next;

            resHead.next = prevNode;
            prevNode = resHead;
            resHead = cloneHead;
        }

        resHead.next = prevNode;

        return resHead;
    }
}