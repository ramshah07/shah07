using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codelity
{
    public static class TimeComplexity
    {
        public static void TimeComplexMethod()
        {
            DiskIntersection();
            Traingle();
            GetCountersAfterApplyingOperations();
            PermCheck();
            TapeEquilribrium();
        }

        private static void TapeEquilribrium()
        {
            int[] A = { 3, 1, 2, 4, 3 };
            // 3 4 6 10
            // 10 9 7 3
            int minvalue = 0;
            int[] result = new int[A.Length - 1];
            int temp = int.MaxValue; int first = 0; int second = 0;
            for (int i = 0; i < A.Length - 1; i++)
            {
                second = 0;
                first = first + A[i];
                for (int j = i + 1; j < A.Length; j++)
                {
                    if (i != j)
                    {
                        second = second + A[j];
                    }
                }
                result[i] = Convert.ToInt32((second - first).ToString().Trim('-'));
                temp = Math.Min(temp, result[i]);
            }

        }
        private static int PermCheck()
        {
            int s = Math.Abs(-2);
            int[] A = { 4, 1, 3, 2 };
            int[] mark = new int[A.Length + 1];
            int temp = 0;
            for (int i = 0; i < A.Length - 1; i++)
            {
                temp = A[i];
                if (temp > mark.Length)
                    return 0;
                else if (mark[temp] == 0)
                    mark[temp] = 1;
                else
                    return 0;
            }
            return 1;

        }
        public static int[] GetCountersAfterApplyingOperations()
        {
            int[] A = { 3, 4, 4, 6, 1, 4, 4 };
            int N = 5;
            //array of counters
            int[] countersArr = new int[N];
            //<max> is the largest value found in <countersArr>
            int max = 0;
            int index;
            //when <N> is found in <A[]>, means all counters have to be set to <max>
            int setAllCountersOp = N;
            //<floor> stores the value of <max> when a <setAllCountersOp> is found in <A[]>
            int floor = 0;
            for (int i = 0; i < A.Length; i++)
            {
                //As A[i] = 1, should convert <countersArr>={0} to {1}, then
                index = A[i] - 1;

                //if <index> == <setAllCountersOp> then the new <floor> = <max>
                if (index == setAllCountersOp)
                {
                    floor = max;
                }
                //If 0 <= index < N, then the counterArr[index] should be incremented
                else if (index < N && index >= 0)
                {
                    //if <setAllCountersOp> was found, no counter can be smaller than <floor>
                    if (countersArr[index] < floor)
                    {
                        countersArr[index] = floor + 1;
                    }
                    else
                    {
                        ++countersArr[index];
                    }
                    if (countersArr[index] > max)
                    {
                        ++max;
                    }
                }
            }
            //if counter is smaller than <floor>, it is set to that value.
            for (int i = 0; i < countersArr.Length; i++)
            {
                if (countersArr[i] < floor)
                {
                    countersArr[i] = floor;
                }
            }
            return countersArr;
        }
        public static int Traingle()
        {
            int[] A = { int.MaxValue, int.MaxValue, int.MaxValue };
            if (A.Length <= 3)
                return 0;
            Array.Sort(A);

            for (int i = 0; i < A.Length - 2; i++)
            {
                if (A[i] + A[i + 1] > A[i + 2])
                {
                    return 1;
                    break;
                }
                if (A[i] == A[i + 2] &&
           A[i + 2] == A[i + 1] &&
           A[i] == Int32.MaxValue)
                {
                    return 1;
                    break;
                }
            }
            return 0;
        }
        public static int DiskIntersection()
        {
            int[] A = { 1, 5, 2, 1, 4, 0 };
            int N = A.Length;
            long[] AX = new long[N];
            long[] AY = new long[N];

            for (int i = 0; i < N; i++)
            {
                AX[Math.Max(0, i - A[i])]++;
                AY[Math.Min(N - 1, i + A[i])]++;
            }
            long result = 0;
            long discsAtIndex = 0;
            for (int i = 0; i < N; i++)
            {
                if (AX[i] > 0)
                {
                    result += discsAtIndex * AX[i] + (AX[i] * (AX[i] - 1) / 2);

                    discsAtIndex += AX[i];
                }
                discsAtIndex -= AY[i];
            }
            if (result <= 10000000)
                return (int)result;
            else return -1;
        }


    }
}
