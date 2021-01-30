using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

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
            int lengthWord = word.Length;
            int remainingCharacters = lengthWord;
            char[] encryptedWord = GetEncryptedWord(lengthWord);
            do
            {
                DisplayWordWithLifes(counterLifes, encryptedWord, false);
                char sym = consoleworker.ReadSymbol();
                int lifesBeforeUpdates = counterLifes;
                UpdateStats(ref remainingCharacters, ref counterLifes, sym, word, encryptedWord);
                if (lifesBeforeUpdates != counterLifes)
                {
                    DisplayWordWithLifes(counterLifes, encryptedWord, true);
                    Thread.Sleep(200);
                }
            }
            while (remainingCharacters != 0 && counterLifes != 0);
            if ( counterLifes == 0)
                consoleworker.WriteEndMessage(false);
        }
        private void DisplayWordWithLifes(int counterLifes, char[] encryptedWord, bool mistake)
        {
            WorkInConsole consoleworker = new WorkInConsole();
            consoleworker.DisplayWordwithLifes(counterLifes, new string(encryptedWord), DeclinationLife(counterLifes), mistake);

        }
        private string DeclinationLife (int counterLifes) //склонение "Жизнь"
        {
            if (counterLifes % 10 == 0 || (counterLifes % 10 >= 5 && counterLifes % 10 <= 9) || (counterLifes >= 10 && counterLifes <= 20))
                return "жизней";
            else if (counterLifes % 10 == 1)
                return "жизнь";
            else
                return "жизни";
        }
        private char[] GetEncryptedWord(int lengthWord) //массив "_"
        {
            char[] encryptedWord = new char[lengthWord];
            for (int i = 0; i < lengthWord; i++)
            {
                encryptedWord[i] = '_';
            }
            return encryptedWord;
        }
        private void UpdateStats(ref int remainingCharacters, ref int counterLifes, char sym, string word,  char[] encryptedWord) // изменеяет статистику
        {
            if (!IsContains(word, sym))
            {
                counterLifes -= 1;
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
            }
        }
        private bool IsContains(string word, char sym) //буква содержится в загаданном слове
        {
            foreach (var ch in word)
            {
                if (ch == sym)
                {
                    return true;
                }
            }
            return false;
            
        }

    }
}
