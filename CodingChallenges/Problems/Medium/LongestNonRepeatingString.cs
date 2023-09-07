/*
3. Longest Substring Without Repeating Characters
Medium
31.7K
1.4K
Companies
Given a string s, find the length of the longest 
substring
 without repeating characters.

 

Example 1:

Input: s = "abcabcbb"
Output: 3
Explanation: The answer is "abc", with the length of 3.
Example 2:

Input: s = "bbbbb"
Output: 1
Explanation: The answer is "b", with the length of 1.
Example 3:

Input: s = "pwwkew"
Output: 3
Explanation: The answer is "wke", with the length of 3.
Notice that the answer must be a substring, "pwke" is a subsequence and not a substring.
 

Constraints:

0 <= s.length <= 5 * 104
s consists of English letters, digits, symbols and spaces.
*/
using Problems.Common;
using u = Utils.Methods;

namespace Problems
{
    public class LongestNonRepeatingString : CodingProblem<string, int>
    {
        internal override void AssignOtherInputs()
        {

        }

        internal override void FillArray()
        {
            this.inputs = new List<string>()
            {
                "abcabcbb",
                "bbbbb",
                "pwwkew",
                " ",
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
            this.problemName = "3. Longest Substring Without Repeating Characters";
        }

        internal override void FillCorrectResults()
        {
            this.correctResults = new List<int>()
            {
                3, 1, 3, 1
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
        internal override int psolve(string input, string secondary)
        {
            return FindLongestNonRepeatingString(input);
        }

        int FindLongestNonRepeatingString(string s)
        {
            u.ToPrettyString(s);
            var size = s.Length;

            var cachedNums = new Dictionary<char, int>();
            int maxLength = 0;
            // save the letters we read and not repeated
            // save the letters postions
            // when current letter is found, move start pointer after first occurrance of repeated letter
            // maxLength is set each loop, if it is less than difference between 2 pointers

            for (int i = 0, j = 1; i < size && j < size; i++)
            {
                u.print("before j: " + j + " i: " + i + " s[i]: " + s[i]);
                if (cachedNums.ContainsKey(s[i]))
                {
                    u.print("found: " + s[i]);
                    var diff = i - j;
                    if (diff > maxLength) maxLength = diff;
                    j = i;
                    u.print("after j: " + j + " i: " + i);
                    u.ToPrettyString(cachedNums);
                }
                else
                {
                    u.print("new: " + s[i]);
                    cachedNums[s[i]] = i;
                    if (i - j > maxLength)
                    {
                        maxLength = i - j;
                    }
                }
                u.print("maxLength: " + maxLength);
            }

            return maxLength;
        }
    }
}