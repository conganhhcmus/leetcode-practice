/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */
public class Solution
{
    public bool IsPalindrome(ListNode head)
    {
        StringBuilder sb = new();
        while (head != null)
        {
            sb.Append(head.val);
            head = head.next;
        }
        int n = sb.Length;
        for (int i = 0; i <= n / 2; i++)
        {
            if (sb[i] != sb[n - i - 1]) return false;
        }
        return true;
    }
}