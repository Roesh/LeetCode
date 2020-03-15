/*https://leetcode.com/problems/add-two-numbers/
You are given two non-empty linked lists representing two non-negative integers. 
The digits are stored in reverse order and each of their nodes contain a single digit. 
Add the two numbers and return it as a linked list.
*/

using System;
using System.Collections;
using System.Collections.Generic;

namespace Leet_code{
    public class ListNode {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
    }

    class AddTwoNumbersClass{

        /*        
        Runtime: 104 ms, faster than 86.21% of C# online submissions for Add Two Numbers. (WITHOUT THROW NEW ARGUMENT EXCEPTION)
        Runtime: 116 ms, faster than 30.05% of C# online submissions for Add Two Numbers. (WITH THROW NEW ARGUMENT EXCEPTION)
        Memory Usage: 27.7 MB, less than 9.09% of C# online submissions for Add Two Numbers.

        Time-space analysis: The bulk of time spent comes from the main while loop, which loops through each value in both lists
        The number of times it loops is equal to the length of the longer number
        O(n) = max(length of linked list 1, length of linked list 2) */
        public static ListNode AddTwoNumbers(ListNode l1, ListNode l2){
            if(l1 == null || l2 == null){
                throw new ArgumentException("lists cannot be null"); // Removing this shaved off 12 ms...
                // return null;
            }
            
            int valL1 = 0;
            int valL2 = 0;
            int sum = 0;
            int carry = 0;

            ListNode nextL1Node = l1;
            ListNode nextL2Node = l2;

            ListNode previousResultNode = null;
            ListNode initialNode = null;
        
            while(nextL1Node != null || nextL2Node != null || carry != 0){

                if(nextL1Node != null){
                    valL1 = nextL1Node.val;
                }
                if(nextL2Node != null){
                    valL2 = nextL2Node.val;
                }
                sum = valL1 + valL2 + carry;
                if(sum > 9){
                    carry = 1; //vaL1, salL2 max value is 9, restricting carry to max 1 will cause all sums to have max of 19
                    sum -= 10;
                }else{
                    carry = 0;
                }

                ListNode newNode = new ListNode(sum);  
                if(previousResultNode != null){
                    previousResultNode.next = newNode;                    
                }else{
                    initialNode = newNode;
                }
                previousResultNode = newNode;

                valL1 = valL2 = sum = 0;       
                if(nextL1Node != null){
                    nextL1Node = nextL1Node.next;
                }
                if(nextL2Node != null){
                    nextL2Node = nextL2Node.next;
                }
            }

            return initialNode;
        }

        public static ListNode createNodes(int input){
            List<ListNode> result = new List<ListNode>();
            char[] digits = input.ToString().ToCharArray();

            ListNode nextNode = null;
            foreach(char c in digits){
                int temp;                
                int.TryParse(c.ToString(),out temp);    

                ListNode currentNode = new ListNode(temp);
                currentNode.next = nextNode;
                result.Add(currentNode);
                
                nextNode = currentNode;
            }
            return nextNode;
        }

        public static string printNode(ListNode list){
            string result = string.Empty;
            ListNode nextNode = list;
            while(nextNode != null){
                result += nextNode.val.ToString();
                nextNode = nextNode.next;
            }
            //https://stackoverflow.com/questions/228038/best-way-to-reverse-a-string
            {
            char[] charArray = result.ToCharArray();
            Array.Reverse( charArray );
            result = new string( charArray );
            }
            return result;
        }


    }


}