using System;
using System.Linq;

namespace Leet_code
{
    class Program
    {
        static void Main(string[] args){
            ThreeSumEntry(args);
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
    }
}
