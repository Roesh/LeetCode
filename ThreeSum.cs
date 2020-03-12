/*Given an array nums of n integers, are there elements a, b, c in nums such that a + b + c = 0? Find all unique triplets in the array which gives the sum of zero.*/
//https://leetcode.com/problems/3sum/
// https://stackoverflow.com/questions/8142389/returning-ilistilistt
using System;
using System.Collections;
using System.Collections.Generic;

namespace Leet_code{
    class threeSum{
        public static IList<IList<int>> performThreeSum(int[] nums){
            IList<IList<int>> result = new List<IList<int>>();

            /* Pseudo code
            For a 2-sum, we can create a hashSet of values and then we can loop through the values and 
            check if the hashSet contains the value needed to satisfy our constraint.
            For example, if the two values need to add to 0, we will check if the negative of 
            the value being checked exists in the hashSet

            For a 3-sum, we can create a hashMap where the keys are unique pairs of numbers and the values
            are the pair's sums. We can loop through the list

            */

            var aList = new List<int>();
            aList.Add(1);
            aList.Add(2);
            aList.Add(3);

            result.Add(aList);
            return result;
        }

    }

}
