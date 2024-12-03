public static void WordFrequencyCounter()
{
    Console.WriteLine("Please enter a paragraph of text:");
    string input = Console.ReadLine();
    string normalizedInput = new string(input.Where(c => !char.IsPunctuation(c)).ToArray()).ToLower();
    string[] words = normalizedInput.Split(' ', StringSplitOptions.RemoveEmptyEntries);

    // Count the frequency of each word
    Dictionary<string, int> wordFrequencies = new Dictionary<string, int>();
    foreach (string word in words)
    {
        if (wordFrequencies.ContainsKey(word))
        {
            wordFrequencies[word]++;
        }
        else
        {
            wordFrequencies[word] = 1;
        }
    }

    Console.WriteLine("Word frequencies:");
    foreach (var pair in wordFrequencies.OrderBy(pair => pair.Key))
    {
        Console.WriteLine($"{pair.Key}: {pair.Value}");
    }
}
