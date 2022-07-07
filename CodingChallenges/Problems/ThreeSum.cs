/*
15. 3Sum
https://leetcode.com/problems/3sum/
Given an integer array nums, return all the triplets [nums[i], nums[j], nums[k]] such that i != j, i != k, and j != k, and nums[i] + nums[j] + nums[k] == 0.

Notice that the solution set must not contain duplicate triplets.

 

Example 1:

Input: nums = [-1,0,1,2,-1,-4]
Output: [[-1,-1,2],[-1,0,1]]
Example 2:

Input: nums = []
Output: []
Example 3:

Input: nums = [0]
Output: []
 

Constraints:

0 <= nums.length <= 3000
-105 <= nums[i] <= 105
*/
using Problems.Common;
using u = Utils.Methods;

namespace Problems
{
    public class ThreeSum : CodingProblem
    {
        internal override void AssignOtherInputs()
        {

        }

        internal override void FillArray()
        {
            this.inputs = new List<int[]>()
            {
                new int[] { 2, 2, -1, -1, -1, 3, -2 },
                new int[] {-1,0,1,2,-1,-4}
            };
        }

        internal override void NameProblem()
        {
            this.problemName = "3Sum";
        }

        internal override void FillCorrectResults()
        {
            this.correctResults = new List<object>()
            {
                new List<List<int>>()
                {
                    new List<int>() {-2,-1,3},
                    new List<int>() {-1,-1,2},
                },
                new List<List<int>>()
                {
                    new List<int>() {-1,-1,2},
                    new List<int>() {-1,0,1},
                },
            };
        }

        // public override void Solve()
        // {
        //     base.Solve();
        //     foreach (var input in this.inputs)
        //     {
        //         ThreeSumAnswer(input);
        //     }
        // }
        internal override object psolve(int[] arr, string secondary)
        {
            return ThreeSumAnswer(arr);
        }

        List<List<int>> ThreeSumAnswer(int[] arr)
        {
            u.WriteArr(arr, "before");
            StartMergeSort(arr);
            u.WriteArr(arr, "after");

            var resultList = new List<List<int>>();

            int size = arr.Length;
            for (int i = 0; i < size; i++)
            {
                if (i > 0 && arr[i] == arr[i - 1]) continue;

                var left = i + 1;
                var right = size - 1;

                while (left < right)
                {
                    var csum = arr[i] + arr[left] + arr[right];
                    if (csum < 0) left++;
                    else if (csum > 0) right--;
                    else
                    {
                        resultList.Add(new List<int> { arr[i], arr[left], arr[right] });
                        while (left < right && arr[left] == arr[left + 1]) left++;
                        while (left < right && arr[right] == arr[right - 1]) right--;
                        left++; right--;
                    }
                }
            }

            u.d(resultList, "resultList");
            return resultList;
            // sort the array
            // loop on array
            // unnecessary - if number is the same as before, continue 
            // let left = i+1 and right = size - 1
            // while (left < right)
            //      let sum = arr[i] + arr[left] + arr[right]
            //      if (sum > 0) right--;
            //      else if (sum < 0) left++;
            //      else add i, left, right to result list
            //          while (left < right && arr[left] == arr[left+1]) left++
            //          while (left < right && arr[right] == arr[right+1]) right--
            //          left++; right--;


            // [2, 2, -1, -1, -1, 3, -2]
            // [-2, -1, -1, -1, 2, 2, 3]
            //  i   l                 r -- sum = 0
            // [-2, -1, -1, -1, 2, 2, 3]
            //  i   l                 r -- sum = 0
            //  i       l             r -- sum = 0
            //  i            l        r -- sum = 0
            //  i               l  r    -- sum = 2
            //     
        }

        void StartMergeSort(int[] arr)
        {
            MergeSort(arr, 0, arr.Length - 1);
        }

        void MergeSort(int[] arr, int s, int e)
        {
            // s = 3
            // e = 7
            if (s >= e)
            {
                return;
            }
            // u.print($"MergeSort - s: {s} | e: {e}");
            int m = (s + e) / 2;
            // u.print($"MergeSort - m: {m}");
            MergeSort(arr, s, m); // (3,5-1) (3,4)
            MergeSort(arr, m + 1, e);   // (5,7)
            // u.print($"MergeSort - s: {s} | m: {m} | e: {e}");
            Merge(arr, s, m, e);
        }

        void Merge(int[] arr, int s, int m, int e)
        {
            // [0, 2, 5, 6, 7, 2, 3, 4, 7, 8]
            //  0  1  2  3  4  5  6  7  8  9
            // s = 3
            // m = 5
            // e = 7
            // u.print($"s: {s} | m: {m} | e: {e}");
            int s1 = m - s + 1;
            int s2 = e - m;
            // u.print($"s1: {s1}");
            // u.print($"s2: {s2}");
            // s1 = 5-3=2
            // s2 = 7-5+1=3

            int[] arr1 = new int[s1];
            int[] arr2 = new int[s2];

            for (int i = 0; i < s1; i++)
            { // s+s1 = 3+2 = 5
                // u.print($"i: {i} | s: {s} | i + s: {i + s}");
                arr1[i] = arr[i + s];
            }

            for (int i = 0; i < s2; i++)
            { // m+s2 = 5+3 = 8
                arr2[i] = arr[m + i + 1];
            }

            int i1 = 0;
            int i2 = 0;
            int ai = s;
            while (i1 < s1 && i2 < s2)
            {
                if (arr1[i1] < arr2[i2])
                {
                    arr[ai] = arr1[i1];
                    i1++;
                }
                else
                {
                    arr[ai] = arr2[i2];
                    i2++;
                }

                ai++;
            }

            while (i1 < s1)
            {
                arr[ai] = arr1[i1];
                i1++;
                ai++;
            }

            while (i2 < s2)
            {
                arr[ai] = arr2[i2];
                i2++;
                ai++;
            }
        }
    }
}