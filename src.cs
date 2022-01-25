class Solution {
    public int solve(List<int> A, int B) {
        int N = A.Count();
        List<int> pfSum = new List<int>();
        List<int> sfSum = new List<int>();
        int sum = 0;
        for(int i = 0; i < N; i++){
            sum =  sum + A[i];
            pfSum.Add(sum);
        }
        sum = 0;

        for(int i = N-1; i >= 0; i--){
            sum =  sum + A[i];
            sfSum.Add(sum);
        }
        
        sfSum = reverse(sfSum, 0, N-1);

        int ans = int.MinValue;
        for(int i = 0; i <= B; i++){
            sum = 0;
            int s = 0;
            if(i < B){
                s = sfSum[(N-B+i)%N];
            }

            sum = (i == 0 ? 0 : pfSum[i-1]) + s;
            ans = Max(ans, sum);
        }

        return ans;
    }

    public List<int> reverse(List<int> arr, int s, int e){
        while(s < e){
            int temp = -1;

            temp = arr[s];
            arr[s] = arr[e];
            arr[e] = temp;

            s++;
            e--;
        }
        return arr;
    }

    public int Max(int a, int b){
        if (a >= b)
            return a;
        else
            return b;
    }
}
