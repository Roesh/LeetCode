/*Given an array nums of n integers, are there elements a, b, c in nums such that a + b + c = 0? Find all unique triplets 
in the array which gives the sum of zero.
You may assume that each input would have exactly one solution, and you may not use the same element twice.

Timespace eval: Looping through input twice. Time = 2*n (loops) + constant for other operations, including Dictionary Add and lookup
O(n) = n

Runtime: 232 ms, faster than 98.33% of C# online submissions for Two Sum.
Memory Usage: 31 MB, less than 5.08% of C# online submissions for Two Sum.*/

//https://leetcode.com/problems/two-sum/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Leet_code{

    class TwoSumClass: TwoSumClassGeneric{
        
        // Note that if we have duplicate values that satisfy the criteria, this class will return fail
        new public static int[] TwoSum(int[] nums, int target){
            int inputLength = nums.Length;
            if(inputLength < 1){
                return null;
            }
            // Dict maps int[] nums values to their indexes
            Dictionary<int,int> valueToIndexDict = new Dictionary<int, int>(inputLength);

            int index = 0;
            foreach(var num in nums){
                if(!valueToIndexDict.ContainsKey(num)){
                    valueToIndexDict.Add(num,index);
                }                                
                index++;
            }

            index = 0;
            foreach(var num in nums){
                int requiredValue = target - num;
                
                if(valueToIndexDict.ContainsKey(requiredValue)){
                    int satsifyingIndex = valueToIndexDict[requiredValue];
                    if(satsifyingIndex != index){
                        return new int[] {index, satsifyingIndex};
                    }
                }
                index++;
            }
            return null;
        }
    }

    class TwoSumClassGeneric{

        public static List<int[]> TwoSum(int[] nums, int target){
            Dictionary<int,List<int>> valueToIndexesDict = new Dictionary<int, List<int>>();
            HashSet<List<int>> indexPairReturnList = new HashSet<List<int>>();

            int index = 0;
            foreach(var num in nums){
                List<int> currentIndexList = new List<int>();
                
                currentIndexList.Add(index);
                
                if(valueToIndexesDict.ContainsKey(num)){
                    List<int> currentIndexes = valueToIndexesDict[num];
                    currentIndexes.Add(index);
                    valueToIndexesDict[num] = new List<int>(currentIndexes);
                }else{
                    valueToIndexesDict.Add(num, new List<int>(){index});
                    
                }
                index++;
            }

            /*foreach(var k in valueToIndexesDict.Keys){
                Console.Write(k + ". ");
                foreach(var indexes in valueToIndexesDict[k]){
                    Console.Write(indexes.ToString() + ", ");
                }
                Console.WriteLine("");
            }*/
            
            index = 0;
            foreach(int num in nums){
                int requiredValue = target - num;
                if(valueToIndexesDict.ContainsKey(requiredValue)){
                    foreach(var ix in valueToIndexesDict[requiredValue]){
                        if(index != ix){
                            int temp = ix;
                            if(ix < index){
                                indexPairReturnList.Add(new List<int>(){ix, index});
                            }else{
                                indexPairReturnList.Add(new List<int>(){index, ix});
                            }
                        }
                    }
                }
                index++;
            }

            return null;
        }
    }

}
