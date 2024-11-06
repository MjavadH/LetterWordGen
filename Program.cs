using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace LetterWordGen
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[] letters = { 'Q', 'W', 'E', 'R', 'T', 'Y' };
            List<string> twoLetterWordsList = new List<string>();
            List<string> threeLetterWordsList = new List<string>();
            List<string> fourLetterWordsList = new List<string>();
            List<string> validWords = new List<string>();

            // Generate words
            GenerateWords(letters, 2, twoLetterWordsList);
            GenerateWords(letters, 3, threeLetterWordsList);
            GenerateWords(letters, 4, fourLetterWordsList);

            // Validate words
            string dictionaryFile = "words.txt";
            try
            {
                foreach (string word in File.ReadLines(dictionaryFile))
                {
                    if (word.All(c => letters.Contains(Char.ToUpper(c))))
                    {
                        validWords.Add(word);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading dictionary file: {ex.Message}");
            }

            // Output results
            PrintWords("Selected letter", letters);
            PrintWords("Two Letter Words", twoLetterWordsList);
            PrintWords("Three Letter Words", threeLetterWordsList);
            PrintWords("Four Letter Words", fourLetterWordsList);
            PrintWords("Valid Words", validWords);

            Console.ReadKey();
        }

        static void GenerateWords(char[] letters, int length, List<string> words)
        {
            if (length == 2)
            {
                foreach (char letter1 in letters)
                {
                    foreach (char letter2 in letters)
                    {
                        words.Add($"{letter1}{letter2}");
                    }
                }
            }
            else if (length == 3)
            {
                foreach (char letter1 in letters)
                {
                    foreach (char letter2 in letters)
                    {
                        foreach (char letter3 in letters)
                        {
                            words.Add($"{letter1}{letter2}{letter3}");
                        }
                    }
                }
            }
            else if (length == 4)
            {
                foreach (char letter1 in letters)
                {
                    foreach (char letter2 in letters)
                    {
                        foreach (char letter3 in letters)
                        {
                            foreach (char letter4 in letters)
                            {
                                words.Add($"{letter1}{letter2}{letter3}{letter4}");
                            }
                        }
                    }
                }
            }
        }

        static void PrintWords(string title, List<string> words)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{title}: {words.Count}");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(string.Join(",", words));
            Console.WriteLine("\n ---------------");
        }
        static void PrintWords(string title, char[] words)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{title}: {words.Length}");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(string.Join(",", words));
            Console.WriteLine("\n ---------------");
        }
    }
}
