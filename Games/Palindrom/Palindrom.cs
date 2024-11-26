using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.Metrics;

// Solution with O(n) time complexity
class Program
{ 
    public static bool IsPalindrome(string word)
    {
        string word_standard = new string(word.ToLower().Where(char.IsLetterOrDigit).ToArray());
        char[] charArray = word_standard.ToCharArray();
        Array.Reverse(charArray);
        return word_standard == new string(charArray);
    }

    public static void Main()
    {
        // Test
        
        Console.WriteLine(IsPalindrome("madam")); 
        Console.WriteLine(IsPalindrome("loto"));
        Console.WriteLine(IsPalindrome("radio"));
        Console.WriteLine(IsPalindrome("AXA"));
    }

   
}
