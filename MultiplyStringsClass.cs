/* https://leetcode.com/problems/multiply-strings/ 
Given two non-negative integers num1 and num2 represented as strings, return the product of num1 and num2, also represented as a string.

Note:

    The length of both num1 and num2 is < 110.
    Both num1 and num2 contain only digits 0-9.
    Both num1 and num2 do not contain any leading zero, except the number 0 itself.
    You must not use any built-in BigInteger library or convert the inputs to integer directly.

My notes:
    we can potentially "chunk" both strings into pieces that can be converted to regular ints.
    This would satisfy the don't convert directly to integer requirement and work around the don't use big int libraries requirement

    The number of pieces would be length / 4 digits. (see below for why 4 items only)

    We will need to think about how piecewise multiplication would work in a scenario like this:
    int a decomposed into chunk a1 + chunk a2 + chunk a3
    times int b, decomposed into chunk b1  + chunk b2 + chunk b3
    Result = (chunks a1, a2, a3)    * chunk b1 + ...
    Note that the results of these operations must fit within out int chunks, meaning 
    our length is actually halved. Max int is 10 digits, so we can safely operate with 4 digits because 9999*9999 is below max int
    but 99999^2 is over the limit.

    The time complexity for the input lengths will end up being (numm pieces of 1 * num pieces of 2)
    
*/

using System;
using System.Collections;
using System.Collections.Generic;

namespace Leet_code
{
    /* Pass #1: Runtime: 148 ms, faster than 24.16% of C# online submissions for Multiply Strings.
    Memory Usage: 26.6 MB, less than 100.00% of C# online submissions for Multiply Strings.    */
    
