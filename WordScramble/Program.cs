using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace WordScramble
{
    class Program
    {
        static void Main(string[] args)
        {
            string source = File.ReadAllText(@"C:\Users\Bálint\source\repos\WordScramble\WordScramble\Source.txt");
            List<string> wordList = ParseWordsToList(source);
            
            Console.WriteLine("Ide ird a szot te allat: ");

            string scrambledWord = Console.ReadLine();

            List<string> resultList = SolveScramble(scrambledWord, wordList);

            //Gábor 152
            //Bálint 50
            if (resultList.Count != 0)
            {
                for (int i = 0; i < resultList.Count; i++)
                {
                    Console.WriteLine("Eredmeny:");
                    Console.WriteLine(resultList[i]);
                }
            }
            else
            {
                Console.WriteLine("Nincs ilyen teso");
            }
        }

        static List<string> SolveScramble(string scrambledWord, List<string> words)
        {
            List<string> resultList = new List<string>();




            //Filter
            for (int i = 0; i < words.Count; i++)
            {

                bool everyCharFound = true;
                for (int j = 0; j < scrambledWord.Length; j++)
                {
                    if (!words[i].Contains(scrambledWord[j]))
                    {
                        everyCharFound = false;
                    }
                }



                if (everyCharFound == true)
                {
                    resultList.Add(words[i]);
                }


            }




            return resultList;
        }

        public static string RemoveSpecialChars(string word)
        {
            Regex specialChar = new Regex(@"[\W+]");
            int i = 0;
            while (i < word.Length)
            {
                Match match = specialChar.Match(word[i].ToString());
                if (match.Success) //If the current char a special char, then remove it
                {
                    word = word.Remove(i, 1);
                }
                else
                {
                    i++;
                }
            }
            return word;
        }

        static List<string> ParseWordsToList(string text)
        {

            MatchCollection mc = Regex.Matches(text.ToLower(), @"[\S]+");

            var matches = new string[mc.Count];

            List<string> Words = new List<string>();
            for (int i = 0; i < matches.Length; i++)
            {
                Words.Add(mc[i].ToString());
            }

            for (int i = 0; i < Words.Count; i++)
            {
                Words[i] = RemoveSpecialChars(Words[i]);
            }


            return Words;
        }
    }
}
