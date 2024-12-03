namespace Problem_27;
public class Solution
{
    public int RemoveElement(int[] nums, int val)
    {
        int[] tmp = [.. nums];
        int k = 0;
        for (int i = 0; i < tmp.Length; i++)
        {
            if (tmp[i] != val)
            {
                nums[k] = tmp[i];
                k++;
            }
        }
        return k;
    }
}