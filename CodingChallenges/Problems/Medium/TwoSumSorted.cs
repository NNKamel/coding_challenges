/*
167. Two Sum II - Input Array Is Sorted
Medium
https://leetcode.com/problems/two-sum-ii-input-array-is-sorted/description/
Companies
Given a 1-indexed array of integers numbers that is already sorted in non-decreasing order, find two numbers such that they add up to a specific target number. Let these two numbers be numbers[index1] and numbers[index2] where 1 <= index1 < index2 <= numbers.length.

Return the indices of the two numbers, index1 and index2, added by one as an integer array [index1, index2] of length 2.

The tests are generated such that there is exactly one solution. You may not use the same element twice.

Your solution must use only constant extra space.

 

Example 1:

Input: numbers = [2,7,11,15], target = 9
Output: [1,2]
Explanation: The sum of 2 and 7 is 9. Therefore, index1 = 1, index2 = 2. We return [1, 2].
Example 2:

Input: numbers = [2,3,4], target = 6
Output: [1,3]
Explanation: The sum of 2 and 4 is 6. Therefore index1 = 1, index2 = 3. We return [1, 3].
Example 3:

Input: numbers = [-1,0], target = -1
Output: [1,2]
Explanation: The sum of -1 and 0 is -1. Therefore index1 = 1, index2 = 2. We return [1, 2].
 

Constraints:

2 <= numbers.length <= 3 * 104
-1000 <= numbers[i] <= 1000
numbers is sorted in non-decreasing order.
-1000 <= target <= 1000
The tests are generated such that there is exactly one solution.
*/
using Problems.Common;
using u = Utils.Methods;

namespace Problems
{
    public class TwoSumSorted : CodingProblem<int[], int[]>
    {
        internal override void AssignOtherInputs()
        {
            this.otherInputs = "9,6,-1";
        }

        internal override void FillArray()
        {
            this.inputs = new List<int[]>()
            {
                new int[] { 2,7,11,15 },
                new int[] {2,3,4},
                new int[] {-1,0},
            };
        }

        internal override void NameProblem()
        {
            this.problemName = "167. Two Sum II - Input Array Is Sorted";
        }

        internal override void FillCorrectResults()
        {
            this.correctResults = new List<int[]>()
            {
                new int[] {1,2},
                new int[] {1,3},
                new int[] {1,2},
            };
        }

        internal override int[] psolve(int[] arr, string secondary)
        {
            return TwoSumSortedAnswer(arr, Int32.Parse(secondary));
        }

        int[] TwoSumSortedAnswer(int[] arr, int target)
        {
            int size = arr.Length;

            for (int i = 0, j = size - 1; i < size && j > 0;)
            {
                var testSum = arr[i] + arr[j];
                if (testSum == target)
                {
                    return new int[] { i + 1, j + 1 };
                }
                else if (testSum > target)
                {
                    j--;
                }
                else
                {
                    i++;
                }
            }

            return new int[2];
        }

        int[] TwoSumAnswer(int[] arr, int target)
        {
            int size = arr.Length;
            var sumdic = new Dictionary<int, int>();

            for (int i = 0; i < size; i++)
            {
                if (sumdic.ContainsKey(arr[i]))
                {
                    return new int[] { sumdic[arr[i]], i };
                }
                sumdic[target - arr[i]] = i;
            }

            return new int[2];
        }
    }
}