public class Solution
{
    public int CountOdds(int low, int high)
    {
        // count odd from [0..high]
        int ans = (high + 1) >> 1;
        // count odd from [0..(low-1)]
        ans -= low >> 1;
        return ans;
    }
}