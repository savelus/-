using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Виселица
{
    public class Logic
    {
        public void Start()
        {
            WorkInConsole consoleworker = new WorkInConsole();
            int counterLifes = consoleworker.WriteStartMessage();
            Play(counterLifes, consoleworker);
        }
        public void Play(int counterLifes, WorkInConsole consoleworker)
        {
            string word = Words.GiveOutWord();
            int lengthword = word.Length;
            int remainingCharacters = lengthword;
            char[] encryptedWord = new char[lengthword];
            for (int i = 0; i < lengthword; i++)
            {
                encryptedWord[i] = '_';
            }
            while (remainingCharacters != 0 && counterLifes != 0 )
            {
                consoleworker.DisplayWordwithLifes(counterLifes, new string(encryptedWord));
                char sym = consoleworker.ReadSymbol();
                counterLifes = UpdateStats
                    (ref remainingCharacters, counterLifes, sym, word, ref encryptedWord);
            }
            consoleworker.End();
        }
        public int UpdateStats(ref int remainingCharacters, int counterLifes, char sym, string word, ref char[] encryptedWord)
        {
            if (!IsContains(word, sym))
            {
                return counterLifes -= 1;
            }
            else
            {
                for (int i = 0; i < word.Length; i++)
                {
                    if(word[i] == sym)
                    {
                        encryptedWord[i] = sym;
                        remainingCharacters -= 1;
                    }
                }
                return counterLifes;
            }
        }
        public bool IsContains(string word, char sym)
        {
            bool isContain = false;
            foreach (var ch in word)
            {
                if (ch == sym)
                {
                    isContain = true;
                    break;
                }
            }
            return isContain;
        }
    }
}
