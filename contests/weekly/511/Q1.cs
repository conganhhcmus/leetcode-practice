public class Solution
{
    public bool CanReach(int[] start, int[] target)
    {
        int diff = target[0] - start[0] + target[1] - start[1];
        return diff % 2 == 0;
    }
}
