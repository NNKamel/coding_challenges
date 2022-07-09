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
    public class ThreeSumClosest : CodingProblem<int[], int> // where T : [] where G : List<int>
    {
        internal override void AssignOtherInputs()
        {
            // this.otherInputs = "1,1,-2";
            this.otherInputs = "-2";
        }

        internal override void FillArray()
        {
            this.inputs = new List<int[]>()
            {
                // new int[] { 2, 2, -1, -1, -1, 3, -2 },
                // new int[] {-1,0,1,2,-1,-4},
                // new int[] {-1,2,1,-4},
                // new int[] {0,0,0},
                new int[] {4,0,5,-5,3,3,0,-4,-5},
            };
        }

        internal override void NameProblem()
        {
            this.problemName = "3Sum Closest";
        }

        internal override void FillCorrectResults()
        {
            this.correctResults = new List<int>()
            {
                // 2, 0, -2
                 -2
            };
        }

        // public override void Solve()
        // {
        //     base.Solve();
        //     // var targets = this.otherInputs.Split(",").Select(t => Int32.Parse(t));
        //     // var allInputs = this.otherInputs.Zip(this.inputs, (e, s) => new { arr = s, t = e });
        //     // foreach (var input in allInputs)
        //     // {
        //     //     ThreeSumClosestAnswer(input.arr, input.t);
        //     // }
        // }

        internal override int psolve(int[] arr, string secondary)
        {
            return ThreeSumClosestAnswer(arr, Int32.Parse(secondary));
        }

        int ThreeSumClosestAnswer(int[] arr, int target)
        {
            StartMergeSort(arr);
            var closestSum = Int32.MaxValue;
            var size = arr.Length;

            // loop on sorted arr
            // if number is the same as previous, continue
            // let right = size-1, left = i+1
            // while (left < right)
            //      let sum = arr[i] + arr[left] + arr[right]
            //      if (closestSum > (|sum - target|)) closestSum = sum;
            //      if (|sum-target| > target) right--
            //      else if (|sum-target| < target) left++
            //      else return sum
            //      while (left < right && arr[left]==arr[left+1]) left++;
            //      while (left < right && arr[right]==arr[right-1]) right--;
            //      left++; right--;

            for (int i = 0; i < size; i++)
            {
                if (i > 0 && arr[i] == arr[i - 1]) continue;
                var right = size - 1;
                var left = i + 1;
                // u.print($"left: {left} | right: {right}");
                while (left < right)
                {
                    var sum = arr[i] + arr[left] + arr[right];
                    var sumDiff = Math.Abs(sum - target);
                    var cSumDiff = Math.Abs(closestSum - target);
                    // u.print($"sum: {sum} | closestSum: {closestSum} diff: {diff}");
                    if (cSumDiff > sumDiff) closestSum = sum;
                    if (sum < target) left++;
                    else if (sum > target) right--;
                    else return closestSum;
                    // while (left < right && arr[left] == arr[left + 1]) left++;
                    // while (left < right && arr[right] == arr[right - 1]) right--;
                }
            }

            // u.print($"output: {closestSum}");
            return closestSum;
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