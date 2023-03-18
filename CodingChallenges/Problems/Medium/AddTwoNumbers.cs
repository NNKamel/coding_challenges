/*
2. Add Two Numbers
https://leetcode.com/problems/add-two-numbers/description/
You are given two non-empty linked lists representing two non-negative integers. The digits are stored in reverse order, and each of their nodes contains a single digit. Add the two numbers and return the sum as a linked list.

You may assume the two numbers do not contain any leading zero, except the number 0 itself.

 

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
    public class AddTwoNumbers : CodingProblem<List<ListNode>, ListNode>
    {
        internal override void AssignOtherInputs()
        {

        }

        internal override void FillArray()
        {
            this.inputs = new List<List<ListNode>>()
            {
                new List<ListNode>() {
                    getListNode(new int[] {2,4,3}, 0),
                    getListNode(new int[] {5,6,4}, 0),
                },
                new List<ListNode>() {
                    getListNode(new int[] {9,9,9,9,9,9,9}, 0),
                    getListNode(new int[] {9,9,9,9}, 0),
                },
            };
        }

        private ListNode getListNode(int[] inp, int pos)
        {
            if (inp.Length <= pos)
            {
                return null;
            }

            return new ListNode()
            {
                val = inp[pos],
                next = getListNode(inp, pos + 1),
            };
        }

        internal override void NameProblem()
        {
            this.problemName = "Add Two Numbers";
        }

        internal override void FillCorrectResults()
        {
            this.correctResults = new List<ListNode>()
            {
                getListNode(new int[] {7, 0, 8}, 0),
                getListNode(new int[] {8,9,9,9,0,0,0,1}, 0)
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
        internal override ListNode psolve(List<ListNode> inpList, string secondary)
        {
            return AddTwoNumbersAnswer(inpList);
        }

        ListNode AddTwoNumbersAnswer(List<ListNode> inpList)
        {
            u.ToPrettyString(inpList);

            var l1 = inpList[0];
            var l2 = inpList[1];

            // sum all items in list into the bigger one
            var firstNode = Sum(l1, l2);

            // calculate remainder, carryover
            firstNode = CalcCarryOver(firstNode, 0);

            ListNode resultList = new();

            u.ToPrettyString(firstNode);
            return firstNode;
        }



        private ListNode CalcCarryOver(ListNode n1, int carryOver)
        {
            if (n1 == null)
            {
                if (carryOver <= 0)
                    return null;
                else
                    return new ListNode() { val = carryOver };
            }

            n1.val += carryOver;

            if (n1.val >= 10)
            {
                n1.val -= 10;
                n1.next = CalcCarryOver(n1.next, 1);
            }
            else
            {
                n1.next = CalcCarryOver(n1.next, 0);
            }

            return n1;
        }

        private ListNode Sum(ListNode n1, ListNode n2)
        {
            u.ToPrettyString(n1);
            u.ToPrettyString(n2);
            if (n1 == null && n2 == null)
            {
                return null;
            }

            if (n1 == null)
            {
                return new ListNode()
                {
                    val = n2.val,
                    next = Sum(null, n2.next),
                };
            }

            if (n2 == null)
            {
                return new ListNode()
                {
                    val = n1.val,
                    next = Sum(null, n1.next),
                };
            }

            return new ListNode()
            {
                val = n1.val + n2.val,
                next = Sum(n1.next, n2.next),
            };
        }
    }

    public class ListNode
    {
        public int val { get; set; }

        public ListNode next { get; set; }
    }
}