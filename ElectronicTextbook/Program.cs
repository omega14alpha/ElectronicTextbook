using ElectronicTextbook.Infrastructure;
using ElectronicTextbook.Infrastructure.Interfaces;
using ElectronicTextbook.Models;
using System;
using System.Linq;

namespace ElectronicTextbook
{
    internal class Program
    {
        private static ITextbook _textbook;

        static void Main(string[] args)
        {
            GetText();
            Console.WriteLine("\n" + _textbook.Text.Value);
            WorkMenu();
        }

        private static void GetText()
        {
            _textbook = new Textbook();
            var configurationWorker = new XmlFileWorker<ConfigurationModel>();
            try
            {
                var config = configurationWorker.ReadData();
                _textbook.GetTextFromFile(config.FilePath);
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
                Console.WriteLine("\n\nOptions menu:");
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
            Console.WriteLine();
            foreach (var item in result)
            {
                Console.WriteLine(item.Value);
            }
        }

        private static void GetWords()
        {
            int length = EnterNumber("Enter length: ");
            var result = _textbook.GetWordsByLengthFromQuestions(length);
            if (result.Any())
            {
                Console.WriteLine();
                foreach (var item in result)
                {
                    Console.WriteLine(item.Value);
                }
            }
            else
            {
                Console.WriteLine("\nNothing found.");
            }
        }

        private static void DeleteWords()
        {
            int length = EnterNumber("Enter length: ");
            var result = _textbook.DeleteWordsByLength(length);
            Console.WriteLine();
            foreach (var item in result)
            {
                Console.Write(item.Value);
            }
        }

        private static void ReplaceWords()
        {
            int length = EnterNumber("Enter length: ");
            string testStr = EnterNewWord();
            var result = _textbook.ReplaceWordsInSentence(length, testStr);
            Console.WriteLine("\n" + result.Value);
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
            return Console.ReadLine();
        }
    }
}
