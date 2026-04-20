public class Solution
{
    public string ReverseByType(string s)
    {
        char[] arr = s.ToCharArray();
        int n = arr.Length;
        List<int> idx = [];
        List<int> idx2 = [];
        for (int i = 0; i < n; i++)
        {
            if (arr[i] >= 'a' && arr[i] <= 'z')
            {
                idx.Add(i);
            }
            else
            {
                idx2.Add(i);
            }
        }
        for (int i = 0; i < idx.Count / 2; i++)
        {
            (arr[idx[i]], arr[idx[idx.Count - 1 - i]]) = (arr[idx[idx.Count - 1 - i]], arr[idx[i]]);
        }

        for (int i = 0; i < idx2.Count / 2; i++)
        {
            (arr[idx2[i]], arr[idx2[idx2.Count - 1 - i]]) = (arr[idx2[idx2.Count - 1 - i]], arr[idx2[i]]);
        }
        return new(arr);
    }
}
