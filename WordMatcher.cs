using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordUnscrambler
{
    class WordMatcher
    {
        public List<MatchedWord> Match(string[] scrambledWords, string[] wordList)
        {
            
            List<MatchedWord> matchedWords = new List<MatchedWord>();

            foreach (var scrambledWord in scrambledWords)
            {
                foreach (var word in wordList)
                {
                    
                    if (scrambledWord.Equals(word, StringComparison.OrdinalIgnoreCase)) 
                    {
                        matchedWords.Add(BuildMatchedWord(scrambledWord, word));
                    }
                    else
                    {
                        char[] scrambledWordArray = scrambledWord.ToCharArray();
                        char[] WordArray = word.ToCharArray();


                        Array.Sort(scrambledWordArray);
                        Array.Sort(WordArray);

                        string sorted1 = new string (scrambledWordArray);
                        string sorted2 = new string (WordArray);

                        if (sorted1 == sorted2)
                        {
                            matchedWords.Add(BuildMatchedWord(scrambledWord, word));
                        }

                    }
                }
            }

            return matchedWords;
            
        }
        MatchedWord BuildMatchedWord(string scrambledWord, string word)
            {
                MatchedWord matchedWord = new MatchedWord
                {
                    ScrambledWord = scrambledWord,
                    Word = word
                };

                return matchedWord;
            }
        }

}
