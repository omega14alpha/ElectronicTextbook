using ElectronicTextbook.Models.PieceOfText;
using System;

namespace ElectronicTextbook
{
    internal class Program
    {
        private  static Textbook _textbook;

        static void Main(string[] args)
        {
            string filePath = Environment.CurrentDirectory + "\\test.txt";
            _textbook = new Textbook(filePath);
            Text text = _textbook.GetTextModel();
            ShowData(text);

            WorkMenu();
        }

        private static void WorkMenu()
        {
            Console.WriteLine("\nOptions menu:");
            Console.WriteLine("\t1. Show all sentences in order of increasing the number of words.");
            Console.WriteLine("\t2. Show all words of a given length in questioning sentences.");
            Console.WriteLine("\t3. Delete all words of a given length that begin with a consonant letter.");
            Console.WriteLine("\t4. Replace words of the specified length with the entered word in the selected sentence.");
            Console.Write("\tPress any button to exit.\nYour choice? ");
            int.TryParse(Console.ReadLine(), out int choise);

            switch (choise)
            {
                case 1: 
                    { 
                        var result = _textbook.SortingByOrderOfIncreasingNumberOfWords();
                        ShowData(result);
                        break; 
                    }
                case 2: 
                    {
                        Console.Write("Enter length: ");
                        int.TryParse(Console.ReadLine(), out int length);
                        _textbook.GetAllWordsOfGivenLengthInQuestioningSentences(length);

                        break; 
                    }
                case 3: { break; }
                case 4: { break; }
                default:
                    {
                        Environment.Exit(0);
                        break;
                    }
            }
        }

        private static void ShowData(Text text)
        {
            foreach (var item in text)
            {
                Console.Write(item);
            }
        }
    }
}
