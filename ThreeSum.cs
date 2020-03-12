/*Given an array nums of n integers, are there elements a, b, c in nums such that a + b + c = 0? Find all unique triplets in the array which gives the sum of zero.*/
//https://leetcode.com/problems/3sum/
// https://stackoverflow.com/questions/8142389/returning-ilistilistt

/* Pseudo code
    To get the unique pairs in a list that make up 2-sum, we can create a hashSet the input values, then,
    we can loop through the values and see if a key exists in the hashset for *desired value* - current value.
    
    For example, if the two values need to add to 0, we will check if the negative of 
    the value being checked exists in the hashSet. If the desired value is 10, we will check if 10-value is in the hashset.

    For a 3-sum, we can create a hashMap where the keys are unique pairs of numbers and the values
    are the pair's sums. We can loop through the list
*/
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Leet_code{
    class threeSum{
        public static IList<IList<int>> performThreeSum(int[] input){
            IList<IList<int>> result = new List<IList<int>>();
            Dictionary<pair,int> twoSum = new Dictionary<pair, int>();
            HashSet<triplet> three_sum = new HashSet<triplet>();
                        
            //Console.WriteLine("Pairs");
            for(int i = 0; i < input.Length; i++){
                for(int j = i+1; j < input.Length; j++){
                    pair pair = new pair(input[i],input[j],i,j);
                    
                    if(!twoSum.ContainsKey(pair)){
                        twoSum.Add(pair,input[i]+input[j]);         
                        //Console.WriteLine(pair.ToString());
                    }
                }
            }
            //Console.WriteLine("Triplets");

            //https://stackoverflow.com/questions/12177596/get-key-by-value-in-hash-table-c-sharp#answer-12177642
            int index = 0;
            foreach(int i in input){
                if(twoSum.ContainsValue(-i)){
                    foreach(pair pair in twoSum.Keys.Where(v => twoSum[v] == -i)){
                        if(pair.getIndexA() == index || pair.getIndexB() == index){
                            //Console.WriteLine("indexA: " + pair.getIndexA() + " .indexB: " + pair.getIndexB() + " .index: " + index);
                            continue;
                        }
                        triplet triplet = new triplet(pair.getX1(), pair.getX2(), i);
                        if(!three_sum.Contains(triplet)){
                            
                            three_sum.Add(triplet);
                            //Console.WriteLine(i + ": " + triplet.ToString());
                            result.Add(new List<int>(){triplet.x1,triplet.x2,triplet.x3});                            
                        }
                    }
                }
                index++;
            }
            
            return result;
        }
        private struct pair{
            int x1;
            int x2;
            int indexA,indexB;
            public pair(int x1, int x2, int indexA, int indexB){
                if(x1 > x2){
                    this.x1 = x2;
                    this.x2 = x1;
                }
                else{
                    this.x1 = x1;
                    this.x2 = x2;
                }
                this.indexA = indexA;
                this.indexB = indexB;
            }
            public int getX1(){
                return x1;
            }
            public int getX2(){
                return x2;
            }
            public int getIndexA(){
                return indexA;
            }
            public int getIndexB(){
                return indexB;
            }

            override public string ToString(){
                return x1.ToString() + ", " + x2.ToString();
            }

        }

        // Assumes x1 and x2 are in ascending order. 
        // Ensures that triplet is in ascending order
        private struct triplet{
            public int x1,x2,x3;
            public triplet(int x1, int x2, int x3){
                if(x3 < x1){
                    this.x1 = x3;
                    this.x2 = x1;
                    this.x3 = x2;
                    return;
                }
                if(x3 < x2){
                    this.x1 = x1;
                    this.x2 = x3;
                    this.x3 = x2;
                    return;
                }
                this.x1 = x1;
                this.x2 = x2;
                this.x3 = x3;
            }
            override public string ToString(){
                return x1.ToString() + ", " + x2.ToString() 
                        + ", " + x3.ToString();
            }
        }
    }

}
