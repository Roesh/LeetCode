//https://leetcode.com/problems/valid-parentheses/
//Given a string containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.
// Implementing the solution using a stack
using System.Collections;
using System;

namespace Leet_code{

    class ValidParanthesesClass{
        public static bool IsValid(string input){
            Stack bracketStack = new Stack();

            Hashtable bracketPair = new Hashtable();
            bracketPair.Add('}','{');
            bracketPair.Add(']','[');
            bracketPair.Add(')','(');            
            
            foreach(char c in input){
                if(GetBracketType(c) == bracketType.opening){
                    bracketStack.Push(c);
                    continue;
                }
                // Ran into trouble here. The comparison was failing and only began to work once bracketPair[c] and bracketStack 
                // were cast to char
                if((bracketStack.Count == 0) || (char)bracketPair[c] != (char)bracketStack.Peek()){                    
                    return false;
                }
                bracketStack.Pop();
            }            
            if(bracketStack.Count > 0){                
                return false;
            }            
            return true;
        }
        private enum bracketType{
            opening,
            closing
        }
        private static bracketType GetBracketType(char c){
            if(c == '[' || c == '{' || c == '('){
                return bracketType.opening;
            }
            if(c == ']' || c == '}' || c == ')'){
                return bracketType.closing;
            }else{
                throw new ArgumentException("Unknown character provided to GetBracketType method. Only [,{,(,],},) are allowed");                
            }

        }
    }

}