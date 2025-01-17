using System;
using System.Linq;

class ImprovedCaesarCipher
{
    public static int process(string formattedText, string decodedWord)
    {
        int length = decodedWord.Length;
        int difference = formattedText.Split()
            .FirstOrDefault(word => word.Length == length && 
                word.Zip(decodedWord, (a, b) => a - b).Distinct().Count() == 1)?
            .First() - decodedWord[0] ?? 0;

        if (difference == 0)
            return -1;

        formattedText = new string(formattedText.Select(c =>
            char.IsLetter(c) ? (char)(((c - getRightA(c) + 26 - difference) % 26) +  getRightA(c)) : c
        ).ToArray());

        Console.WriteLine(formattedText);
        return 1;
    }

    private static char getRightA(char c){
        return (char.IsUpper(c) ? 'A' : 'a');
    }
}
