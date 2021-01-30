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
            int lengthWord = word.Length;
            int remainingCharacters = lengthWord;
            char[] encryptedWord = GetEncryptedWord(lengthWord);
            while (remainingCharacters != 0 && counterLifes != 0 )
            {
                consoleworker.DisplayWordwithLifes(counterLifes, new string(encryptedWord), DeclinationLife(counterLifes));
                char sym = consoleworker.ReadSymbol();
                UpdateStats(ref remainingCharacters, ref counterLifes, sym, word, encryptedWord);
            }
            if( counterLifes == 0)
                consoleworker.WriteEndMessage(false);

        }
        private string DeclinationLife (int counterLifes)
        {
            if (counterLifes % 10 == 0 || (counterLifes % 10 >= 5 && counterLifes % 10 <= 9) || (counterLifes >= 10 && counterLifes <= 20))
                return "жизней";
            else if (counterLifes % 10 == 1)
                return "жизнь";
            else
                return "жизни";
        }
        private char[] GetEncryptedWord(int lengthWord)
        {
            char[] encryptedWord = new char[lengthWord];
            for (int i = 0; i < lengthWord; i++)
            {
                encryptedWord[i] = '_';
            }
            return encryptedWord;
        }
        private void UpdateStats(ref int remainingCharacters, ref int counterLifes, char sym, string word,  char[] encryptedWord)
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
        private bool IsContains(string word, char sym)
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
