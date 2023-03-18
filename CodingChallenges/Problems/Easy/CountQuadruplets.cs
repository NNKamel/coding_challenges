/*
1995. Count Special Quadruplets
https://leetcode.com/problems/count-special-quadruplets/
Given a 0-indexed integer array nums, return the number of distinct quadruplets (a, b, c, d) such that:

nums[a] + nums[b] + nums[c] == nums[d], and
a < b < c < d
 

Example 1:

Input: nums = [1,2,3,6]
Output: 1
Explanation: The only quadruplet that satisfies the requirement is (0, 1, 2, 3) because 1 + 2 + 3 == 6.
Example 2:

Input: nums = [3,3,6,4,5]
Output: 0
Explanation: There are no such quadruplets in [3,3,6,4,5].
Example 3:

Input: nums = [1,1,1,3,5]
Output: 4
Explanation: The 4 quadruplets that satisfy the requirement are:
- (0, 1, 2, 3): 1 + 1 + 1 == 3
- (0, 1, 3, 4): 1 + 1 + 3 == 5
- (0, 2, 3, 4): 1 + 1 + 3 == 5
- (1, 2, 3, 4): 1 + 1 + 3 == 5
 

Constraints:

4 <= nums.length <= 50
1 <= nums[i] <= 100
*/
using System.Numerics;
using Problems.Common;
using u = Utils.Methods;

namespace Problems
{
    public class CountQuadruplets : CodingProblem<int[], int>
    {
        internal override void AssignOtherInputs()
        {
            this.otherInputs = "";
            // this.otherInputs = "-294967296";
        }

        internal override void FillArray()
        {
            this.inputs = new List<int[]>()
            {
                // new int[] {1,2,3,6},
                // new int[] {3,3,6,4,5},
                new int[] {1,1,1,3,5},
            };
        }

        internal override void NameProblem()
        {
            this.problemName = "Count Special Quadruplets";
        }

        internal override void FillCorrectResults()
        {
            this.correctResults = new List<int>()
            {
                // 1,
                // 0,
                4,
            };
        }

        internal override int psolve(int[] inputs, string secondary)
        {
            return CountQuadrupletsAnswer(inputs);
        }

        private int CountQuadrupletsAnswer(int[] arr)
        {
            // sort array
            // loop on array
            // define right = i+1, left = size-2, total = size-1
            // while (left < right& right < total) {
            // while (left < right)
            //      if (arr[i] + arr[left] + arr[right] < total) left++;
            //      if (arr[i] + arr[left] + arr[right] > total) right--;
            //      else {
            //          results++;
            //          left++; right--;
            //      }
            //  total--; right = total-1;
            //  }

            int size = arr.Length;
            int results = 0;

            var countSums = new Dictionary<int, int>();

            // [1, 1, 1, 3, 5]
            //     j  i         count = { {} }
            // [1, 1, 1, 3, 5]
            //        i     k   count = { {4: 1} } (-(1-5)=4)
            // [1, 1, 1, 3, 5]
            //        i  k      count = { {4: 1} {2: 1} } ((3-1)=2)
            // [1, 1, 1, 3, 5]
            //  j  i            count = { {0: 1} {4: 1} {2: 1} } ((1+1)=2) results=1
            // [1, 1, 1, 3, 5]
            //  j     i         count = { {0: 1} {4: 1} {2: 1} } ((1+1)=2) results=2
            // [1, 1, 1, 3, 5]
            //        i     k   count = { {0: 1} {4: 1} {2: 1} {3: 1} } (-(1-1)=0) results=2
            // [1, 1, 1, 3, 5]
            //        i  k      count = { {0: 1} {4: 1} {2: 2} {3: 1} } (-(1-1)=0) results=2
            // [1, 1, 1, 3, 5]
            //        j  i      count = { {0: 1} {4: 1} {2: 2} {3: 1} } ((3+1)=4)  results=3
            // [1, 1, 1, 3, 5]
            //     j     i      count = { {0: 1} {4: 1} {2: 2} {3: 1} } ((3+1)=4)  results=4

            for (int i = size - 2; i >= 1; i--)
            {
                for (int j = i - 1; j >= 0; j--)
                {
                    u.print($"js - arr[{i}]: {arr[i]} | arr[{j}]: {arr[j]} ({arr[i]} + {arr[j]} = {arr[i] + arr[j]})");
                    results += countSums.GetValueOrDefault(arr[j] + arr[i], 0);
                }

                for (int k = size - 1; k >= i; k--)
                {
                    u.print($"ks - arr[{i}]: {arr[i]} | arr[{k}]: {arr[k]} ({arr[k]} - {arr[i]} = {arr[k] - arr[i]})");
                    countSums[-(arr[i] - arr[k])] = countSums.GetValueOrDefault(-(arr[i] - arr[k]), 0) + 1;
                }
                u.d(countSums, "countSums");
            }

            return results;
        }
    }
}