/*
18. 4Sum
https://leetcode.com/problems/4sum/
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
-109 <= nums[i] <= 109
-109 <= target <= 109

*/
using System.Numerics;
using Problems.Common;
using u = Utils.Methods;

namespace Problems
{
    public class FourSum : CodingProblem<int[], List<IList<int>>>
    {
        internal override void AssignOtherInputs()
        {
            this.otherInputs = "0,8,0,-294967296";
            // this.otherInputs = "-294967296";
        }

        internal override void FillArray()
        {
            this.inputs = new List<int[]>()
            {
                new int[] {1,0,-1,0,-2,2},
                new int[] {2,2,2,2,2},
                new int[] {-2,-1,-1,1,1,2,2},
                new int[] {1000000000,1000000000,1000000000,1000000000},
            };
        }

        internal override void NameProblem()
        {
            this.problemName = "4Sum";
        }

        internal override void FillCorrectResults()
        {
            this.correctResults = new List<List<IList<int>>>()
            {
                new List<IList<int>>()
                {
                    new List<int>() {-2,-1,1,2},
                    new List<int>() {-2,0,0,2},
                    new List<int>() {-1,0,0,1},
                },
                new List<IList<int>>()
                {
                    new List<int>() {2,2,2,2},
                },
                new List<IList<int>>()
                {
                    new List<int>() {-2,-1,1,2},
                    new List<int>() {-1,-1,1,1},
                },
                new List<IList<int>>()
                {
                }
            };
        }

        internal override List<IList<int>> psolve(int[] inputs, string secondary)
        {
            return FourSumAnswer2(inputs, Int32.Parse(secondary));
        }

        private IList<IList<int>> FourSumAnswer(int[] arr, int target)
        {
            // size
            // loop on array for i
            // loop on array for j (i+1)
            // move right (size-1) and left (j+1)

            int size = arr.Length;
            IList<IList<int>> results = new List<IList<int>>();
            u.WriteArr(arr, "before");
            StartMergeSort(arr);
            u.WriteArr(arr, "after");

            // if (arr[0] > target) return results;
            // if (arr[size - 1] < target) return results;

            var tempTarget = target;

            for (int i = 0; i < size; i++)
            {
                tempTarget = target - arr[i];
                u.print($"i: {i} | tt: {tempTarget}");
                for (int j = i + 1; j < size; j++)
                {
                    tempTarget = target - arr[j] - arr[i];
                    u.print($"j: {j} | tt: {tempTarget}");
                    var left = j + 1;
                    var right = size - 1;
                    while (left < right)
                    {
                        // arr[left] + arr[right] > target right--
                        // target < arr[left] + arr[right]s right--
                        // target - arr[left] < arr[right] right--
                        // long sum = arr[left] + arr[right];
                        if (tempTarget - arr[left] > arr[right]) left++;
                        else if (tempTarget - arr[left] < arr[right]) right--;
                        else
                        {
                            u.print($"found! t:{tempTarget} i: {arr[i]}, j: {arr[j]}, left: {arr[left]}, right: {arr[right]}");
                            results.Add(new List<int>() { arr[i], arr[j], arr[left], arr[right] });
                            while (left < right && arr[left] == arr[left + 1]) left++;
                            while (left < right && arr[right] == arr[right - 1]) right--;
                            left++; right--;
                        }
                    }
                    while (j < size - 1 && arr[j] == arr[j + 1]) j++;
                }
                while (i < size - 1 && arr[i] == arr[i + 1]) i++;
            }

            return results;
        }

        private List<IList<int>> FourSumAnswer2(int[] arr, int target)
        {
            StartMergeSort(arr);
            return kSum(4, arr, 0, target);
        }

        private List<IList<int>> kSum(int k, int[] arr, int index, BigInteger target)
        {
            var results = new List<IList<int>>();
            int size = arr.Length;
            if (index >= size) return results;
            if (k > 2)
            {
                for (int i = index; i < size; i++)
                {
                    var r = kSum(k - 1, arr, i + 1, target - arr[i]);
                    foreach (var list in r)
                    {
                        list.Insert(0, arr[i]);
                    }
                    results.AddRange(r);
                    while (i < size - 1 && arr[i] == arr[i + 1]) i++;
                }
                return results;
            }
            else
            {
                var left = index;
                var right = size - 1;
                while (left < right)
                {
                    // target < arr[left] + arr[right] left++
                    // target - arr[left] < arr[right] left++
                    var test = target - arr[left];
                    if (target - arr[left] < arr[right]) right--;
                    else if (target - arr[left] > arr[right]) left++;
                    else
                    {
                        results.Add(new List<int>() { arr[left], arr[right] });
                        while (left < right && arr[left] == arr[left + 1]) left++;
                        while (left < right && arr[right] == arr[right - 1]) right--;
                        left++; right--;
                    }
                }
                return results;
            }
        }

        private void StartMergeSort(int[] arr)
        {
            MergeSort(arr, 0, arr.Length - 1);
        }

        private void MergeSort(int[] arr, int s, int e)
        {
            if (s >= e) return;
            int m = (s + e) / 2;
            MergeSort(arr, s, m);
            MergeSort(arr, m + 1, e);
            Merge(arr, s, m, e);
        }

        private void Merge(int[] arr, int s, int m, int e)
        {
            int s1 = m - s + 1;
            int s2 = e - m;

            int[] arr1 = new int[s1];
            int[] arr2 = new int[s2];

            for (int i = 0; i < s1; i++)
            {
                arr1[i] = arr[i + s];
            }

            for (int i = 0; i < s2; i++)
            {
                arr2[i] = arr[i + m + 1];
            }

            int i1 = 0, i2 = 0;
            int ia = s;

            while (i1 < s1 && i2 < s2)
            {
                if (arr1[i1] < arr2[i2])
                {
                    arr[ia] = arr1[i1];
                    i1++;
                }
                else
                {
                    arr[ia] = arr2[i2];
                    i2++;
                }
                ia++;
            }

            while (i1 < s1)
            {
                arr[ia] = arr1[i1];
                i1++;
                ia++;
            }

            while (i2 < s2)
            {
                arr[ia] = arr2[i2];
                i2++;
                ia++;
            }
        }
    }
}