using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Виселица
{
    public static class Words
    {
        public static string GiveOutWord()
        {
            string[] allWords = File.ReadAllLines("words.txt");
            int countWords = allWords.Length;
            Random rnd = new Random();
            return allWords[rnd.Next(0, countWords)].ToLower();
        }
    }
}
