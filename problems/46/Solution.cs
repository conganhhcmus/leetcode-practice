public class Solution
{
    public IList<IList<int>> Permute(int[] nums)
    {
        IList<IList<int>> ans = [];
        bool[] visited = new bool[nums.Length];
        BackTracking(0, nums, [], visited, ans);
        return ans;
    }

    void BackTracking(int i, int[] nums, IList<int> permutation, bool[] visited, IList<IList<int>> ans)
    {
        if (i == nums.Length)
        {
            ans.Add([.. permutation]);
            return;
        }
        for (int j = 0; j < nums.Length; j++)
        {
            if (visited[j]) continue;
            visited[j] = true;
            permutation.Add(nums[j]);
            BackTracking(i + 1, nums, permutation, visited, ans);
            permutation.RemoveAt(permutation.Count - 1); // backtrack
            visited[j] = false;
        }
    }
}