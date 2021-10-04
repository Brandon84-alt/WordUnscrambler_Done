using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordUnscrambler
{
    class Program
    {
        private static readonly FileReader _fileReader = new FileReader();
        private static readonly WordMatcher _wordMatcher = new WordMatcher();


        static void Main(string[] args)
        {
            try
            {
                bool continueWordUnscramble = true;

                do
                {

                    
                    Console.WriteLine("Enter scrambled word(s) manually or as a file: F - file / M - manual");

                    String option = Console.ReadLine() ?? throw new Exception("String is empty");


                    
                    switch (option.ToUpper())
                    {
                        case "F":
                            Console.WriteLine(Constants.EnterScrambledWordsViaFile);
                            ExecuteScrambledWordsInFileScenario();
                            break;
                        case "M":
                            Console.WriteLine(Constants.Manual);
                            ExecuteScrambledWordsManualEntryScenario();
                            break;
                        default:
                            Console.WriteLine(Constants.NotRecognized);
                            break;
                    }

                    
                    var userinput = String.Empty;
                    do
                    {
                        Console.WriteLine(Constants.OptionToContinue);
                        userinput = Console.ReadLine() ?? string.Empty;
                       
                    } while (!userinput.ToUpper().Equals("Y", StringComparison.OrdinalIgnoreCase) &&
                             !userinput.ToUpper().Equals("N", StringComparison.OrdinalIgnoreCase));
                   
                     continueWordUnscramble = userinput.Equals("Y", StringComparison.OrdinalIgnoreCase);

                } while (continueWordUnscramble);

            }

            catch (Exception ex)
            {
                Console.WriteLine("The program will be terminated." + ex.Message);

            }
        }

        private static void ExecuteScrambledWordsInFileScenario()
        {
            
            try
            {
                var filename = Console.ReadLine();
                string[] scrambledWords = _fileReader.Read(filename);

                    DisplayMatchedUnscrambledWords(scrambledWords);
            }
            catch (Exception e)
            {
                //print exception
                System.Console.WriteLine("Scrambled words were not loaded because there was an error" + e);
                throw;
            }
        }

        private static void ExecuteScrambledWordsManualEntryScenario()
        {
            
            //create empty string manuelInput
            var manualInput = Console.ReadLine() ?? string.Empty;
            //splits with comma
            char[] separators = {',', ' '};
            string[] scrambledWords = manualInput.Split(separators);
            DisplayMatchedUnscrambledWords(scrambledWords);
        }

        private static void DisplayMatchedUnscrambledWords(string[] scrambledWords)
        {
          
           string[] wordList = _fileReader.Read("wordlist.txt");
            
            List<MatchedWord> matchedWords = new List<MatchedWord>();
            matchedWords = _wordMatcher.Match(scrambledWords, wordList);
            if (matchedWords.Any())
            {
                foreach (var match in matchedWords)
                {
                   // scrambledWords.Equals(wordList, StringComparison.OrdinalIgnoreCase);
                   Console.WriteLine(Constants.MatchFound, match.GetScrambledWord().ToString(),
                       match.GetWord().ToString());


                }
            }
            else
            {
                //If no word has been found prints this.
                Console.WriteLine(Constants.MatchNotFound);
            }
        }
    }
}
