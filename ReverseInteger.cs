using System;

//https://leetcode.com/problems/reverse-integer/
namespace Leet_code
{
    class Reverse_Integer
    {
        public static void reverseInt(string[] args)
        {
            int input = 0;
            if(args.Length >0){
                int.TryParse(args[0],out input);
            }

            char[] value = input.ToString().ToCharArray();

            int index = 0;
            long output = 0;
            int multiplier = 1;
            if(value[0] == '-'){
                multiplier = -1;
                index++;
            }

            for(int i = value.Length - 1; i >= index; i--){
                output *= 10;
                int val;
                Int32.TryParse(value[i].ToString(), out val);
                output += val;
            }
            output *= multiplier;
            if(output > int.MaxValue || output < int.MinValue){
                output = 0;
            }
            Console.WriteLine((int)output);
        }
    }
}

/*Accepted:
public class Solution {
    public int Reverse(int x) {
        char[] value = x.ToString().ToCharArray();

        int index = 0;
        long output = 0;
        int multiplier = 1;
        if(value[0] == '-'){
            multiplier = -1;
            index++;
        }

        for(int i = value.Length - 1; i >= index; i--){
            output *= 10;
            int val;
            Int32.TryParse(value[i].ToString(), out val);
            output += val;
        }
        output *= multiplier;
        if(output > int.MaxValue || output < int.MinValue){
            output = 0;
        }
        return ((int)output);
    }
}
*/
