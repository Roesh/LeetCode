using System;

//https://leetcode.com/problems/string-to-integer-atoi/submissions/
namespace Leet_code{

    class MyAtoi{
        public static int performMyAtoi(string str){
            double output = 0;
            int multiplier = 1;
            bool whitespaceStripComplete = false;
            bool validationComplete = false;

            foreach(char c in str){     
                if(validationComplete){
                    break;
                }
                if(!whitespaceStripComplete){
                    switch(getCharacterType(c)){
                        case(characterType.negativeSign): {
                            multiplier = -1;
                            whitespaceStripComplete = true;
                        }break;
                        case(characterType.positiveSign): {
                            multiplier = 1;
                            whitespaceStripComplete = true;
                        }break;
                        case(characterType.number):{
                            double.TryParse(c.ToString(), out output);
                            whitespaceStripComplete = true;
                        }break;
                        case(characterType.other):{
                            validationComplete = true;
                        }break;
                    }
                    continue;
                }
                
                characterType cType = getCharacterType(c);
                if(cType == characterType.number){
                    output *= 10;
                    int val;
                    Int32.TryParse(c.ToString(), out val);
                    output += val;
                }else{
                    break;
                }
            }
            output *= multiplier;
            if(output > int.MaxValue){
                output = int.MaxValue;
            }
            if(output < int.MinValue){
                output = int.MinValue;
            }
            return (int)output;
        }

        private static characterType getCharacterType(char c){
            if(c == ' '){
                return characterType.whiteSpace;
            }else if(c == '-'){
                return characterType.negativeSign;                
            }else if(c == '+'){
                return characterType.positiveSign;                
            }else if(c >= '0' && c <= '9'){
                return characterType.number;
            }else{
                return characterType.other;
            }

        }
        enum characterType{
            whiteSpace,
            negativeSign,
            positiveSign,
            number,
            other
        }
    }

}