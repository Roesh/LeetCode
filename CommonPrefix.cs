/* Roshan Manuel: 3/13/2020 (20 mins to create) 
Runtime: 108 ms, faster than 41.88% of C# online submissions for Longest Common Prefix.
Memory Usage: 24.7 MB, less than 5.26% of C# online submissions for Longest Common Prefix.
*/
namespace Leet_code{
    class CommonPrefix{
        
        public static string LongestCommonPrefix(string[] strs){
            
            string output = string.Empty;

            if(strs.Length == 0){
                return output;
            }
            
            int currentCharIndex = 0;
            
            foreach(char c in strs[0]){                
                foreach(string s in strs){
                    // If at any point, one of the strings has been fully checked, 
                    // or if the character at this index in this string is not the same
                    // return whats in out
                    if(s.Length == currentCharIndex || s[currentCharIndex] != c){
                        return output; 
                    }
                }
                currentCharIndex++;
                output += c.ToString();
            }
            return output;
        }

    }

}