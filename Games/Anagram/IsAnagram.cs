using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.Metrics;

// Solution with O(n) time complexity
class Program
{
   public static void IsAnagram(string word1, string word2)
   {
        string word1_standard = word1.ToLower().Replace(" ", "");
        string word2_standard = word2.ToLower().Replace(" ", "");

        if(word1_standard.Length != word2_standard.Length)
        {
            Console.WriteLine("They're definitely not anagrams lol !"); 
            return; 
        }

        var charCount1 = new Dictionary<char, int>();
        var charCount2 = new Dictionary<char, int>();

        foreach (char c in word1_standard)
        {
            if (!charCount1.ContainsKey(c))
                charCount1[c] = 0;
            charCount1[c]++;
        }

        foreach (char c in word2_standard)
        {
            if (!charCount2.ContainsKey(c))
                charCount2[c] = 0;
            charCount2[c]++;
        }

        if(charCount1.Count != charCount2.Count || !charCount1.All(kv => charCount1.ContainsKey(kv.Key) && charCount2[kv.Key] == kv.Value))
        {
            Console.WriteLine("They're not anagrams !"); 
        }
        else
        {
            Console.WriteLine("They're anagrams !"); 
        }

   }
    public static void Main()
    {
        // Test 

        IsAnagram("Listen", "Silent");          // Yes, they're anagrams!
        IsAnagram("The eyes", "They see");      // Yes, they're anagrams!
        IsAnagram("Hello", "World");            // No, they're not anagrams
        IsAnagram("abc", "aabbcc");             // No, they're definitely not !!

    }

   
}
