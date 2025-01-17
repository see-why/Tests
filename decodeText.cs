using System;

class CaesarCipher
{   
    // assumomg shifts are forward not backwards e.g a after 3 steps is d
    // and y after 3 steps is b
    public static int process(String fromattedText, string decodedWord) {
        int length = decodedWord.Count();
        int difference = 0;
        String[] words = fromattedText.Split();
        foreach(var word in words) {
            if (word.Length == length) {
                difference = getDifference(word[0], decodedWord[0]);
                for (int c = 1; c < length; c++) {
                    if (getDifference(word[0], decodedWord[0]) != difference) {
                        break;
                    }
                }
                break;
            }
        }
        
        if (difference == 0) {
            return -1;
        }
        
        String result = "";
        for(int i = 0; i < fromattedText.Length; i++) {
                if (char.IsLetter(fromattedText[i])) {
                    int unicode = (int)fromattedText[i];
                    int originalUnicode = unicode - difference;
                    if (char.IsUpper(fromattedText[i])) {
                        result += (char)((int)'A' + ((originalUnicode - (int)'A' + 26) % 26));
                    } else {
                         result +=  (char)((int)'a' + ((originalUnicode - (int)'a' + 26) % 26));
                    }
                } else {
                    result += fromattedText[i];
                }
        } 
        
        Console.WriteLine(result);
        return 1;
        
    }
    
    static int getDifference(char a, char b) {
        return (int)(a - b);
    }
}