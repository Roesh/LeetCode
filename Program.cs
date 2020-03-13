using System;
using System.Linq;

namespace Leet_code
{
    class Program
    {
        static void Main(string[] args){
                        
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
    }
}
