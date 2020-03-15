using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Leet_code
{
    class Program
    {
        static void Main(string[] args){
            AddTwoNumbersClassEntry(args);
        }

        static void CommonPrefixEntry(string[] args){
            if(args.Length == 0){
                throw new ArgumentException("Common Prefix Entry requires input strings. Format is \"abc,bcd,cde...,xyz\"");                
            }
            var strs = args[0].Split(",");
            /*foreach(string s in strs){
                Console.WriteLine(s);
            }*/
            string commonPrefix = CommonPrefix.LongestCommonPrefix(strs);
            Console.WriteLine("Longest Common prefix among input is "+ commonPrefix);
        }

        static void ThreeSumEntry(string[] args){
            if(args.Length == 0){
                throw new ArgumentException("Three sum requires input array. Format is \"x1,x2,x3...,x4\"");                
            }
            //https://stackoverflow.com/questions/2959161/convert-string-to-int-array-using-linq
            
            int[] input = args[0].Split(',').Select(n => Convert.ToInt32(n)).ToArray();
            
            var output = threeSum.performThreeSum(input);

            foreach(var list in output){
                foreach(var item in list){
                    Console.Write(item + ",");
                }
                Console.WriteLine();
            }
        }

        static void ValidParanthesesEntry(string[] args){
            if(args.Length == 0){
                throw new ArgumentException("Requires input array argument. Format is any combination of brackets, e.g: \"(){}[]\"");
            }
            if(ValidParanthesesClass.IsValid(args[0])){
                Console.WriteLine("Parantheses are balanced");
            }else{
                Console.WriteLine("Parantheses are not balanced");
            }

        }

        static void TwoSumEntry(string[] args){
            if(args.Length < 2){
                throw new ArgumentException("Requires input array and target arguments. Format is \"x1,x2,x3...,x4\" and target should be integer");
            }
            int[] input = args[0].Split(',').Select(n => Convert.ToInt32(n)).ToArray();
            int target;
            int.TryParse(args[1],out target);
            int[] output = TwoSumClass.TwoSum(input,target);
            if(output == null){
                Console.WriteLine("No pairs that satisfy constaint found");      
                return;          
            }if(output.Length != 2){
                throw new Exception("Output array does not have exactly two elements.");
            }
            else{
                Console.WriteLine("Two sum satisfied by integers at " + output[0] + " and " + output[1]);
            }
        }
    
        static void AddTwoNumbersClassEntry(string[] args){
            if(args.Length < 2){
                throw new ArgumentException("Please supply at least two integer arguments when calling add Two Numbers");
            }
            int num1,num2;
            if(!int.TryParse(args[0],out num1) || !int.TryParse(args[1],out num2)){
                throw new ArgumentException("Could not convert an input to integer");
            }
            
            if(num1 < 0 || num2 < 0){
                throw new ArgumentException("Numbers supplied must be non-negative calling add Two Numbers");
            }

            ListNode list1 = AddTwoNumbersClass.createNodes(num1);
            ListNode list2 = AddTwoNumbersClass.createNodes(num2);
            ListNode result = AddTwoNumbersClass.AddTwoNumbers(list1,list2);

            Console.WriteLine("List 1 is " + AddTwoNumbersClass.printNode(list1));
            Console.WriteLine("List 2 is " + AddTwoNumbersClass.printNode(list2));
            Console.WriteLine("Sum of lists is " + AddTwoNumbersClass.printNode(result));
            
        }
    }
}
