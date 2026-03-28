public class Solution {
    int[] parent;

    int Find(int x){
        if (parent[x] == x) return x;
        return parent[x] = Find(parent[x]);
    }

    bool Union(int x, int y){
        int pX = Find(x), pY = Find(y);
        if (pX == pY) return false;
        if (pX < pY){
            parent[pY] = pX;
        } else {
            parent[pX] = pY;
        }
        return true;
    }

    public string FindTheString(int[][] lcp) {
        int n = lcp.Length;
        parent = new int[n];
        for(int i = 0;i<n;i++){
            parent[i] = i;
        }
        // lcp[i][j] = longest common prefix of substr word[i..n-1] & word[j..n-1]
        // lcp[n-1][n-1] = 0;
        // lcp[i][i] = n - i
        // lcp[i][j] = lcp[j][i]
        // lcp[i][j] = x => word[i] == word[j], .. word[i-x] == word[j-x]

        for(int i = n-1;i>=0;i--){
            if (lcp[i][i] != n - i) return string.Empty;
            for(int j = i - 1;j>=0;j--){
                if (lcp[i][j] > n - i) return string.Empty;
                if (lcp[i][j] != lcp[j][i]) return string.Empty;
                for(int k = 0; k < lcp[i][j]; k++){
                    Union(i + k, j + k);
                }
                if (i + lcp[i][j] < n) {
                    if (Find(i + lcp[i][j]) == Find(j + lcp[i][j])) return string.Empty;
                }
            }
        }

        for(int i = n-1;i>=0;i--){
            for(int j = i-1;j>=0;j--){
                if (lcp[i][j] == 0 && Find(i) == Find(j)) return string.Empty;
            }
        }

        char[] arr = new char[n];
        Dictionary<int, char> map = [];
        char c = 'a';
        map[0] = c;
        for(int i = 0;i<n;i++){
            int p = Find(i);
            if (!map.ContainsKey(p)){
                c++;
                map[p] = c;
            }
            if (c > 'z') return string.Empty;
            arr[i] = map[p];
        }
        return new(arr);
    }
}