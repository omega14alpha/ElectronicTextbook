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
            ShowText(_textbook.Text);
            WorkMenu();
        }

        private static void WorkMenu()
        {
            while (true)
            {
                Console.WriteLine("\nOptions menu:");
                Console.WriteLine("\t1. Show all sentences in order of increasing the number of words.");
                Console.WriteLine("\t2. Show all words of a given length in questioning sentences.");
                Console.WriteLine("\t3. Delete all words of a given length that begin with a consonant letter.");
                Console.WriteLine("\t4. Replace words of the specified length with the entered word in > '-' <.");
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
            ShowAsColumn(result);
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
            string testStr = "TestWord";
            var result = _textbook.ReplaceWordsInSentence(length, testStr);
            ShowText(result);
        }

        private static int EnterNumber(string message)
        {
            Console.Write(message);
            int.TryParse(Console.ReadLine(), out int length);
            return length;
        }

        private static void ShowText(Text text) => Console.WriteLine(text);        

        private static void ShowAsColumn(Text text)
        {
            foreach (var item in text)
            {
                Console.WriteLine(item);
            }
        }
    }
}
