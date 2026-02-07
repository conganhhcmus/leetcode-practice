public class Solution
{
    public int MaxSumDivThree(int[] nums)
    {
        int[] mod = new int[3];
        foreach (int num in nums)
        {
            int[] mod2 = new int[3];
            Array.Copy(mod, mod2, 3);
            foreach (int val in mod)
            {
                int nVal = val + num;
                int nMod = nVal % 3;
                mod2[nMod] = Math.Max(mod2[nMod], nVal);
            }
            mod = mod2;
        }
        return mod[0];
    }
}