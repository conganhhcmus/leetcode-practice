public class Solution {
    public bool FindRotation(int[][] mat, int[][] target) {
        for(int i = 0;i<4;i++){
            Rotate(mat);
            if (IsSame(mat, target)) return true;
        }
        return false;
    }

    void Rotate(int[][] mat){
        int n = mat.Length;
        // [x, x, y, x]
        // [y, x, x, x]
        // [x, x, x, y]
        // [x, y, x, x]
        for(int i = 0;i<n/2;i++){
            for(int j = i;j<n-i-1;j++){
                int tmp = mat[i][j];
                mat[i][j] = mat[n-1-j][i];
                mat[n-1-j][i] = mat[n-1-i][n-1-j];
                mat[n-1-i][n-1-j] = mat[j][n-1-i];
                mat[j][n-1-i] = tmp;
            }
        }
    }

    bool IsSame(int[][] mat, int[][] tar){
        int n = mat.Length;
        for(int i = 0;i<n;i++){
            for(int j = 0;j<n;j++){
                if (mat[i][j] != tar[i][j]) return false;
            }
        }
        return true;
    }
}