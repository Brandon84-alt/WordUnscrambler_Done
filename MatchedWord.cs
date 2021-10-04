using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordUnscrambler
{
    struct MatchedWord
    {


        public string ScrambledWord;
        public string Word;

        public string GetScrambledWord()
        {
            return ScrambledWord; 
        }

        public void SetScrambledWords(string ScrambledWord_arg)
        {
            ScrambledWord = ScrambledWord_arg;
        }
        
        public string GetWord()
        {
            return Word; 
        }

        public void SetWord(string Word_arg)
        {
            Word = Word_arg;
        }

    }
}
