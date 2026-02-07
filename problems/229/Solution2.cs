public class Solution
{
    public IList<int> MajorityElement(int[] nums)
    {
        int c1 = 0, c2 = 0;
        int cn1 = 0, cn2 = 0;
        foreach (int num in nums)
        {
            if (num == c1) cn1++;
            else if (num == c2) cn2++;
            else if (cn1 == 0)
            {
                c1 = num;
                cn1 = 1;
            }
            else if (cn2 == 0)
            {
                c2 = num;
                cn2 = 1;
            }
            else
            {
                cn1--;
                cn2--;
            }
        }
        cn1 = cn2 = 0;
        foreach (int num in nums)
        {
            if (num == c1) cn1++;
            else if (num == c2) cn2++;
        }

        int threshold = nums.Length / 3;
        IList<int> ret = [];
        if (cn1 > threshold) ret.Add(c1);
        if (cn2 > threshold) ret.Add(c2);
        return ret;
    }
}