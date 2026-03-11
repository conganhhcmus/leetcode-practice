public class Solution
{
    public string RemoveDuplicates(string s)
    {
        char[] arr = s.ToCharArray();
        int n = s.Length;
        int j = 0;
        for (int i = 0; i < n; i++)
        {
            arr[j] = arr[i];
            if (j > 0 && arr[i] == arr[j - 1])
            {
                j--;
            }
            else j++;
        }

        return new string(arr, 0, j);
    }
}