    class MultiplyStringClass
    {
        private const int stringChunkSize = 4;
        public string Multiply(string num1, string num2)
        {
            if (num1 == null || num2 == null)
            {
                return string.Empty;
            }
            string[] smallerNumber, largerNumber;
            int numChunksLarger, numChunksSmaller;
            if (num2.Length > num1.Length)
            {
                largerNumber = this.getStringChunks(num2, out numChunksLarger);
                smallerNumber = this.getStringChunks(num1, out numChunksSmaller);
            }
            else
            {
                largerNumber = this.getStringChunks(num1, out numChunksLarger);
                smallerNumber = this.getStringChunks(num2, out numChunksSmaller);
            }

            string prodChunkSmaller, prodChunkLarger, carry = string.Empty;
            int resultChunksLength = (int)Math.Ceiling((double)(num2.Length + num1.Length) / stringChunkSize);
            List<string> result = new List<string>(resultChunksLength);
            int currentResultChunk = 0;
            for (int i = numChunksLarger - 1; i >= 0; i--)
            {
                currentResultChunk = numChunksLarger - 1 - i;
                for (int j = numChunksSmaller - 1; j >= 0; j--)
                {
                    // Console.WriteLine("----------------------------------------------------");
                    // Console.WriteLine("Multiplying smaller number's piece" + (numChunksSmaller - 1 - j) + ", " + smallerNumber[j] + " with piece " + (numChunksLarger - 1 - i) + ", value " + largerNumber[i] + " of larger number");
                    prodChunkSmaller = this.multiplyStringChunks(smallerNumber[j], largerNumber[i], out prodChunkLarger);
                    // Console.WriteLine("Product chunk 1 is " + prodChunkSmaller + ". Product chunk 2 is " + prodChunkLarger);

                    if (result.Count < currentResultChunk + 1)
                    {
                        // Console.WriteLine("Creating smaller piece, Adding " + prodChunkSmaller + " and " + carry);
                        //result.Add(addStringChunks(prodChunkSmaller, carry, string.Empty, out carry));
                        result.Add(addStringChunks(prodChunkSmaller, carry, string.Empty, out carry));
                    }
                    else
                    {
                        //Console.WriteLine("Creating smaller piece, Adding " + result[currentResultChunk] + ", " + prodChunkSmaller + " and " + carry);
                        //result[currentResultChunk] = addStringChunks(result[currentResultChunk], prodChunkSmaller, carry, out carry);
                        result[currentResultChunk] = addStringChunks(result[currentResultChunk], prodChunkSmaller, carry, out carry);
                    }
                    // Console.WriteLine("result[" + currentResultChunk + "] is " + result[currentResultChunk] + ". Next carry is " + carry);

                    if (result.Count < currentResultChunk + 2)
                    {
                        // Console.WriteLine("Creating larger piece, Adding " + prodChunkLarger + " and " + carry);
                        result.Add(addStringChunks(prodChunkLarger, carry, string.Empty, out carry));
                    }
                    else
                    {
                        // Console.WriteLine("Creating larger piece, Adding " + result[currentResultChunk+1] + ", " + prodChunkLarger + " and " + carry);
                        result[currentResultChunk + 1] = addStringChunks(result[currentResultChunk + 1], prodChunkLarger, carry, out carry);
                    }
                    //Console.WriteLine("result[" + (currentResultChunk + 1) + "] is " + result[currentResultChunk + 1] + ". Propagating carry " + carry);                    
                    propagateCarry(result, currentResultChunk + 2, carry);
                    
                    {/*
                         Console.Write("Result state is :");
                        result.Reverse();
                        foreach(string s in result){
                            Console.Write(s + " ");
                        }
                        Console.WriteLine();
                        result.Reverse();
                    */}

                    carry = null;
                    currentResultChunk++;
                }
            }

            if (carry != string.Empty)
            {
                result.Add(carry);
            }
            
            string output = string.Empty;
            result.Reverse();
            foreach (var s in result)
            {
                output += padNeededZeroesLeft(s);
            }

            char nextChar = output[0];
            int trimFromIndex = 0;
            while (nextChar == '0' && output.Length > trimFromIndex+1)
            {
                trimFromIndex++;
                nextChar = output[trimFromIndex];
            }
            if (trimFromIndex > 0)
            {
                output = output.Substring(trimFromIndex);
            }
            return output;
        }
        private void propagateCarry(List<string> input, int currentIndex, string carry){
            while(carry != null && carry != string.Empty){
                if(currentIndex < input.Count){
                    input[currentIndex] = addStringChunks(input[currentIndex],string.Empty, carry, out carry);  
                    currentIndex++;
                }else{
                    input.Add(carry);
                    carry = string.Empty;
                }
            }
            return;
        }
        private string padNeededZeroesLeft(string input)
        {
            if(input == null){
                return null;
            }
            int neededZeros = stringChunkSize - input.Length;
            if (neededZeros > 0)
            {
                for (int i = 0; i < neededZeros; i++)
                {
                    input = "0" + input;
                }
            }
            return input;
        }
        private string addStringChunks(string chunk1, string chunk2, string carryIn, out string carry)
        {
            int result = 0;
            if (chunk1 != null && chunk1 != string.Empty)
            {
                result += int.Parse(chunk1);
            }
            if (chunk2 != null && chunk2 != string.Empty)
            {
                result += int.Parse(chunk2);
            }
            if (carryIn != null && carryIn != string.Empty)
            {
                result += int.Parse(carryIn);
            }
            string[] resultStrings = dualChunkParse(result.ToString());
            carry = resultStrings[0];
            return resultStrings[1];
            {/*
                int numPieces = 0;
                string[] resultStrings = getStringChunks(result.ToString(), out numPieces);
                if(numPieces == 2){
                    carry = resultStrings[0];
                    return resultStrings[1];
                }else{
                    carry = string.Empty;
                    return resultStrings[0];
                }*/

            }
            
        }
        private string[] dualChunkParse(string input){
            string[] output = new string[2];
            if(input.Length <= stringChunkSize){
                output[1] = input;
                output[0] = string.Empty;
            }else{
                int carryLength = input.Length - stringChunkSize;
                output[1] = input.Substring(carryLength);
                output[0] = input.Substring(0,carryLength);
            }
            return output;

        }
        private string[] getStringChunks(string input, out int numChunks)
        {
            int inputLength = input.Length;
            numChunks = (int)Math.Ceiling((double)inputLength / stringChunkSize);
            string[] result = new string[numChunks];

            int lastChunkLength = inputLength % stringChunkSize;
            int substringStartIndex = 0;
            int currentResultIndex = 0;
            if(lastChunkLength > 0){
                result[0] = input.Substring(substringStartIndex,lastChunkLength);
                substringStartIndex += lastChunkLength;
                currentResultIndex++;
            }
            for (int i = currentResultIndex; i < numChunks; i++)
            {
                result[i] = input.Substring(substringStartIndex, stringChunkSize);
                substringStartIndex += stringChunkSize;
            }            
            //result[numChunks - 1] = input.Substring(startIndex);

            return result;
        }
        private string multiplyStringChunks(string num1, string num2, out string carry)
        {
            int intNum1, intNum2;
            if (!int.TryParse(num1, out intNum1) || !int.TryParse(num2, out intNum2))
            {
                carry = null;
                return string.Empty;
                //throw new ArgumentException("String chunk arguments must only contain numeric value");
            }

            string productString = (intNum1 * intNum2).ToString();
            int stringDelta = productString.Length - stringChunkSize;
            if (stringDelta > 0)
            {
                carry = productString.Substring(0, stringDelta);
            }
            else
            {
                carry = string.Empty;
            }
            return productString.Substring(Math.Clamp(stringDelta, 0, stringChunkSize));
        }
    
    }
}