using ElectronicTextbook.Infrastructure.Interfaces;
using System;
using System.Linq;

namespace ElectronicTextbook
{
    internal class Program
    {
        private  static ITextbook _textbook;

        static void Main(string[] args)
        {
            GetText();
            ShowText(_textbook.Text);
            WorkMenu();
        }

        private static void GetText()
        {
            try
            {
                _textbook = new Textbook();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }            
        }

        private static void WorkMenu()
        {
            while (true)
            {
                Console.WriteLine("\nOptions menu:");
                Console.WriteLine("\t1. Show all sentences in order of increasing the number of words.");
                Console.WriteLine("\t2. Show all words of a given length in questioning sentences.");
                Console.WriteLine("\t3. Delete all words of a given length that begin with a consonant letter.");
                Console.WriteLine("\t4. Replace words of the specified length with the entered word in the selected sentence.");
                Console.Write("\tPress any button to exit.\n");
                int choise = EnterNumber("Your choice? ");

                switch (choise)
                {
                    case 1: { SortText(); break; }
                    case 2: { GetWords(); break; }      
                    case 3: { DeleteWords(); break; }
                    case 4: { ReplaceWords(); break; }
                    default: 
                        {
                            Environment.Exit(0);
                            break;
                        }
                }
            }
        }

        private static void SortText()
        {
            var result = _textbook.SortSentencesByWordsCount();
            ShowAsColumn(result);
        }

        private static void GetWords()
        {
            int length = EnterNumber("Enter length: ");
            var result = _textbook.GetWordsByLengthFromQuestions(length);
            if (result.Count() == 0)
            {
                Console.WriteLine("\nNothing found.");
            }
            else
            {
                ShowAsColumn(result);
            }            
        }

        private static void DeleteWords()
        {
            int length = EnterNumber("Enter length: ");
            var result = _textbook.DeleteWordsByLength(length);
            ShowText(result);
        }

        private static void ReplaceWords()
        {
            int length = EnterNumber("Enter length: ");
            string testStr = EnterNewWord();
            var result = _textbook.ReplaceWordsInSentence(length, testStr);
            ShowText(result);
        }

        private static int EnterNumber(string message)
        {
            Console.Write(message);
            int.TryParse(Console.ReadLine(), out int length);
            return length;
        }

        private static string EnterNewWord()
        {
            Console.Write("Enter a new word (the line must not contain punctuation marks of the end of the sentence): ");
            string newWord = Console.ReadLine();
            return newWord;
        }

        private static void ShowText(IText text) => Console.WriteLine("\n" + text);        

        private static void ShowAsColumn(IText text)
        {
            Console.WriteLine();
            foreach (var item in text)
            {
                Console.WriteLine(item);
            }
        }
    }
}
