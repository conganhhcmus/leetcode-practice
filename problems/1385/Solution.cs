public class Solution
{
    public int FindTheDistanceValue(int[] arr1, int[] arr2, int d)
    {
        // count the number of element in arr1 where |arr1[i] - arr2[j]| > d
        int ans = 0;
        foreach (int x in arr1)
        {
            bool isValid = true;
            foreach (int y in arr2)
            {
                if (Math.Abs(x - y) <= d)
                {
                    isValid = false;
                    break;
                }
            }
            if (isValid) ans++;
        }
        return ans;
    }
}