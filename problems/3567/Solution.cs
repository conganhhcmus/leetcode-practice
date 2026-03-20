public class Solution {
    public int[][] MinAbsDiff(int[][] grid, int k) {
        int m = grid.Length, n = grid[0].Length;
        int[][] ans = new int[m-k+1][];
        for(int i = 0;i<m-k+1;i++){
            ans[i] = new int[n-k+1];
        }
        for(int i = 0;i<m-k+1;i++){
            for(int j = 0;j<n-k+1;j++){
                ans[i][j] = Calc(grid, k, i, j);
            }
        }
        return ans;
    }

    int Calc(int[][] grid, int k, int x, int y){
        List<int> arr = [];
        for(int i = 0;i<k;i++){
            for(int j = 0;j<k;j++){
                arr.Add(grid[x+i][y+j]);
            }
        }
        arr.Sort((a,b)=>a-b);
        int INF = int.MaxValue;
        int ans = INF;
        for(int i = 1;i<arr.Count;i++){
            if (arr[i] == arr[i-1]) continue;
            ans = Math.Min(ans, arr[i] - arr[i-1]);
        }
        if (ans == INF) return 0;
        return ans;
    }
}