using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.Metrics;

class Program
{
    public static string PasswordGenerator(int length, bool includeUppercase, bool includeLowercase, bool includeNumbers, bool includeSpecial)
    {
        // Pool of characters
        string uppercase = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        string lowercase = "abcdefghijklmnopqrstuvwxyz";
        string numbers = "0123456789";
        string special = "!@#$%^&*()-_+=<>?";
        string characterPool = "";

        if (includeUppercase) characterPool += uppercase;
        if (includeLowercase) characterPool += lowercase;
        if (includeNumbers) characterPool += numbers;
        if (includeSpecial) characterPool += special;

        if (string.IsNullOrEmpty(characterPool))
            throw new ArgumentException("At least one character type must be selected.");

        Random random = new Random(); 
        return new string(Enumerable.Range(0, length).Select(_ => characterPool[random.Next(characterPool.Length)]).ToArray()); 

    }
    
            public static void Main()
    {
        // Test
        Console.WriteLine(PasswordGenerator(45, true, true, true, true)); // Very Strong
        Console.WriteLine(PasswordGenerator(20, true, false, true, false)); // Medium 
        Console.WriteLine(PasswordGenerator(5, true, true, false, false)); // Very week 
    }
}