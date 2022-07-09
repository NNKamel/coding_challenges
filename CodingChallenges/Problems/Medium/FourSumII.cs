/*
454. 4Sum II
https://leetcode.com/problems/4sum-ii/
Given an array nums of n integers, return an array of all the unique quadruplets [nums[a], nums[b], nums[c], nums[d]] such that:

0 <= a, b, c, d < n
a, b, c, and d are distinct.
nums[a] + nums[b] + nums[c] + nums[d] == target
You may return the answer in any order.

 

Example 1:

Input: nums = [1,0,-1,0,-2,2], target = 0
Output: [[-2,-1,1,2],[-2,0,0,2],[-1,0,0,1]]
Example 2:

Input: nums = [2,2,2,2,2], target = 8
Output: [[2,2,2,2]]
 

Constraints:

1 <= nums.length <= 200
Given an array nums of n integers, return an array of all the unique quadruplets [nums[a], nums[b], nums[c], nums[d]] such that:

0 <= a, b, c, d < n
a, b, c, and d are distinct.
nums[a] + nums[b] + nums[c] + nums[d] == target
You may return the answer in any order.

 

Example 1:

Input: nums = [1,0,-1,0,-2,2], target = 0
Output: [[-2,-1,1,2],[-2,0,0,2],[-1,0,0,1]]
Example 2:

Input: nums = [2,2,2,2,2], target = 8
Output: [[2,2,2,2]]
 

Constraints:

1 <= nums.length <= 200
Given four integer arrays nums1, nums2, nums3, and nums4 all of length n, return the number of tuples (i, j, k, l) such that:

0 <= i, j, k, l < n
nums1[i] + nums2[j] + nums3[k] + nums4[l] == 0
 

Example 1:

Input: nums1 = [1,2], nums2 = [-2,-1], nums3 = [-1,2], nums4 = [0,2]
Output: 2
Explanation:
The two tuples are:
1. (0, 0, 0, 1) -> nums1[0] + nums2[0] + nums3[0] + nums4[1] = 1 + (-2) + (-1) + 2 = 0
2. (1, 1, 0, 0) -> nums1[1] + nums2[1] + nums3[0] + nums4[0] = 2 + (-1) + (-1) + 0 = 0
Example 2:

Input: nums1 = [0], nums2 = [0], nums3 = [0], nums4 = [0]
Output: 1
 

Constraints:

n == nums1.length
n == nums2.length
n == nums3.length
n == nums4.length
1 <= n <= 200
-228 <= nums1[i], nums2[i], nums3[i], nums4[i] <= 228
*/
using System.Numerics;
using Problems.Common;
using u = Utils.Methods;

namespace Problems
{
    public class FourSumII : CodingProblem<List<int[]>, int>
    {
        internal override void AssignOtherInputs()
        {
            this.otherInputs = "";
            // this.otherInputs = "-294967296";
        }

        internal override void FillArray()
        {
            this.inputs = new List<List<int[]>>()
            {
                new List<int[]>()
                {
                    new int[] {1,2},
                    new int[] {-2,-1},
                    new int[] {-1,2},
                    new int[] {0,2},
                },
                new List<int[]>()
                {
                    new int[] {0},
                    new int[] {0},
                    new int[] {0},
                    new int[] {0},
                },
            };
        }

        internal override void NameProblem()
        {
            this.problemName = "4Sum II";
        }

        internal override void FillCorrectResults()
        {
            this.correctResults = new List<int>()
            {
                2,
                0
            };
        }

        internal override int psolve(List<int[]> inputs, string secondary)
        {
            List<int[]> arrays = inputs;
            return FourSumIIAnswer(arrays[0], arrays[1], arrays[2], arrays[3]);
        }

        private int FourSumIIAnswer(int[] arr1, int[] arr2, int[] arr3, int[] arr4)
        {
            // loop on first 2 arrays, store all N^2 sums in dictionary
            // loop on second 2 arrays, check against all N^2 keys - this sum = 0;

            var results = 0;
            var countSums = new Dictionary<int, int>();

            foreach (var n1 in arr1)
                foreach (var n2 in arr2)
                    countSums[n1 + n2] = countSums.GetValueOrDefault(n1 + n2, 0) + 1;

            foreach (var n3 in arr3)
                foreach (var n4 in arr4)
                    results += countSums.GetValueOrDefault(-(n3 + n4), 0);

            return results;
        }
    }
}