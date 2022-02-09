using System;
using System.Collections.Generic;

namespace _07._WordsCruncher
{
    public class Program
    {
        private static string[] words;
        private static string target;
        private static string currentlyGeneratedWord;
        private static Dictionary<int, List<string>> wordsByLengthDictionary;
        private static Dictionary<string, int> wordOccurances;
        private static List<string> selectedWords;
        private static HashSet<string> results = new HashSet<string>();

        public static void Main()
        {
            words = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
            target = Console.ReadLine();

            wordsByLengthDictionary = new Dictionary<int, List<string>>();
            wordOccurances = new Dictionary<string, int>();
            selectedWords = new List<string>();

            foreach (var word in words)
            {
                var length = word.Length;

                if (wordsByLengthDictionary.ContainsKey(length) == false)
                {
                    wordsByLengthDictionary.Add(length, new List<string>());
                }

                wordsByLengthDictionary[length].Add(word);

                if (wordOccurances.ContainsKey(word) == false)
                {
                    wordOccurances.Add(word, 1);
                }
                else
                {
                    wordOccurances[word] += 1;
                }
            }

            currentlyGeneratedWord = string.Empty;
            GenerateSolutions(target.Length);

            Console.WriteLine(string.Join(Environment.NewLine, results));
        }

        private static void GenerateSolutions(int remainingLength)
        {
            if (remainingLength == 0)
            {
                if (currentlyGeneratedWord == target)
                {
                    results.Add(string.Join(" ", selectedWords));
                }

                return;
            }

            foreach (var wordsByLength in wordsByLengthDictionary)
            {
                if (wordsByLength.Key > remainingLength)
                {
                    continue;
                }

                foreach (var word in wordsByLength.Value)
                {
                    if (wordOccurances[word] > 0)
                    {
                        currentlyGeneratedWord += word;

                        if (IsCurrentlyGeneratedWordMatchingTargetWordSoFar(target, currentlyGeneratedWord))
                        {
                            wordOccurances[word] -= 1;
                            selectedWords.Add(word);
                            GenerateSolutions(remainingLength - word.Length);
                            wordOccurances[word] += 1;
                            selectedWords.RemoveAt(selectedWords.Count - 1);
                        }

                        currentlyGeneratedWord = currentlyGeneratedWord.Remove(currentlyGeneratedWord.Length - word.Length, word.Length);
                    }
                }
            }
        }

        private static bool IsCurrentlyGeneratedWordMatchingTargetWordSoFar(string expected, string actual)
        {
            for (int i = 0; i < actual.Length; i++)
            {
                if (expected[i] != actual[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
