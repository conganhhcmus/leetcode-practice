public class Solution
{
    public bool CanWinNim(int n)
    {
        // base for 4, you turn if divide by 4 alway lose
        // 12 -> 8 -> 4 -> 0
        // if you chose 1, your friend chose 3
        // if you chose 2, your friend chose 2
        // if you chose 3, your friend chose 1
        return n % 4 != 0;
    }
}