using System;

namespace Leet_code
{
    class Program
    {
        static void Main(string[] args){
            
            var output = threeSum.performThreeSum(new int[] {1,2,3});
            foreach(var list in output){
                 foreach(var item in list){
                     Console.Write(item +", ");
                 }
                 Console.WriteLine();
            }
           
        }
    }
}
