using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Виселица
{
    class Words
    {
        public static string GiveOutWord()
        {
            string[] allWords = File.ReadAllLines("words.txt");
            int countWords = allWords.Length;
            Random rnd = new Random();
            return allWords[rnd.Next(0, countWords)].ToLower();
        }
        public static void StartWords(Button button)
        {
            WorkInConsole.ConsolePrintDummy(button);
        }
    }
}
