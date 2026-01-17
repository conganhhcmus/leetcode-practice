#if DEBUG
namespace Problems_2975;
#endif

public class Solution {
    public int MaximizeSquareArea(int m, int n, int[] hFences, int[] vFences) {
        int mod = (int)1e9+7;
        long ans = -1;
        hFences = [1, ..hFences, m];
        vFences = [1, ..vFences, n];
        Array.Sort(hFences);
        Array.Sort(vFences);
        List<int>hDiff = [];
        for(int i = 0;i<hFences.Length-1;i++){
            hDiff.Add(hFences[i+1] - hFences[i]);
        }
        List<int>vDiff = [];
        for(int i = 0;i<vFences.Length-1;i++){
            vDiff.Add(vFences[i+1]-vFences[i]);
        }
        HashSet<long> seen = [];
        for(int i = 0;i<hDiff.Count;i++){
            long sum = 0;
            for(int j = i;j<hDiff.Count;j++){
                sum+= hDiff[j];
                seen.Add(sum);
            }
        }

        for(int i = 0;i<vDiff.Count;i++){
            long sum = 0;
            for(int j = i;j<vDiff.Count;j++){
                sum+=vDiff[j];
                if (seen.Contains(sum)){
                    ans = Math.Max(ans ,sum);
                }
            }
        }
        if (ans == -1) return -1;
        return (int)(ans * ans % mod);
    }
}